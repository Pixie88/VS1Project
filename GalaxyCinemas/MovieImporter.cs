using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using Common;


namespace GalaxyCinemas
{
    public class MovieImporter : BaseImporter
    {
       //question 18 - constructor to set fileName
        public MovieImporter(string fileName): base(fileName)
        {
            this.fileName = fileName;
        }
  
        /// <summary>
        /// Import movie file. Filename has been provided in the constructor.
        /// </summary>
        public override void Import(object o)
        {
            // Initialise progress to zero for progress bar.
            Progress = 0;
            //Initialise results
            ImportResult result = new ImportResult();
            
            try
            {
                // Read file
                string fileData = null;
                using (StreamReader reader = File.OpenText(fileName))
                {
                    // Read file  using ReadToEnd and assign to fileData
                    fileData = reader.ReadToEnd();
                   
                }
                string[] lines = fileData.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n'); // To deal with Windows, Mac and Linux line endings the same.

                string firstLine = lines[0];

                // Split into columns
                string[] columns = firstLine.Split(',');
                //check first line is column names only
                if (columns.Count() == 2)
                {
                    columns[0] = columns[0].Trim().ToLower();
                    columns[1] = columns[1].Trim().ToLower();
                    if (columns[0] == "movieid" && columns[1] == "title")
                    {
                        lines[0] = "";
                    }

                }
                else
                    Console.WriteLine("First column does not contain column names");

                // Line count and line numbers to allow progress tracking.
                int lineCount = lines.Length;
                int lineNumber = 1;

                // Get all movies.
                List<Movie> movies = DataLayer.DataLayer.GetAllMovies();


                foreach (string line in lines)
                {
                    // Check whether we need to stop after importing each line.
                    if (Stop)
                    {
                        return;
                    }
                    try
                    {
                        // Just to make it slow enough to test stopping functionality.
                        Thread.Sleep(500);

                        // Update progress of import.
                        Progress = lineNumber / lineCount;
                        RaiseProgressChanged();

                        // Skip blank lines
                        if (line == "")
                        {
                            continue;
                        }
                        else
                        {
                            result.TotalRows++;
                        }

                        // Break up line by commas, each item in array will be one column.
                        columns = line.Split(',');
                        if (columns.Length != 2)
                        {
                            result.FailedRows++;
                            result.ErrorMessages.Add(string.Format("Line {0}: Wrong number of columns.", lineNumber));
                            continue;
                        }

                        // Check the format of data, and update ImportResult accordingly.
                        int movieID = 0;
                        if (!int.TryParse(columns[0], out movieID))
                        {
                            result.FailedRows++;
                            result.ErrorMessages.Add(string.Format("Line {0}: MovieID is not a number.", lineNumber));
                            continue;
                        }

                        string title = columns[1].Trim();
                        if (title == "") {
                            result.FailedRows++;
                            result.ErrorMessages.Add(string.Format("Line {0}: Title is empty", lineNumber));
                            continue;

                        }
                        // Insert/update DB if okay.
                        Movie movieToUpdate = movies.Where(m => m.MovieID == movieID).FirstOrDefault();
                        if (movieToUpdate == null)
                        {
                            Movie movieToAdd = new Movie() { MovieID = movieID, Title = title };
                            DataLayer.DataLayer.AddMovie(movieToAdd);
                        }
                        else
                        {
                            movieToUpdate.Title = title;
                            DataLayer.DataLayer.UpdateMovie(movieToUpdate);
                        }

                        result.ImportedRows++;

                    }

                    finally
                    {
                        lineNumber++;
                    }

                }
                    
                
            }

            catch (IOException)
            {
                result.ErrorMessages.Add(string.Format("IO Exception caught"));
            }

            catch (Exception)
            {
                result.ErrorMessages.Add(string.Format("Unknown error occured"));
            }
            finally
            {
                RaiseCompleted(result);
            }

        }

    }
}
