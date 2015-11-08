using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Data;

namespace FlooringProgram.BLL
{
    public class OrderManager
    {
        private IOrderRepository _repo;

        public OrderManager()
        {
            _repo = new OrderRepository();
        }

        public OrderManager(IOrderRepository repo)
        {
            _repo = repo;
        }

        public Response<Order> GetOrder(string orderDate, int orderNumber)
        {
            var response = new Response<Order>();

            var order = _repo.LoadOrder(orderDate, orderNumber);

            try
            {
                if (order == null)
                {
                    response.Success = false;
                    response.Message = "Order was not found.";
                }
                else
                {
                    response.Success = true;
                    response.Message = "order found.";
                    response.Data = order;
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = "There was an error. Pleas try again later...";
                _repo.Logger(ex);
            }
            return response;

        }

        public Response<Order> CreateOrder(string orderDate , Order order)
        {
            var response = new Response<Order>();

            try
            {
                var orders = _repo.GetAllOrders(orderDate);

                if (orders.Count() != 0)
                {
                    int LatestOrderNumber = orders.Select(a => a.OrderNumber).Last();
                    order.OrderNumber = LatestOrderNumber + 1;
                }
                else
                {
                    order.OrderNumber = 1;
                }

                response.Data = new Order();
                response.Data.OrderNumber = order.OrderNumber;
                response.Data.CustomerName = order.CustomerName;
                response.Data.Area = order.Area;
                order.LaborCost = LaborCostCalculator(order);
                order.MaterialCost = MaterialCostCalculator(order);
                order.SubTotal = SubtotalCalculator(order);
                order.TotalTax = TaxCalculator(order);
                order.Total = TotalCalculator(order);

                _repo.CreateOrder(orderDate , order);
                response.Success = true;
                response.Message = "Your order has been placed.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                _repo.Logger(ex);
            }
            return response;
        }

        private decimal TotalCalculator(Order order)
        {
            return order.TotalTax + order.SubTotal;
        }

        private decimal TaxCalculator(Order order)
        {
            return (order.TaxRate / 100) * order.SubTotal;
        }

        private decimal SubtotalCalculator(Order order)
        {
            return order.LaborCost + order.MaterialCost; 
        }

        private decimal MaterialCostCalculator(Order order)
        {
            return order.CostPerSquareFoot * order.Area;
        }

        private decimal LaborCostCalculator(Order order)
        {
            return order.LaborCostPerSquareFoot * order.Area;
        }

        public Response<Order> UpdateOrder(string orderDate , Order order)
        {
            var response = new Response<Order>();

            try
            {
                 _repo.UpdateOrder(orderDate , order);

                response.Success = true;
                response.Message = "Successfully updated your account!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                _repo.Logger(ex);
            }
            return response;
        }

        public Response<Order> DeleteOrder(string orderDate, Order order)
        {
            var response = new Response<Order>();

            try
            {
                _repo.DeleteOrder(orderDate , order);

                response.Success = true;
                response.Message = "Successfully removed order.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                _repo.Logger(ex);
            }
            return response;
        }
    }
}
