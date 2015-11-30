using System.Collections.Generic;
using CarDealership.Models;

namespace CarDealership.Data
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAllCars();
        Vehicle GetCarByID(int id);
        void DeleteCarByID(int id);
        void AddCar(Vehicle newCar);
        List<RequestInfo> GetAllRequests();
        RequestInfo GetRequestByID(int id);
        void AddRequest(RequestInfo newRequest);
        void UpdateRequest(RequestInfo request, int status);
    }
}