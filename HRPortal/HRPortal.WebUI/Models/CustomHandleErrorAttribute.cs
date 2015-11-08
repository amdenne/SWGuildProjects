using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPortal.WebUI.Models
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            if (filterContext.Exception != null)
            {
                logger.Error("More Testing");
                logger.Error(filterContext.Exception.Message);
                logger.Error(filterContext.Exception.Message, filterContext.ExceptionHandled);
            }
        }
    }
}
