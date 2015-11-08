using System.Collections.Generic;
using DVDLibrary.Models;

namespace DVDLibrary.DLL
{
    public interface IDVDRepository
    {
        void CreateDVD(DVDInfo DVD);
        List<DVDInfo> GetAllDVDs();
        DVDInfo LoadDVD(int dvdID);
        void RemoveDVDInfo(int dvdID);
        List<DVDInfo> SearchDVD(string dvdQuery);
        void AddBorrower(DVDInfo borrower);
        void ReturnDVD(DVDInfo borrower);
    }
}
