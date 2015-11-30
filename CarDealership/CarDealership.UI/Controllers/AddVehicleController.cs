using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Models;
using CarDealership.BLL;

namespace CarDealership.UI.Controllers
{
    public class AddVehicleController : Controller
    {
        public ActionResult AddVehicle( )
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCar(Vehicle car)
        {
            var manager = new VehicleManager();
            var response = manager.AddCar(car);

            return View("Home");
        }
    }
}