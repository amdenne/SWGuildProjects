using System;
using System.Collections.Generic;
using System.Linq;
using HRPortal.Models;
using System.Web;
using System.Web.Mvc;

namespace HRPortal.WebUI.Models
{
    public class PolicyViewModel : Policy
    {
        private SelectList _listOfCategories;

        public PolicyViewModel()
        {
            _listOfCategories = new SelectList(new List<SelectListItem>{
            new SelectListItem() { Text = "Diversity", Value = "Diversity" },
            new SelectListItem() { Text = "Hiring", Value = "Hiring" },
            new SelectListItem() { Text = "Benefits", Value = "Benefits" } }, "Value", "Text"
            );
        }

        public SelectList ListOfCategories
        {
            get
            {
                return _listOfCategories;
            }
        }
    };
}
