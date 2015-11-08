using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.DLL;
using HRPortal.Models;


namespace HRPortal.BLL
{
    public class ApplicationManager
    {
        private IApplicationRepository _repo;

        public ApplicationManager()
        {
            _repo = new ApplicationRepository();
        }

        public ApplicationManager(IApplicationRepository repo)
        {
            _repo = repo;
        }

        public Response<List<Application>> LoadAllApplications()
        {
            var response = new Response<List<Application>>();

            try
            {
                response.Data = _repo.GetAllApplications();
                response.Message = "Success";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public Response<Application> GetApplication(int appID)
        {
            var response = new Response<Application>();

            try
            {
                var application = _repo.LoadApplication(appID);

                if(application == null)
                {
                    response.Success = false;
                    response.Message = "Application was not found...";
                }
                else
                {
                    response.Success = true;
                    response.Data = application;
                }               
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Application> CreateApplication(Application newApplication)
        {
            var response = new Response<Application>();

            try
            {
                var allApplications = _repo.GetAllApplications();

                int LatestAppNumber = allApplications.Select(a => a.AppID).LastOrDefault();
                newApplication.AppID = LatestAppNumber + 1;

                response.Data = new Application();
                response.Data.FirstName = newApplication.FirstName;
                response.Data.LastName = newApplication.LastName;
                response.Data.Address = newApplication.Address;
                response.Data.PhoneNumber = newApplication.PhoneNumber;
                response.Data.City = newApplication.City;
                response.Data.State = newApplication.State;
                response.Data.Zip = newApplication.Zip;
                response.Data.AppID = newApplication.AppID;
                response.Data.JobHistory = newApplication.JobHistory;

                response.Success = true;
                _repo.CreateApplication(newApplication);
                response.Message = "Application was created.";
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
