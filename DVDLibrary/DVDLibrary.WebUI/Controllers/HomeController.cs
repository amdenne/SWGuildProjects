using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.DLL;
using DVDLibrary.BLL;
using DVDLibrary.Models;
using System.Net;

namespace DVDLibrary.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private DVDRepository db = new DVDRepository();

        public ActionResult Index()
        {
            var manager = new DVDManager();
            var d = manager.LoadAllDVDs().Data;

            return View(d);
        }

        [HttpPost]
        public ActionResult IndexSearch(string SearchDVD)

        {
            var manager = new DVDManager();
            var d = manager.SearchDVD(SearchDVD).Data;

            return View("Index", d);
        }

        public ActionResult DisplayDVD(int id)
        {
            var manager = new DVDManager();
            //var d = db.GetAllDVDs().Find(x => x.dvdID == id);
            var response = manager.GetDVDInfo(id);
            //var dvd = response.Data.FirstOrDefault();

            return View("DisplayDVD", response.Data);
        }

        public ActionResult Delete(int id)
        {
            db.RemoveDVDInfo(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var models = new DVDInfo();
            return View(models);
        }

        [HttpPost]
        public ActionResult CreateDVD(DVDInfo dvd)
        {
            if (ModelState.IsValid)
            {
                var manager = new DVDManager();
                var response = manager.CreateDVD(dvd);

                return View("CreateDVD", response.Data);
            }
            return View("Create");
        }

        [HttpPost]
        public ActionResult CheckOut(DVDInfo id)
        {
            var manager = new DVDManager();

            var response = manager.AddBorrower(id);

            var dvd = manager.GetDVDInfo(id.dvdID);

            return View("CheckOut", response.Data);
        }

        public ActionResult CheckIn(DVDInfo id)
        {
            var manager = new DVDManager();

            var response = manager.ReturnDVD(id);

            return View("CheckIn", response.Data);
        }


    }

    }
