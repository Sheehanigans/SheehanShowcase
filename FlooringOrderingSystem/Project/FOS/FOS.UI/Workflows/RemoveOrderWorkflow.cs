using FOS.BLL;
using FOS.MODELS.Responses;
using FOS.UI.UI_Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.UI.Workflows
{
    public class RemoveOrderWorkflow
    {

        public void Execute()
        {
            string workflow = "Remove";

            OrderManager orderManager = OrderManagerFactory.Create();
            
            Headers.DisplayHeader(workflow);

            //get date
            DateTime date = ConsoleIO.GetExistingOrderDate("Enter the date of the order you would like to remove (MM/DD/YYYY): ");

            Headers.DisplayHeader(workflow);

            //get order number
            int orderNumber = ConsoleIO.GetOrderNumberFromUser("Enter the order number: ");

            OrderGetSingleResponse getOrderResponse = orderManager.GetSingleOrder(date, orderNumber);
            if (getOrderResponse.Success)
            {
                Headers.DisplayHeader(workflow);
                ShowDetails.DisplayOrderDetails(getOrderResponse.Order);

                if (ConsoleIO.GetYesOrNo("Would you like to remove this order?") == "Y")
                {
                    OrderRemoveResponse removeOrderResponse = orderManager.RemoveOrder(getOrderResponse.Order);
                    if (!removeOrderResponse.Success)
                    {
                        Console.WriteLine("There was an error removing the order.");
                        Console.WriteLine(removeOrderResponse.Message);
                    }
                    else
                    {
                        Console.WriteLine("Order removed! Press any key to return to main menu...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Remove cancelled. Press any key to return to Main Menu...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("An error occured:");
                Console.WriteLine(getOrderResponse.Message);
                Console.WriteLine("Press any key to return to main menu...");
                Console.ReadKey();
                return;
            }
        }
    }
}
