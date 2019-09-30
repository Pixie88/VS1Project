using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyCinemas
{
    public class ImportResult
    {
        public int TotalRows { get; set; }
        public int ImportedRows { get; set; }
        public int FailedRows { get; set; }

        private List<String> errorMessages;

        //question 16 
        public List<String> ErrorMessages
        {
            get { return errorMessages; }
        }

        //question 17 - constructor to clear properties
        public ImportResult()
            {
            TotalRows = 0;
            ImportedRows = 0;
            FailedRows = 0;
            errorMessages.Clear();
            }

    }



}
