using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.DLL;


namespace DVDLibrary.Tests
{
    public class MockDVDLibrary : IDVDRepository
    {
        private DVDInfo dvd = new DVDInfo();
        private List<DVDInfo> dvdList = new List<DVDInfo>();

        public MockDVDLibrary()
        {
            dvdList.Add(new DVDInfo()
            {
                dvdID = 1,
                Title = "Avengers: Age of Ultron",
                ReleaseDate = "2015-05-01",
                DirectorsName = "Joss Whedon",
                MPAARating = "PG-13",
                Studio = "Marvel",
                UserRating = "7.7",
                UserNotes = "It was kinda good",
                ActorsInMovies = "Robert Downey Jr., Chris Evans, Chris Hemsworth"
            });

            dvdList.Add(new DVDInfo()
            {
                dvdID = 2,
                Title = "Avengers",
                ReleaseDate = "2013-05-01",
                DirectorsName = "Joss Whedon",
                MPAARating = "PG-13",
                Studio = "Marvel",
                UserRating = "7.7",
                UserNotes = "It was kinda good",
                ActorsInMovies = "Robert Downey Jr., Chris Evans, Chris Hemsworth"
            });
        }

        public void AddBorrower(DVDInfo borrower)
        {
            throw new NotImplementedException();
        }

        public void CreateDVD(DVDInfo DVD)
        {
            var dvd = GetAllDVDs();
            dvd.Add(DVD);
        }

        public List<DVDInfo> GetAllDVDs()
        {
            return dvdList;
        }

        public DVDInfo LoadDVD(int dvdID)
        {
            List<DVDInfo> DVDs = GetAllDVDs();
            return DVDs.FirstOrDefault(a => a.dvdID == dvdID);
        }

        public void RemoveDVDInfo(int dvdID)
        {
            dvdList.RemoveAll(x => x.dvdID == dvdID);
      
        }

        public void ReturnDVD(DVDInfo borrower)
        {
            throw new NotImplementedException();
        }

        public List<DVDInfo> SearchDVD(string dvdQuery)
        {
            throw new NotImplementedException();
        }
    }
}
