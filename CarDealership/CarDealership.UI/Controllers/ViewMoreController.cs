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
    public class ViewMoreController : ApiController
    {
        public Vehicle Get(int id)
        {
            var manager = new VehicleManager();
            var data = manager.GetCarByID(id).Data;
            return data;
        } 
    }
}
