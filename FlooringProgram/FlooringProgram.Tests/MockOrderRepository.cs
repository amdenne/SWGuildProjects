using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlooringProgram.Data;
using FlooringProgram.Models;
using System.Threading.Tasks;
using NLog;

namespace FlooringProgram.Tests
{
    public class MockOrderRepository : IOrderRepository
    {
        private List<Order> _orders = new List<Order>();

        public MockOrderRepository()
        {
            _orders.Add(new Order()
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

            _orders.Add(new Order()
            {
                OrderNumber = 2,
                CustomerName = "Ricardo Brady",
                StateAbbreviation = "IN",
                TaxRate = 6.00M,
                ProductType = "Carpet",
                Area = 100.00M,
                CostPerSquareFoot = 2.25M,
                LaborCostPerSquareFoot = 2.10M,
                MaterialCost = 225.00M,
                LaborCost = 210.00M,
                TotalTax = 26.10M,
                Total = 461.10M
            });

            _orders.Add(new Order()
            {
                OrderNumber = 3,
                CustomerName = "Eduardo Ward Jr.",
                StateAbbreviation = "MI",
                TaxRate = 5.75M,
                ProductType = "Laminate",
                Area = 100.00M,
                CostPerSquareFoot = 1.75M,
                LaborCostPerSquareFoot = 2.10M,
                MaterialCost = 175.00M,
                LaborCost = 210.00M,
                TotalTax = 22.1375M,
                Total = 407.1375M
            });

            _orders.Add(new Order()
            {
                OrderNumber = 4,
                CustomerName = "Ronald Mc Macintyre Sr.",
                StateAbbreviation = "PA",
                TaxRate = 6.75M,
                ProductType = "Tile",
                Area = 100.00M,
                CostPerSquareFoot = 3.50M,
                LaborCostPerSquareFoot = 4.15M,
                MaterialCost = 350.00M,
                LaborCost = 415.00M,
                TotalTax = 51.6375M,
                Total = 816.6375M
            });

        }

        public void CreateOrder(string orderDate, Order order)
        { 
                var orders = GetAllOrders(orderDate);
                orders.Add(order);
        }

        public void DeleteOrder(string orderDate, Order order)
        {
            var orders = GetAllOrders(orderDate);
            orders.RemoveAll(a => order.OrderNumber == a.OrderNumber);
        }

        public List<Order> GetAllOrders(string orderDate)
        {
            return _orders;
        }

        public Order LoadOrder(string orderDate, int orderNumber)
        {
            List<Order> orders = GetAllOrders(orderDate);
            return _orders.FirstOrDefault(a => a.OrderNumber == orderNumber);
        }

        public void Logger(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(string orderDate, Order orderToUpdate)
        {
            var orders = GetAllOrders(orderDate);

            var existingOrder = orders.FirstOrDefault(a => a.OrderNumber == orderToUpdate.OrderNumber);
            existingOrder.CustomerName = orderToUpdate.CustomerName;
            existingOrder.StateAbbreviation = orderToUpdate.StateAbbreviation;
            existingOrder.TaxRate = orderToUpdate.TaxRate;
            existingOrder.ProductType = orderToUpdate.ProductType;
            existingOrder.Area = orderToUpdate.Area;
            existingOrder.CostPerSquareFoot = orderToUpdate.CostPerSquareFoot;
            existingOrder.LaborCostPerSquareFoot = orderToUpdate.LaborCostPerSquareFoot;
            existingOrder.MaterialCost = orderToUpdate.MaterialCost;
            existingOrder.LaborCost = orderToUpdate.LaborCost;
            existingOrder.TotalTax = orderToUpdate.Total;
            existingOrder.Total = orderToUpdate.Total;
        }

    }
}

