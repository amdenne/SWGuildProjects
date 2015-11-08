using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using FlooringProgram.Models;
using System.IO;


namespace FlooringProgram.Data
{
    public class JsonRepository : IOrderRepository
    {
        private string FilePath = ConfigurationManager.AppSettings["FileMode"];

        public List<Order> GetAllOrders(string orderDate)
        {
            List<Order> orders = new List<Order>();
            
            string json = File.ReadAllText(FilePath + orderDate + ".json");
            List<Order> data = JsonConvert.DeserializeObject<List<Order>>(json);

            return data;
        }

        public Order LoadOrder(string orderDate, int orderNumber)
        {
            List<Order> orders = GetAllOrders(orderDate);
            return orders.FirstOrDefault(a => a.OrderNumber == orderNumber);
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

            OverwriteFile(orderDate, orders);
        }

        private void OverwriteFile(string orderDate, List<Order> orders)
        {
            if (File.Exists(FilePath + orderDate + ".json"))
                File.Delete(FilePath + orderDate + ".json");

            foreach (var order in orders)
            {
                File.WriteAllText(FilePath + orderDate + ".json", JsonConvert.SerializeObject(orders));
            }            
        }

        private void WriteFile(string orderDate, Order order)
        {
            File.WriteAllText(FilePath + orderDate + ".json", JsonConvert.SerializeObject(order));
        }

        public void CreateOrder(string orderDate, Order order)
        {          
                var orders = GetAllOrders(orderDate);
                orders.Add(order);

                OverwriteFile(orderDate, orders);         
        }

        public void DeleteOrder(string orderDate, Order order)
        {
            var orders = GetAllOrders(orderDate);
            orders.RemoveAll(a => order.OrderNumber == a.OrderNumber);

            OverwriteFile(orderDate, orders);
        }

        public void Logger(Exception ex)
        {
            using (var writer = File.CreateText(@"DataFiles\Log.txt"))
            {
                writer.WriteLine("{0}", DateTime.Now.ToString("MM/dd/yyyy"));
                writer.WriteLine("{0}", ex.ToString());
            }
        }

    }
}
