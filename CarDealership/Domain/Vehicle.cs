using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string AdTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureURL { get; set; }
        public bool IsAvailable { get; set; }

    }
}
