using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBlog.Domain
{
    public class Post
    {
        public int PostID { get; set; }
        public int CatID { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsApproved { get; set; }

        public List<Category> Categories { get; set; }
    }
}
