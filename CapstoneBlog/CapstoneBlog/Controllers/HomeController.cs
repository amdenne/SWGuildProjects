using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneBlog.BLL;

namespace CapstoneBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var manager = new BlogManager();
            var data = manager.GetAllApprovedPosts().Data;
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult IndexSearch(string SearchBlog)
        {
            var manager = new BlogManager();
            var b = manager.GetPostsByCategory(SearchBlog).Data;

            return View("Index", b);
        }
    }
}