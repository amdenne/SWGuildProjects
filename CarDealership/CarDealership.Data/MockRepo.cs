using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.Data
{
    public class MockRepo 
    {
        private List<Vehicle> vehicles = new List<Vehicle>() {

            new Vehicle()
                { VehicleID = 1, Make = "Ford", Model = "Mustang", Year = 2004,
                    AdTitle = "USED 2004 YELLOW MUSTANG", Description="Mustang", IsAvailable = true, Mileage =100000,
                    PictureURL="http://www.musclecardrive.com/ford/images/2004-mach-1-yellow.jpg", Price= 7000, Requests=null },

            new Vehicle()
                { VehicleID = 2, Make = "Lincoln", Model = "LS", Year = 2004,
                    AdTitle = "USED 2004 White Lincoln LS", Description="Lincoln", IsAvailable = true, Mileage =100000,
                    PictureURL="http://www.lincolnvscadillac.com/forum/attachment.php?attachmentid=828450827", Price= 7000, Requests=null }
                   };

        public List<Vehicle> GetAllCars()
        {

            return vehicles;
        }

        public Vehicle GetCarByID(int id)
        {

            return vehicles.FirstOrDefault(x => x.VehicleID == id);
        }

        public void DeleteCarByID(int ID)
        {
            vehicles.RemoveAll(x => x.VehicleID == ID);
        }
    }
}

