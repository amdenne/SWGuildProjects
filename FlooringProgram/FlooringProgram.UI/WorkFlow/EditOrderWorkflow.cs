using FlooringProgram.Models;
using System;
using FlooringProgram.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace FlooringProgram.UI.WorkFlow
{
    public class EditOrderWorkflow
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private Order _currentOrder;

        public void Execute()
        {
            string orderDate = GetOrderDateFromUser();
            int orderNumber = GetOrderNumberFromUser();
            var manager = new OrderManager();
            var response = manager.GetOrder(orderDate , orderNumber);
            var order = response.Data;

            if (response.Success)
            {
                _currentOrder = response.Data;
                EditCustomerName(order);
                EditProductType(order);
                EditState(order);
                EditArea(order);
                ConfirmOrder(orderDate, order);
            }
            else
            {
                logger.Error("A problem occured..");
                Console.WriteLine(response.Message);
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
                    logger.Error("The order date was not in a valid format!");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
            } while (true);
        }

        private string EditCustomerName(Order order)
        {
            Console.WriteLine("Enter your first and last name: {0}", _currentOrder.CustomerName);
            string customerName = Console.ReadLine();

            if (customerName == "")
                order.CustomerName = _currentOrder.CustomerName;
            else
            {
                order.CustomerName = customerName;
                return order.CustomerName;
            }

            return order.CustomerName;
        }

        private Order EditProductType(Order order)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Materials we offer:");
                Console.WriteLine("Previous choice: {0}", _currentOrder.ProductType);
                Console.WriteLine("*******************");
                Console.WriteLine("\n1. Carpet");
                Console.WriteLine("2. Laminate");
                Console.WriteLine("3. Tile");
                Console.WriteLine("4. Wood");

                Console.WriteLine("\n\nEnter your choice: ");
                string input = Console.ReadLine();

                if(input == "")
                {
                    order.ProductType = _currentOrder.ProductType;
                    order.CostPerSquareFoot = _currentOrder.CostPerSquareFoot;
                    order.LaborCostPerSquareFoot = _currentOrder.LaborCostPerSquareFoot;
                    return order;
                }
                else
                {
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
                            Console.WriteLine("---INVALID CHOICE---");
                            Console.WriteLine("Please Try again...");
                            Console.ReadLine();
                            break;
                    }
                }

            } while (true);
        }

        private Order EditState(Order order)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("States we operate in:");
                Console.WriteLine("Previous choice: {0}", _currentOrder.StateAbbreviation);
                Console.WriteLine("*******************");
                Console.WriteLine("\n1. Ohio");
                Console.WriteLine("2. Pennsylvania");
                Console.WriteLine("3. Michigan");
                Console.WriteLine("4. Indiana");

                Console.WriteLine("\n\nEnter your choice: ");
                string input = Console.ReadLine();

                if(input == "")
                {
                    order.StateName = _currentOrder.StateName;
                    order.StateAbbreviation = _currentOrder.StateAbbreviation;
                    order.TaxRate = _currentOrder.TaxRate;

                    return order;
                }
                else
                {
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
                        case "4":
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
                }

            } while (true);
        }

        private Order EditArea(Order order)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("What is the area of material? {0}", _currentOrder.Area);
                string input = Console.ReadLine();
                decimal area;

                if (input == "")
                {
                    order.Area = _currentOrder.Area;
                    return order;
                }
                else
                {
                    if (decimal.TryParse(input, out area))
                    {
                        order.Area = area;
                        return order;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid number!");
                        Console.WriteLine("Press any key to try again...");
                        Console.ReadKey();
                    }
                }
            } while (true);
        }

        private void ConfirmOrder(string orderDate , Order order)
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
                Console.WriteLine("Are you sure you want to update this order? (Y/N): ");
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
                        var response = manager.UpdateOrder(orderDate, order);
                        if (response.Success == true)
                        {
                            Console.Clear();
                            Console.WriteLine(response.Message);
           
                            Console.WriteLine("Press any key to contnue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            logger.Error("An error has occured. {0}", response.Message);
                            Console.WriteLine("Press any key to contnue...");
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
