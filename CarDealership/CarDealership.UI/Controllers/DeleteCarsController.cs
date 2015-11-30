using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Data;
using CarDealership.BLL;

namespace CarDealership.UI.Controllers
{
    public class DeleteCarsController : Controller
    {

        [HttpPost]
        public ActionResult Delete(int VehicleID)
        {
            var manager = new VehicleManager();
            manager.DeleteCarByID(VehicleID);

            return Json(new { route = "/Home/Index" });
        }
    
    }
}