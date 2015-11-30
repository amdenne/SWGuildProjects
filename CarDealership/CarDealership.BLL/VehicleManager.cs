using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using CarDealership.Data;

namespace CarDealership.BLL
{
    public class VehicleManager 
    {
        private IVehicleRepository _repo;

        public VehicleManager()
        {
            _repo = new VehicleRepository();
        }

        public VehicleManager(IVehicleRepository repo)
        {
            _repo = repo;
        }

        public Response<List<Vehicle>> GetAllCars()
        {
            Response<List<Vehicle>> response = new Response<List<Vehicle>>();
            try
            {
                response.Data = _repo.GetAllCars();
                response.Success = true;
                response.Message = "Successfully got all cars.";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;                
        }

        public Response<Vehicle> GetCarByID(int id)
        {
            var response = new Response<Vehicle>();
            try
            {
                response.Data = _repo.GetCarByID(id);
                response.Success = true;
                response.Message = "success.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Vehicle> DeleteCarByID(int id)
        {
            var response = new Response<Vehicle>();
            try
            {
                _repo.DeleteCarByID(id);
                response.Success = true;
                response.Message = "success.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Vehicle> AddCar(Vehicle newCar)
        {
            var response = new Response<Vehicle>();
   
            try
            {
                response.Success = true;
                response.Message = "A new car was added";
                 _repo.AddCar(newCar);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<RequestInfo>> GetAllRequests()
        {
            Response<List<RequestInfo>> response = new Response<List<RequestInfo>>();

            try
            {
                response.Data = _repo.GetAllRequests();
                response.Success = true;
                response.Message = "Sucess";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public Response<RequestInfo> GetRequestByID(int id)
        {
            var response = new Response<RequestInfo>();
            try
            {
                response.Data = _repo.GetRequestByID(id);
                response.Success = true;
                response.Message = "success.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<RequestInfo> AddRequest(RequestInfo newRequest)
        {
            var response = new Response<RequestInfo>();

            try
            {
                response.Success = true;
                response.Message = "A new request was added";
                _repo.AddRequest(newRequest);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<RequestInfo> UpdateRequestStatus(int id, int status)
        {
            var response = new Response<RequestInfo>();

            try
            {
                var request = _repo.GetRequestByID(id);
                _repo.UpdateRequest(request,status);

                response.Success = true;
                response.Message = "Sucess";

            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

       
    }
}
