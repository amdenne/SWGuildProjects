using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;
using NLog;

namespace FlooringProgram.UI.WorkFlow
{
    class DisplayOrderWorkflow
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private Order _currentOrder;

        public void Execute()
        {
            string orderDate = GetOrderDateFromUser();
            int orderNumber = GetOrderNumberFromUser();

            DisplayOrderInformation(orderDate, orderNumber);
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
                    logger.Error("The order date was not in a valid format!");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
            } while (true);

        }

        private void DisplayOrderInformation(string orderDate, int orderNumber)
        {
            var manager = new OrderManager();

            var response = manager.GetOrder(orderDate, orderNumber);

            Console.Clear();

            if(response.Success)
            {
                _currentOrder = response.Data;
                PrintOrderDetails(response);
                DisplayOrderInformation();
            }
            else
            {
                logger.Error("A problem occured..");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void PrintOrderDetails(Response<Order> response)
        {
            Console.WriteLine("Order Information:");
            Console.WriteLine("**************************************");
            Console.WriteLine("Order Number:".PadRight(15) + "{0}", response.Data.OrderNumber);
            Console.WriteLine("Customer Name:".PadRight(15) + "{0}", response.Data.CustomerName);
            Console.WriteLine("State:".PadRight(15) +"{0}", response.Data.StateAbbreviation);

            Console.WriteLine("Product Type:".PadRight(15) + "{0}", response.Data.ProductType);
            Console.WriteLine("Product Area:".PadRight(15)+ "{0}\n", response.Data.Area);

            Console.WriteLine("Material Cost:".PadRight(15) + "{0,10:C}", response.Data.MaterialCost);
            Console.WriteLine("Labor Cost:".PadRight(15) + "{0,10:C}\n", response.Data.LaborCost);
            
            Console.WriteLine("Subtotal:".PadRight(15)+ "{0,10:C}", response.Data.MaterialCost + response.Data.LaborCost);
            Console.WriteLine("Taxes:".PadRight(15) + "{0,10:C}\n", response.Data.TotalTax);
            Console.WriteLine("Total Cost:".PadRight(15) + "{0,10:C}", response.Data.Total);
            Console.WriteLine("**************************************");
        }

        private void DisplayOrderInformation()
        {
            do
            {
                Console.WriteLine("\n1. Edit Order");
                Console.WriteLine("2. Main Menu");
                Console.WriteLine("3. Quit");

                Console.WriteLine("\n\nEnter Choice: ");
                string input = Console.ReadLine();

                if (input.Length != 1)
                    break;

                ProcessChoice(input);
            } while (true);
        }

        private void ProcessChoice(string choice)
        {
            switch(choice)
            {
                case "1":
                    var EditOrder = new EditOrderWorkflow();
                    EditOrder.Execute();
                    break;
                case "2":
                    var MainMenu = new MainMenu();
                    MainMenu.Execute();
                    break;
                default:
                    break;
            }
        }

        private int GetOrderNumberFromUser()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Enter your order number: ");
                string input = Console.ReadLine();
                int orderNumber;

                if (int.TryParse(input, out orderNumber))
                    return orderNumber;

                logger.Error("That was not a valid order Number!");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();

            } while (true);
        }
    }
}
