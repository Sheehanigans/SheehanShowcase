using FOS.BLL;
using FOS.BLL.DataVaidations;
using FOS.BLL.DataValidations;
using FOS.MODELS;
using FOS.MODELS.Models;
using FOS.MODELS.Responses;
using FOS.UI.UI_Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            string workflow = "Add";

            OrderManager orderManager = OrderManagerFactory.Create();

            Headers.DisplayHeader(workflow);

            //create order object
            Order newOrder = new Order();

            //get date
            newOrder.Date = ConsoleIO.GetNewOrderDate("Enter a date (MM/DD/YYYY):");

            //get order number 
            newOrder.OrderNumber = OrderNumberValidation.CreateOrderNumber(newOrder.Date);

            Headers.DisplayHeader(workflow);

            //get customer name
            newOrder.CustomerName = ConsoleIO.GetCustomerName("Add","none");

            Headers.DisplayHeader(workflow);

            //get state tax
            bool validState = false;
            StateTax stateTax = null;
            while (!validState)
            {
                string stateAbbratiavtion = ConsoleIO.GetStateInputFromUser("Add");
                StateTax tempStateTax = StateTaxValidation.CreateStateTax(stateAbbratiavtion).State;
                if(tempStateTax == null)
                {
                    validState = false;
                }
                else
                {
                    stateTax = tempStateTax;
                    validState = true;
                }
            }

            Headers.DisplayHeader(workflow);

            //set state
            newOrder.State = stateTax.StateAbbreviation;
            newOrder.TaxRate = stateTax.TaxRate;

            //get product
            List<Product> products = ProductListValidation.CreateProductList();
            Product product = ConsoleIO.DisplayProducts(products, "Add");
            newOrder.ProductType = product.ProductType;
            newOrder.CostPerSquareFoot = product.CostPerSquareFoot;
            newOrder.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;

            Headers.DisplayHeader(workflow);

            //get area
            newOrder.Area = ConsoleIO.GetArea("Add");

            Headers.DisplayHeader(workflow);

            //display new order
            ShowDetails.DisplayOrderDetails(newOrder);

            //--show message if add failed--
            if (ConsoleIO.GetYesOrNo("Add order? ") == "Y")
            {
                OrderAddResponse response = orderManager.AddOrder(newOrder);
                if (!response.Success)
                {
                    Console.WriteLine("There was an error adding the order:");
                    Console.WriteLine(response.Message);
                }
                else
                {
                    Console.WriteLine("Order added! Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Order cancelled :(");
                Console.ReadLine();
            }
        }
    }
}
