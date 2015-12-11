using CapstoneBlog.BLL;
using CapstoneBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneBlog.Controllers
{
    public class StaticController : Controller
    {
        // GET: Static
        public ActionResult Index(string Title)
        {
            var manager = new BlogManager();
            var page = manager.GetWebpageByTitle(Title).Data;

            return View(page);
        }


    }
}