using CapstoneBlog.BLL;
using CapstoneBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneBlog.Controllers
{
    [Authorize (Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var manager = new BlogManager();
            var response = manager.GetAllApprovedPosts();

            return View(response.Data);
        }
        public ActionResult NewAdminPost()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatePost(Models.HTMLContent x)
        {
            if(ModelState.IsValid)
            {
            var newPost = new Post();
            newPost.Content = x.HtmlContent;
            newPost.Title = x.Title;
            newPost.IsApproved = false;
            newPost.DatePosted = DateTime.Now;
            
            var manager = new BlogManager();
            var response = manager.AddPost(newPost);

            return View("Pending");
            }
            else
            {
                return View("NewAdminPost");
            }

        }
       
        //public ActionResult EditAdminPost()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult EditPost(HTMLContent HTMLContent)
        //{
        //    var manager = new BlogManager();
        //    var response = manager.UpdatePost(HTMLContent);
        //    return RedirectToAction("Index");
        //}

    }
}