using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.DLL;

namespace HRPortal.BLL
{
    public class TimeManager
    {

        private ITimeRepository _repo;

        public TimeManager()
        {
            _repo = new TimeRepository();
        }

        public TimeManager(ITimeRepository repo)
        {
            _repo = repo;
        }

        public Response<List<Time>> LoadAllTimes()
        {
            var response = new Response<List<Time>>();

            try
            {
                response.Data = _repo.GetAllTimes();
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
        public Response<Time> GetTimes(int EmpID)
        {
            var response = new Response<Time>();

            try
            {
                var time = _repo.LoadTimes(EmpID);

                if (time == null)
                {
                    response.Success = false;
                    response.Message = "Time was not found...";
                }
                else
                {
                    response.Success = true;
                    response.Data = time;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Time> CreateTime(Time newTime)
        {
            var response = new Response<Time>();

            try
            {
                var allTimes = _repo.GetAllTimes();

                int LastestTimeNumber = allTimes.Select(a => a.EmpID).LastOrDefault();
                newTime.EmpID = LastestTimeNumber + 1;

                response.Data = new Time();

                

                response.Success = true;
                _repo.CreateTime(newTime);
                response.Message = "Time was created.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public Response<Time> UpdateTime(Time time)
        {
            var response = new Response<Time>();
            
                try
                {
                    _repo.UpdateTime(time);

                    response.Success = true;
                    response.Message = "Successfully updated your account!";
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
