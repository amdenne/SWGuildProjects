using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRPortal.BLL;
using HRPortal.Models;
using System.Web.Mvc;

namespace HRPortal.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(string category)
        {
            var policy = new Policy();
            policy.Category = category;

            var manager = new PolicyManager();
            var response = manager.LoadAllPolicies(policy);

            
            return View(response.Data);
        }

        [HttpPost]
        public ActionResult PolicyView(Policy policy)
        {
            var manager = new PolicyManager();
            var response = manager.GetPolicy(policy);
            
            return View(response.Data);
        }

        public ActionResult Description(Policy policy)
        {
            var manager = new PolicyManager();
            var response = manager.GetPolicy(policy);

            return View(response.Data);
        }
    }
}