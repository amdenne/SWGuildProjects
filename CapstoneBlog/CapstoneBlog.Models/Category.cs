using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBlog.Models
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }
        public string category { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
