using FlooringProgram.BLL;
using FlooringProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Web.Mvc;

namespace FlooringProgram.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayOrder()
        {
            var order = new Order();

            return View(order);
        }

        [HttpPost]
        public ActionResult DisplayOrder(int OrderNumber, string OrderDate)
        {
            var manager = new OrderManager();

            var order = manager.GetOrder(OrderDate, OrderNumber);

            return View("Display", order.Data);
        }

        public ActionResult EditOrder()
        {
            var order = new Order();

            return View(order);
        }

        [HttpPost]
        public ActionResult EditOrder(int OrderNumber, string OrderDate)
        {
            var manager = new OrderManager();

            var order = manager.GetOrder(OrderDate, OrderNumber);

            return View("Edit", order.Data);
        }

        [HttpPost]
        public ActionResult DisplayEditedOrder(string OrderDate,Order order)
        {
            var manager = new OrderManager();

            var response = manager.UpdateOrder(OrderDate, order);

            return View("Display", response.Data);
        }
    }
}