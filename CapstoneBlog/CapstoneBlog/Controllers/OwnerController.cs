using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapstoneBlog.BLL;
using CapstoneBlog.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CapstoneBlog.Controllers
{
    [Authorize(Roles="Owner")]
    public class OwnerController : Controller
    {
        // GET: Owner
        public ActionResult Index()
        {
            var manager = new BlogManager();
            var data = manager.GetAllApprovedPosts().Data;
            return View(data);
        }

        [HttpPost]
        public ActionResult Approve(Array checkedIds)
        {
            var postID = new List<int>();
            
            foreach (string p in checkedIds)
            {
                postID.Add(int.Parse(p));
            }

            var manager = new BlogManager();
            manager.ApprovePost(postID);

            return RedirectToAction("Index");
        }

        public ActionResult UnapprovedPosts()
        {
            var manager = new BlogManager();
            var data = manager.GetAllUnapprovedPosts().Data;
            return View(data);
        }

        public ActionResult OwnerAddPost()
        {
            return View();
        }

        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult CreatePost(HTMLContent x)
        {
            var newPost = new Domain.Post();
          
            newPost.Content = x.HtmlContent;
            newPost.Title = x.Title;
            newPost.IsApproved = true;
            newPost.DatePosted = DateTime.Now;

            
            if (ModelState.IsValid)
            {
                var manager = new BlogManager();
                var response = manager.AddPost(newPost);

                return RedirectToAction("Index");
            }
            else
            {
                return View("OwnerAddPost");
            }

        }

        [HttpPost]
        public ActionResult OwnerDelete(Array checkedBoxes)
        {
            var postID = new List<int>();
            foreach(string ID in checkedBoxes)
            {
                postID.Add(int.Parse(ID));
        }
            var manager = new BlogManager();
            manager.DeletePost(postID); 

            return RedirectToAction("Index");
        }

        public ActionResult CreateWebpage()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateWebpage(Webpage page)
        {
            var manager = new BlogManager();
            manager.AddWebpage(page);

            

            return RedirectToAction("Index/"+ page.Title, "Static");
        }
    }
}