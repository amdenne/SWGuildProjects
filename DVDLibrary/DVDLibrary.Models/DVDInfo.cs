using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class DVDInfo  
    {
        public int dvdID { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string DirectorsName { get; set; }
        public string MPAARating { get; set; }
        public string Studio { get; set; }
        public string UserRating { get; set; }
        public string UserNotes { get; set; }
        public string ActorsInMovies { get; set; }
        public BorrowerInformation BorrowerInfo { get; set; }
    }
}