using FOS.UI.UI_Elements;
using FOS.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.UI
{
    public class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Headers.MainMenuHeader();
                Console.WriteLine(" 1. Display Orders");
                Console.WriteLine(" 2. Add an Order");
                Console.WriteLine(" 3. Edit an Order");
                Console.WriteLine(" 4. Remove an Order");
                Console.WriteLine("\n Q to Quit");
                Console.WriteLine("\n Enter a selection:");

                string userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        DisplayOrdersWorkflow displayWorkflow = new DisplayOrdersWorkflow();
                        displayWorkflow.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow addWorkflow = new AddOrderWorkflow();
                        addWorkflow.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow editWorkflow = new EditOrderWorkflow();
                        editWorkflow.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeWorkflow = new RemoveOrderWorkflow();
                        removeWorkflow.Execute();
                        break;
                    case "Q":
                        return;
                }
            }
        }
    }
}
