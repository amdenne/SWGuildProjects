using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlooringProgram.BLL;
using FlooringProgram.Models;
using System.Threading.Tasks;
using NLog;

namespace FlooringProgram.UI.WorkFlow
{
    public class DeleteOrderWorkflow
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void Execute()
        {
            string orderDate = GetOrderDateFromUser();
            int orderNumber = GetOrderNumberFromUser();

            var manager = new OrderManager();
            var orderGetter = manager.GetOrder(orderDate , orderNumber);
            var order = orderGetter.Data;

            var response = manager.DeleteOrder(orderDate, order);

            if (response.Success)
            {
                Console.Clear();
                Console.WriteLine("Successfully removed your account!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                logger.Error("An error occured. {0}", response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private string GetOrderDateFromUser()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("What is the date your order was placed? (MMDDYYYY)");
                string orderDate = Console.ReadLine();

                if (orderDate.Length == 8)                
                        return orderDate;
                else
                {
                    Console.WriteLine("The order date was not in a valid format!");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
            } while (true);
        }

        private int GetOrderNumberFromUser()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Enter an order number to delete.");

                string input = Console.ReadLine();
                int orderNumber;

                if (int.TryParse(input, out orderNumber))
                    return orderNumber;

                Console.WriteLine("That was not a valid order number!");
                Console.ReadKey();
            } while (true);
        }
    }
}
