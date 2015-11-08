using FlooringProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace FlooringProgram.Data
{
    public class OrderRepository : IOrderRepository
    {
        private string FilePath = ConfigurationManager.AppSettings["FileMode"];

        public List<Order> GetAllOrders(string orderDate)
        {
            List<Order> orders = new List<Order>();

            if (File.Exists(FilePath + orderDate + ".txt"))
            {
                var reader = File.ReadAllLines(FilePath + orderDate + ".txt");

                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split(',');

                    var order = new Order();

                    order.OrderNumber = int.Parse(columns[0]);
                    order.CustomerName = columns[1];
                    order.StateAbbreviation = columns[2];
                    order.TaxRate = decimal.Parse(columns[3]);
                    order.ProductType = columns[4];
                    order.Area = decimal.Parse(columns[5]);
                    order.CostPerSquareFoot = decimal.Parse(columns[6]);
                    order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                    order.MaterialCost = decimal.Parse(columns[8]);
                    order.LaborCost = decimal.Parse(columns[9]);
                    order.TotalTax = decimal.Parse(columns[10]);
                    order.Total = decimal.Parse(columns[11]);

                    orders.Add(order);
                }
            }
                return orders;
        }

        public Order LoadOrder(string orderDate , int orderNumber)
        {
            List<Order> orders = GetAllOrders(orderDate);
            return orders.FirstOrDefault(a => a.OrderNumber == orderNumber);
        }

        public void UpdateOrder(string orderDate , Order orderToUpdate)
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

        private void OverwriteFile(string orderDate , List<Order> orders)
        {
            File.Delete(FilePath + orderDate + ".txt");

            using (var writer = File.CreateText(FilePath + orderDate + ".txt"))
            {
                writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,"+
                    "LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach(var order in orders)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                        order.OrderNumber,
                        order.CustomerName,
                        order.StateAbbreviation,
                        order.TaxRate,
                        order.ProductType,
                        order.Area,
                        order.CostPerSquareFoot,
                        order.LaborCostPerSquareFoot,
                        order.MaterialCost,
                        order.LaborCost,
                        order.TotalTax,
                        order.Total);
                }
            }
        }

        private void WriteFile(string orderDate, Order order)
        {
            using (var writer = File.CreateText(FilePath + orderDate + ".txt"))
            {
                writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot," +
                    "LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                
                writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                        order.OrderNumber,
                        order.CustomerName,
                        order.StateAbbreviation,
                        order.TaxRate,
                        order.ProductType,
                        order.Area,
                        order.CostPerSquareFoot,
                        order.LaborCostPerSquareFoot,
                        order.MaterialCost,
                        order.LaborCost,
                        order.TotalTax,
                        order.Total);
                }
            }

        public void Logger(Exception ex)
        {
            using (var writer = File.CreateText(@"DataFiles\Log.txt"))
            {
                writer.WriteLine("{0}", DateTime.Now.ToString("MM/dd/yyyy"));
                writer.WriteLine("{0}", ex.ToString());
            }
        }

        public void CreateOrder(string orderDate, Order order)
        {
            if (File.Exists(FilePath + orderDate + ".txt"))
            {
                var orders = GetAllOrders(orderDate);
                orders.Add(order);

                OverwriteFile(orderDate, orders);
            }
            else
            {
                WriteFile(orderDate, order);
            }


        }

        public void DeleteOrder(string orderDate, Order order)
        {
            var orders = GetAllOrders(orderDate);
            orders.RemoveAll(a => order.OrderNumber == a.OrderNumber);

            OverwriteFile(orderDate, orders);
        }


    }
}