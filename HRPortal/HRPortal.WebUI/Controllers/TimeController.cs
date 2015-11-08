using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.BLL;
using HRPortal.Models;
using HRPortal.WebUI.Models;

namespace HRPortal.WebUI.Controllers
{
    public class TimeController : Controller
    {
        // GET: Time
        //public ActionResult Index()
        //{
        //    return View();
        //}

        
        public ActionResult Submit()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SubmitTime(Time time)
        {            
            if (ModelState.IsValid)
            {
                var manager = new TimeManager();
                var response = manager.CreateTime(time);
                return RedirectToAction("TimeSheet");
            }
            return View("Submit");
        }

        public ActionResult TimeSheet()
        {
            var manager = new TimeManager();
            var response = manager.LoadAllTimes();

            return View(response.Data);
        }
   
        public ActionResult Summary(Time time)
        {
            var manager = new TimeManager();
            var response = manager.GetTimes(time.EmpID);
          

            return View("Summary", response.Data);
        }
    }
}