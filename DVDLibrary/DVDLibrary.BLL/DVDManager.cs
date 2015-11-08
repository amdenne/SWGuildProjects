using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DVDLibrary.Models;
using System.Threading.Tasks;
using DVDLibrary.DLL;

namespace DVDLibrary.BLL
{
    public class DVDManager
    {
        private IDVDRepository _repo;

        public DVDManager()
        {
            //_repo = new DVDRepository();
            _repo = new DVDRepository();
        }

        public DVDManager(IDVDRepository repo)
        {
            _repo = repo;
        }

        public Response<List<DVDInfo>> LoadAllDVDs()
        {
            var response = new Response<List<DVDInfo>>();

            try
            {
                response.Data = _repo.GetAllDVDs();
                response.Message = "Success!";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<DVDInfo> GetDVDInfo(int dvdID)
        {
            var response = new Response<DVDInfo>();

            try
            {
                DVDInfo DVD = new DVDInfo()
                {
                    BorrowerInfo = new BorrowerInformation()
                };

                DVD = _repo.LoadDVD(dvdID);

                if (DVD == null)
                {
                    response.Success = false;
                    response.Message = "DVD was not found in our database...";
                }
                else
                {
                    response.Success = true;
                    response.Data = DVD;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<DVDInfo> CreateDVD(DVDInfo DVD)
        {
            var response = new Response<DVDInfo>();
            bool foundDVD = false;

            try
            {
                var allDVDs = _repo.GetAllDVDs();

                response.Data = new DVDInfo();

                foreach(var dvd in allDVDs)
                {
                    if (DVD.Title == dvd.Title)
                    {
                        response.Success = false;
                        response.Message = "A DVD with that title already exists! Please try again...";
                        foundDVD = true;
                        
                    }
                }

                if(!foundDVD)
                {
                    response.Success = true;
                    _repo.CreateDVD(DVD);
                    response.Message = "You have successfully added a DVD to the database!";
                }
             
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<DVDInfo> DeleteDVD(int dvdID)
        {
            var response = new Response<DVDInfo>();

            try
            {
                _repo.RemoveDVDInfo(dvdID);
                response.Success = true;
                response.Message = "Successfully delete the DVD information from the database.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<DVDInfo>> SearchDVD(string dvdQuery)
        {
            var response = new Response<List<DVDInfo>>();
            try
            {
                response.Data =  _repo.SearchDVD(dvdQuery);
                response.Success = true;
                response.Message = "Successfully found the dvd info for " + dvdQuery;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<DVDInfo> AddBorrower(DVDInfo borrower)
        {

            var response = new Response<DVDInfo>();

            response.Data = new DVDInfo()
            {
                BorrowerInfo = new BorrowerInformation()
            };
            response.Data = GetDVDInfo(borrower.dvdID).Data;

            //response.Data.ActorsInMovies = dvd.ActorsInMovies;
            //response.Data.DirectorsName = dvd.DirectorsName;
            //response.Data.dvdID = dvd.dvdID;
            //response.Data.MPAARating = dvd.MPAARating;
            //response.Data.ReleaseDate = dvd.ReleaseDate;
            //response.Data.Title = dvd.Title;
            //response.Data.UserNotes = dvd.UserNotes;
            //response.Data.UserRating = dvd.UserRating;
            //response.Data.Studio = dvd.Studio;

            response.Data.BorrowerInfo.dvdID = borrower.dvdID;
            response.Data.BorrowerInfo.Borrower = borrower.BorrowerInfo.Borrower;
            response.Data.BorrowerInfo.DateBorrowed = DateTime.Now;

            try
            {
                if (response.Data.BorrowerInfo.DateReturned != null)
                {
                    response.Success = false;
                    response.Message = "Someone already has that checked out!";
                }
                else
                {
                    _repo.AddBorrower(response.Data);
                    response.Success = true;
                    response.Message = "Successfully added a borrower to ";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<DVDInfo> ReturnDVD(DVDInfo borrower)
        {
            var response = new Response<DVDInfo>();

            response.Data = new DVDInfo()
            {
                BorrowerInfo = new BorrowerInformation()
            };

            response.Data = GetDVDInfo(borrower.dvdID).Data;

            response.Data.BorrowerInfo.DateReturned = DateTime.Now;

            try
            {
                if (response.Data.BorrowerInfo.DateReturned != null)
                {
                    _repo.ReturnDVD(response.Data);
                    response.Success = true;
                    response.Message = "Successfully returned ";
                    response.Data.BorrowerInfo = null;
                }
                              
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
