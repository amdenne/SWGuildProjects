using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        public List<Vehicle> GetAllCars()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var context = new DealershipContext())
            {
                var car = context.Vehicles.ToList();
                foreach (var c in car)
                {
                    vehicles.Add(c);
                }
            }
            return vehicles;
        }

        public Vehicle GetCarByID(int id)
        {
            using (var context = new DealershipContext())
            {
               return context.Vehicles.FirstOrDefault(c=>c.VehicleID == id);
            }
             
        }

        public void DeleteCarByID(int id)
        {
            using (var context = new DealershipContext())
            {
                var car = context.Vehicles.Where(c => c.VehicleID == id);

                foreach(var c in car)
                {
                    context.Vehicles.Remove(c);
                }
                context.SaveChanges();
            }
        }

        public void AddCar(Vehicle newCar)
        {
            using (var context = new DealershipContext())
            {

                context.Vehicles.Add(newCar);
                context.SaveChanges();
            }
        }

        public RequestInfo GetRequestByID(int id)
        {
            using (var context = new DealershipContext())
            {
                return context.Requests.FirstOrDefault(r => r.RequestInfoID == id);
            }

        }

        public List<RequestInfo> GetAllRequests()
        {
            List<RequestInfo> requests = new List<RequestInfo>();

            using (var context = new DealershipContext())
            {
                var request = context.Requests.ToList();
                foreach (var r in request)
                {
                    requests.Add(r);
                }
            }
            return requests;
        }

        public void AddRequest(RequestInfo newRequest)
        {
            using (var context = new DealershipContext())
            {

                context.Requests.Add(newRequest);
                context.SaveChanges();
            }
        }

        public void UpdateRequest( RequestInfo request,int status)
        {
            using (var context = new DealershipContext())
            {
               
                context.Requests.Where(x => x.RequestInfoID == request.RequestInfoID);
                request.RequestStatus = status;
                context.SaveChanges();
               
            }
        }

    }
}
