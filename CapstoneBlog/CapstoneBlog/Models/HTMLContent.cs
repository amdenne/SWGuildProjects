using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CapstoneBlog.Models
{
    public class HTMLContent
    {
        [AllowHtml]
        [Required(ErrorMessage = "Content can not be empty")]
        public string HtmlContent { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Title must be between 3-30 characters")]
        public string Title { get; set; }

        public HTMLContent()
        {

        }
    }
}