using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class BorrowerInformation
    {
        public int? dvdID { get; set; }
        public string Borrower { get; set; }
        public DateTime? DateBorrowed { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}
