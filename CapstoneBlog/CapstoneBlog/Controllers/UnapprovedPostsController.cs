using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapstoneBlog.Domain;
using CapstoneBlog.BLL;

namespace CapstoneBlog.Controllers
{
    public class UnapprovedPostsController : ApiController
    {
        public List<Post> Get()
        {
            var manager = new BlogManager();
            var data = manager.GetAllUnapprovedPosts().Data;
            return data;
        }
    }
}
