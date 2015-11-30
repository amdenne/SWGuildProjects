using CarDealership.BLL;
using CarDealership.Models;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult ShowUserInformation()
        {
            //FIXED THIS CODE, NEEDED "new ApplicationDbContext()" IN THE CONSTRUCTOR
            //SLIDE WAS WRONG :-/
            var userStore = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var id = User.Identity.GetUserId();
            var user = userStore.FindById(User.Identity.GetUserId());

            return View(user);
        }
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult AdminIndex()
        {
            var manager = new VehicleManager();
            var cars = manager.GetAllCars().Data;

            return View("_CarList", cars);
        }

        public ActionResult ViewPartial(Vehicle data)
        {
            return View("_ViewMore", data);
        }

        public ActionResult CarList()
        {
            var manager = new VehicleManager();
            var cars = manager.GetAllCars().Data;

            return View("_userCarList", cars);
        }

        public ActionResult InfoList()
        {
            var manager = new VehicleManager();
            var infos = manager.GetAllRequests().Data;

            return View("_RequestInfoList", infos);

        }

        [HttpPost]
        public ActionResult ChangeStatus(int sID, int rID)
        {
       
            var manager = new VehicleManager();
            manager.UpdateRequestStatus(sID, rID);
            var status = manager.GetAllRequests().Data;

            return View("_RequestInfoList", status);
        }
    }
}