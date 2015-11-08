using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.BLL;
using NLog;

namespace FlooringProgram.UI.WorkFlow
{
    public class CreateOrderWorkflow
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void Execute()
        {
            string orderDate = DateTime.Now.ToString("MMddyyyy"); 

            Order order = new Order();

            order.CustomerName = GetCustomerName();
            GetProductType(order);
            GetState(order);
            GetArea(order);

            var manager = new OrderManager();

            ConfirmOrder(orderDate, order);
          
     
        }

        private Order GetArea(Order order)
        {


            do
            {
                Console.Clear();
                Console.WriteLine("What is the area of material?");
                string input = Console.ReadLine();
                decimal area;

                if (decimal.TryParse(input, out area))
                {
                    order.Area = area;
                    return order;
                }

                logger.Error("That was not a valid number!");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
            } while (true);
        }

        private Order GetState(Order order)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("States we operate in:");
                Console.WriteLine("*******************");
                Console.WriteLine("\n1. Ohio");
                Console.WriteLine("2. Pennsylvania");
                Console.WriteLine("3. Michigan");
                Console.WriteLine("4. Indiana");

                Console.WriteLine("\n\nEnter your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        order.StateName = "Ohio";
                        order.StateAbbreviation = "OH";
                        order.TaxRate = 6.25M;
                        return order;
                    case "2":
                        order.StateName = "Pennsylvania";
                        order.StateAbbreviation = "PA";
                        order.TaxRate = 6.75M;
                        return order;
                    case "3":
                        order.StateName = "Michigan";
                        order.StateAbbreviation = "MI";
                        order.TaxRate = 5.75M;
                        return order;
                    case"4":
                        order.StateName = "Indiana";
                        order.StateAbbreviation = "IN";
                        order.TaxRate = 6.00M;
                        return order;
                    default:
                        Console.WriteLine("---INVALID CHOICE---");
                        Console.WriteLine("Please Try again...");
                        Console.ReadLine();
                        break;
                }

            } while (true);
        }

        private string GetCustomerName()
        {
            Console.WriteLine("Enter your first and last name: ");
            string customerName = Console.ReadLine();

            return customerName;
        }

        private Order GetProductType(Order order)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Materials we offer:");
                Console.WriteLine("*******************");
                Console.WriteLine("\n1. Carpet");
                Console.WriteLine("2. Laminate");
                Console.WriteLine("3. Tile");
                Console.WriteLine("4. Wood");

                Console.WriteLine("\n\nEnter your choice: ");
                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        order.ProductType = "Carpet";
                        order.CostPerSquareFoot = 2.25M;
                        order.LaborCostPerSquareFoot = 2.10M;
                        return order;
                    case "2":
                        order.ProductType = "Laminate";
                        order.CostPerSquareFoot = 1.75M;
                        order.LaborCostPerSquareFoot = 2.10M;
                        return order;
                    case "3":
                        order.ProductType = "Tile";
                        order.CostPerSquareFoot = 3.50M;
                        order.LaborCostPerSquareFoot = 4.15M;
                        return order;
                    case "4":
                        order.ProductType = "Wood";
                        order.CostPerSquareFoot = 5.15M;
                        order.LaborCostPerSquareFoot = 4.75M;
                        return order;
                    default:
                        logger.Error("---INVALID CHOICE---");
                        Console.WriteLine("---INVALID CHOICE---");
                        Console.WriteLine("Please Try again...");
                        Console.ReadLine();
                        break;
                }

            } while (true);
        }

        private void ConfirmOrder(string orderDate, Order order)
        {
            Console.Clear();
            Console.WriteLine("Order Information:");
            Console.WriteLine("**************************************");
            Console.WriteLine("Customer Name: {0}", order.CustomerName);
            Console.WriteLine("State: {0}", order.StateAbbreviation);
            Console.WriteLine("Product Type: {0}", order.ProductType);
            Console.WriteLine("Product Area: {0}", order.Area);            
            Console.WriteLine("**************************************");

            do
            {
                Console.WriteLine("Are you sure you want to create this order? (Y/N): ");
                string input = Console.ReadLine();
                string confirmInput = input.ToUpper();
                if (confirmInput != "Y" && confirmInput != "N")
                {
                    logger.Error("---INVAILD CHOICE---");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
                else
                {
                    if (confirmInput == "Y")
                    {
                        var manager = new OrderManager();
                        var response = manager.CreateOrder(orderDate , order);
                        if(response.Success == true)
                        {
                            Console.WriteLine(response.Message);
                            Console.WriteLine("Your Order number is: {0}", response.Data.OrderNumber);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            logger.Error("An error has occured. {0}", response.Message);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;

                    }
                    else
                    {
                        break;
                    }
                }

            } while (true);
        }



    }
}

