using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringProgram.Models;
using FlooringProgram.BLL;
using FlooringProgram.Data;
using NLog;
using Moq;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace FlooringProgram.Tests
{
    [TestFixture]
    public class OrderManagerTests
    {
        [Test]
        public void FoundOrderReturnedSuccess()
        {
            var manager = new OrderManager(new MockOrderRepository());
            var response = manager.GetOrder("06012013", 1);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Data.OrderNumber);
            Assert.AreEqual("Billy Henderson", response.Data.CustomerName);
        }

        [Test]
        public void NotFoundOrder()
        {
            var manager = new OrderManager(new MockOrderRepository());
            var response = manager.GetOrder("06012013", 26);

            Assert.IsFalse(response.Success);
        }

        [Test]
        public void EditOrderSuccess()
        {
            var manager = new OrderManager(new MockOrderRepository());

            var orderToUpdate = manager.GetOrder("06012013", 1);

            orderToUpdate.Data.CustomerName = "George Henderson";
            orderToUpdate.Data.StateAbbreviation = "OH";
            orderToUpdate.Data.TaxRate = 6.25M;
            orderToUpdate.Data.ProductType = "Wood";
            orderToUpdate.Data.Area = 100.00M;
            orderToUpdate.Data.CostPerSquareFoot = 5.15M;
            orderToUpdate.Data.LaborCostPerSquareFoot = 4.75M;
            orderToUpdate.Data.MaterialCost = 515.00M;
            orderToUpdate.Data.LaborCost = 475.00M;
            orderToUpdate.Data.TotalTax = 61.88M;
            orderToUpdate.Data.Total = 1051.88M;

            var response = manager.UpdateOrder("06012013", orderToUpdate.Data);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(orderToUpdate.Data.CustomerName, "George Henderson");

        }

        [Test]
        public void CreateOrderTest()
        {
            var manager = new OrderManager(new MockOrderRepository());
            Order order = new Order();

            order.OrderNumber = 5;
            order.CustomerName = "George Henderson";
            order.StateAbbreviation = "OH";
            order.TaxRate = 6.25M;
            order.ProductType = "Wood";
            order.Area = 100.00M;
            order.CostPerSquareFoot = 5.15M;
            order.LaborCostPerSquareFoot = 4.75M;
            order.MaterialCost = 515.00M;
            order.LaborCost = 475.00M;
            order.TotalTax = 61.88M;
            order.Total = 1051.88M;

            var response = manager.CreateOrder("06012013", order);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(5, order.OrderNumber);

        }

        [Test]
        public void DeleteOrderTest()
        {
            var manager = new OrderManager(new MockOrderRepository());
            var deleteOrderResponse = manager.GetOrder("06012013", 2);
            var orderToDelete = deleteOrderResponse.Data;

            var response = manager.DeleteOrder("06012013", orderToDelete);

            Assert.IsTrue(response.Success);
            Assert.IsNull(response.Data);

        }

        [Test]
        public void LoadOrderMoqTest()
        {
            Mock<IOrderRepository> mockRepository = new Mock<IOrderRepository>();

            mockRepository.Setup(x => x.LoadOrder(It.IsAny<string>(), It.IsAny<int>())).Returns(new Order()
            {
                OrderNumber = 5,
                CustomerName = "George Henderson",
                StateAbbreviation = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475.00M,
                TotalTax = 61.88M,
                Total = 1051.88M
            });

            Assert.AreEqual(5, mockRepository.Object.LoadOrder(It.IsAny<string>(), It.IsAny<int>()).OrderNumber);
            Assert.AreEqual("George Henderson", mockRepository.Object.LoadOrder(It.IsAny<string>(), It.IsAny<int>()).CustomerName);
            Assert.AreEqual("OH", mockRepository.Object.LoadOrder(It.IsAny<string>(), It.IsAny<int>()).StateAbbreviation);
            Assert.AreEqual("Wood", mockRepository.Object.LoadOrder(It.IsAny<string>(), It.IsAny<int>()).ProductType);
            Assert.AreEqual(100.00M, mockRepository.Object.LoadOrder(It.IsAny<string>(), It.IsAny<int>()).Area);
        }

        [Test]
        public void LoadJsonData()
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order()
            {
                OrderNumber = 1,
                CustomerName = "Billy Henderson",
                StateAbbreviation = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475.00M,
                TotalTax = 61.88M,
                Total = 1051.88M
            });

            string FilePath = ConfigurationManager.AppSettings["FileMode"];
            string orderDate = "06012013";

            File.Delete(FilePath + orderDate + ".json");

            File.WriteAllText(FilePath + orderDate + ".json", JsonConvert.SerializeObject(orders));

            using (StreamWriter file = File.CreateText(FilePath + orderDate + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, orders);
            }


        }
    }
}   

