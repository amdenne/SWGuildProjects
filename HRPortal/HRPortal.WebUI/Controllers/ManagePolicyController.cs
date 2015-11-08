using HRPortal.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using HRPortal.Models;
using System.Web;
using HRPortal.BLL;
using System.Web.Mvc;

namespace HRPortal.WebUI.Controllers
{
    public class ManagePolicyController : Controller
    {
        // GET: ManagePolicy
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var models = new PolicyViewModel();
            return View(models);
        }

        [HttpPost]
        public ActionResult CreatePolicy(Policy policy)
        {
            var manager = new PolicyManager();
            var response = manager.CreatePolicy(policy);
            
            return View("CreatePolicy", response.Data);
        }

        public ActionResult Display(string category)
        {
            var policy = new Policy();
            policy.Category = category;

            var manager = new PolicyManager();
            var response = manager.LoadAllPolicies(policy);

            var policies = response.Data;

            return View(policies);
        }

        [HttpPost]
        public ActionResult DeletePolicy(Policy policy)
        {
            var manager = new PolicyManager();
            var response = manager.DeletePolicy(policy);

            return View("DeletePolicy", response.Data);
        }

    }
}
