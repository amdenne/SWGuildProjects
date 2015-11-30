using CarDealership.BLL;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class InfoListController : ApiController
    {
        public List<RequestInfo> Get()
        {
            var manager = new VehicleManager();
            return manager.GetAllRequests().Data;
        }

     
    }
}
