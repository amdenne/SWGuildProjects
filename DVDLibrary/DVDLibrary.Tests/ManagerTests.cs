using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.BLL;
using DVDLibrary.Models;

namespace DVDLibrary.Tests
{
    [TestFixture]
    class ManagerTests
    {
        [Test]
        public void LoadDVDTest()
        {
            List<DVDInfo> dvdList = new List<DVDInfo>();
            var manager = new DVDManager(new MockDVDLibrary());
            var response = manager.LoadAllDVDs();

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Data.Count(), 2);
        }

        [Test]
        public void GetDVDTEST()
        {
            DVDInfo dvd = new DVDInfo();
            var manager = new DVDManager(new MockDVDLibrary());
            var response = manager.GetDVDInfo(1);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Data.Title, "Avengers: Age of Ultron");
        }

        [Test]
        public void CreateDVDTest()
        {
            DVDInfo dvd = new DVDInfo()
            {
                dvdID = 3,
                Title = "new move",
                ReleaseDate = "2015-05-01",
                DirectorsName = "Joss Whedon",
                MPAARating = "PG-13",
                Studio = "studio",
                UserRating = "7.7",
                UserNotes = "It was kinda good",
                ActorsInMovies = "actors"
            };
           
            var manager = new DVDManager(new MockDVDLibrary());
            var response = manager.CreateDVD(dvd);
            var dvdList = manager.LoadAllDVDs();

            Assert.AreEqual(dvdList.Data.Count(), 3);
        }

        [Test]
        public void DeleteDVDTest()
        {
            var manager = new DVDManager(new MockDVDLibrary());
            var response = manager.DeleteDVD(2);
            var dvdList = manager.LoadAllDVDs();

            Assert.AreEqual(dvdList.Data.Count(), 1);
        }
    }
}
