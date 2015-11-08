using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRPortal.Models;
using HRPortal.BLL;
using System.Web.Mvc;
using HRPortal.WebUI.Models;

namespace HRPortal.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var models = new ApplicationViewModel();
            return View(models);
        }
        
        [HttpPost]
        public ActionResult CreateApp(Application application)
        {
            if (ModelState.IsValid)
            { 
                var manager = new ApplicationManager();
                var response = manager.CreateApplication(application);
   
                return View("CreateApp", response.Data);
            }
            return View("Create");
            
        }

        [HttpPost]
        public ActionResult CreateApp2(Application application)
        {
            if (ModelState.IsValid)
            {
                var manager = new ApplicationManager();
                var response = manager.CreateApplication(application);

                return View("CreateApp2", response.Data);
            }
            return View("Create");

        }


        public ActionResult Display()
        {
            var manager = new ApplicationManager();
            var response = manager.LoadAllApplications();
            var applications = response.Data;

            return View("Display", applications);
        }

        [HttpPost]
        public ActionResult Application(int AppID)
        {
            var manager = new ApplicationManager();
            var response = manager.GetApplication(AppID);
            var application = response.Data;

            return View(application);
        }

        public ActionResult ApplyNoMenu()
        {
            var model = new ApplicationViewModel();
            return View(model);
        }

    }
}