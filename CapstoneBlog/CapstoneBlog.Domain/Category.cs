using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBlog.Domain
{
    public class Category
    {
        public int CatID { get; set; }
        public string category { get; set; }

        public List<Post> Posts { get; set; }
    }
}
