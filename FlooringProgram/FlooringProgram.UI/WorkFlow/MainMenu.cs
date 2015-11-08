using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI.WorkFlow
{
    public class MainMenu
    {
        public void Execute()
        {
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("\t\tFlooring Program\n");
                    Console.WriteLine("1. Display Orders");
                    Console.WriteLine("2. Create an Order");
                    Console.WriteLine("3. Edit an Order");
                    Console.WriteLine("4. Remove an Order");
                    Console.WriteLine("5. Quit\n");
                    Console.WriteLine("***********************************************");

                    Console.WriteLine("\n\nEnter Choice: ");
                    string input = Console.ReadLine();

                    if (input.Length != 1)
                    {
                        Console.WriteLine("---INVALID CHOICE---");
                        Console.WriteLine("Press any key to try again...");
                        Console.ReadKey();
                    }                       

                    ProcessChoice(input);
                } while (true);
            }
        }

        private void ProcessChoice(string choice)
        {
            switch(choice)
            {
                case "1":
                    var Display = new DisplayOrderWorkflow();
                    Display.Execute();
                    break;
                case "2":
                    var CreateOrder = new CreateOrderWorkflow();
                    CreateOrder.Execute();
                    break;
                case "3":
                    var EditOrder = new EditOrderWorkflow();
                    EditOrder.Execute();
                    break;
                case "4":
                    var DeleteOrder = new DeleteOrderWorkflow();
                    DeleteOrder.Execute();
                    break;
                default:
                    break;
            }
        }
    }            

}
