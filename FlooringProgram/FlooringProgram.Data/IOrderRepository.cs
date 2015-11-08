using System.Collections.Generic;
using FlooringProgram.Models;
using System;

namespace FlooringProgram.Data
{
    public interface IOrderRepository
    {
        void CreateOrder(string orderDate , Order order);
        void DeleteOrder(string orderDate , Order order);
        List<Order> GetAllOrders(string orderDate);
        Order LoadOrder(string orderDate, int orderNumber);
        void UpdateOrder(string orderDate , Order orderToUpdate);
        void Logger(Exception ex);
    }
}