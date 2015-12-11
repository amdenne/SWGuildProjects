using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBlog.Models
{
    public class Webpage
    {
        [Key]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
