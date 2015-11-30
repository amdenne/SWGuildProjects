using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Models;
using CarDealership.BLL;

namespace CarDealership.UI.Controllers
{
    public class RequestInfoController : Controller
    {
        public ActionResult RequestInfo()
        {
            return View();
        }

        // GET: RequestInfo
        [HttpPost]
        public ActionResult Index(RequestInfo info)
        {
            var manager = new VehicleManager();
            var response = manager.AddRequest(info);

            return View("RequestInfo");
        }

        //[HttpPost]
        //public ActionResult RequestConfirm(RequestInfo request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var manager = new VehicleManager();
        //        var response = manager.AddRequest(request);

        //        return View();
        //    }
        //    return View("RequestInfo");
        //}
    }
}