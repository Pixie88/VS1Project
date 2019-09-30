using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using Common;

namespace GalaxyCinemas
{
    public class SessionImporter : BaseImporter
    {
        public SessionImporter(string filename) : base(filename)
        {
        }

        /// <summary>
        /// Import session file. Filename has been provided in the constructor.
        /// </summary>
        public override void Import(object o)
        {
            // Initialise progress to zero for progress bar.
            Progress = 0f;
            ImportResult results = new ImportResult();
            try
            {
                // Read file
                string fileData = null;
                using (StreamReader reader = File.OpenText(fileName))
                {
                    fileData = reader.ReadToEnd();
                }
                string[] lines = fileData.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n'); // To deal with Windows, Mac and Linux line endings the same.

                string firstLine = lines[0];
                string[] columns = firstLine.Split(',');
                // Check if first line is column names.
                if (columns.Count() == 4)
                {
                    columns[0] = columns[0].Trim().ToLower();
                    columns[1] = columns[1].Trim().ToLower();
                    columns[2] = columns[2].Trim().ToLower();
                    columns[3] = columns[3].Trim().ToLower();
                    if (columns[0] == "sessionid" && columns[1] == "movieid" && columns[2] == "sessiondate" && columns[3] == "cinemanumber")
                    {
                        lines[0] = "";
                    }

                }
                else
                    Console.WriteLine("First column does not contain column names");

                // Line count and line numbers to allow progress tracking.
                int lineCount = lines.Length;
                int lineNum = 1;

                // Get all movies. These will be used to check that MovieIDs are valid.
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
                        // Just to make it slow enough to testing stopping functionality.
                        Thread.Sleep(500);

                        // Update progress of import.
                        Progress = lineNum / lineCount;
                        RaiseProgressChanged();

                        // Skip blank lines and increase total rows
                        if (line == "")
                        {
                            continue;
                        }
                        else
                        {
                            results.TotalRows++;
                        }

                        // Break up line by commas, each item in array will be one column.
                        columns = line.Split(',');

                        if (columns.Length != 4)
                        {
                            results.FailedRows++;
                            results.ErrorMessages.Add(string.Format("Line {0}: Wrong number of columns.", lineNum));
                            continue;
                        }

                        // Check the format of data, and update ImportResult accordingly.
                        // Check movie ID.
                        int movieID = 0;
                        if (!int.TryParse(columns[1].Trim(), out movieID))
                        {
                            results.FailedRows++;
                            results.ErrorMessages.Add(string.Format("Line {0}: MovieID is not a number.", lineNum));
                            continue;
                        }
                        if (movies.Count(m => m.MovieID == movieID) < 1)
                        {
                            results.FailedRows++;
                            results.ErrorMessages.Add(string.Format("Line {0}: MovieID not found in movie database.", lineNum));
                            continue;
                        }
                        // Check session date/time.
                        DateTime sessionDate = DateTime.MinValue;
                        if (!DateTime.TryParse(columns[2].Trim(), out sessionDate))
                        {
                            results.FailedRows++;
                            results.ErrorMessages.Add(string.Format("Line{0}: Session date is not a date/time", lineNum));
                            continue;
                        }

                        // Check session ID.
                        int sessionID = 0;
                        if (!int.TryParse(columns[1].Trim(), out sessionID))
                        {
                            results.FailedRows++;
                            results.ErrorMessages.Add(string.Format("Line {0}: sessionID is not a number.", lineNum));
                            continue;
                        }

                        // Check cinema number.
                        byte cinemaNumber = 0;
                        if (!byte.TryParse(columns[1].Trim(), out cinemaNumber))
                        {
                            results.FailedRows++;
                            results.ErrorMessages.Add(string.Format("Line {0}: cinemaNumber is not a number (byte format).", lineNum));
                            continue;
                        }
                        if (cinemaNumber < 1)
                        {
                            results.FailedRows++;
                            results.ErrorMessages.Add(string.Format("Line {0}: cinema number must be postive.", lineNum));
                        }

                        // Insert/update DB if okay.
                        Session sessionToUpdate = DataLayer.DataLayer.GetSessionByID(sessionID);
                        if(sessionToUpdate == null)
                        {
                            Session sessionToAdd = new Session()
                            {
                                SessionID = sessionID,
                                MovieID = movieID,
                                SessionDate = sessionDate,
                                CinemaNumber = cinemaNumber
                            };
                            DataLayer.DataLayer.AddSession(sessionToAdd);      
                        }
                        else
                        {
                            sessionToUpdate.MovieID = movieID;
                            sessionToUpdate.SessionDate = sessionDate;
                            sessionToUpdate.CinemaNumber = cinemaNumber;
                            DataLayer.DataLayer.UpdateSession(sessionToUpdate);
                        }
                        results.ImportedRows++;
                    }
                    catch (System.Data.Common.DbException dbEx)
                    {
                        results.FailedRows++;
                        results.ErrorMessages.Add(string.Format("Line {0}: Database error occurred updating data.", lineNum));
                    }
                    finally
                    {
                        lineNum++;
                    }
                }
            }
            catch (System.IO.IOException)
            {
                results.ErrorMessages.Add("Error occurred opening file. Please check that the file exists and that you have permissions to open it.");
            }
            catch (Exception)
            {
                results.ErrorMessages.Add("An unknown error occurred during importing.");
            }
            finally
            {
                // Do callback to end import.
                RaiseCompleted(results);
            }

        
        }

    }
}
