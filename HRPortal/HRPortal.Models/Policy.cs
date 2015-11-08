using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class Policy
    {
        public string PolicyTitle { get; set; }
        public string PolicyDescription { get; set; }
        public string Category { get; set; }
        public int PolicyID { get; set; }

        public string FilePath
        {
            get
            {
                return @"C:\_Bitbucket\FlooringProgram\flooringprogram\HRPortal\DataFiles\" + Category + ".txt";
            }
        }
    }
}
