using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapstoneBlog.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public int CatID { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public DateTime DatePosted { get; set; }
        public bool IsApproved { get; set; }
        
        public virtual List<Category> Categories { get; set; }

        //public Category Category { get; set; }

    }
}
