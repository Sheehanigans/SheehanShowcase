using FOS.BLL;
using FOS.BLL.Factories;
using FOS.BLL.Managers;
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
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            string workflow = "Edit";

            OrderManager orderManager = OrderManagerFactory.Create();
            StateTaxManager stateTaxManager = StateTaxManagerFactory.Create();
            ProductManager productManager = ProductManagerFactory.Create();

            Headers.DisplayHeader(workflow);

            //get date
            DateTime date = ConsoleIO.GetExistingOrderDate("Enter the date of the order you would like to edit (MM/DD/YYYY): ");

            Headers.DisplayHeader(workflow);

            //get order number
            int orderNumber = ConsoleIO.GetOrderNumberFromUser("Enter the order number: ");

            OrderGetSingleResponse orderResponse = orderManager.GetSingleOrder(date, orderNumber);
            if (orderResponse.Success)
            {
                Headers.DisplayHeader(workflow);
                ShowDetails.DisplayOrderDetails(orderResponse.Order);
                Console.WriteLine("Press any key to begin editing...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("An error occured:");
                Console.WriteLine(orderResponse.Message);
                Console.WriteLine("Press any key to return to main menu...");
                Console.ReadKey();
                return;
            }

            Headers.DisplayHeader(workflow);


            //edit name
            string editName = ConsoleIO.GetCustomerName("Edit", orderResponse.Order.CustomerName);

            Headers.DisplayHeader(workflow);

            //edit state
            bool validInput = false;
            StateTax editStateTax = null;
            while (!validInput)
            {
                string editState = ConsoleIO.GetStateInputFromUser("Edit");
                if (editState == "")
                {
                    validInput = true;
                }
                else
                {
                    StateTaxResponse stateTaxResponse = stateTaxManager.GetStateTax(editState);
                    if (stateTaxResponse.Success == true)
                    {
                        editStateTax = stateTaxResponse.State;
                        validInput = true;
                    }
                }
            }

            Headers.DisplayHeader(workflow);


            //edit product type
            List<Product> products = productManager.GetProductList().Products;
            Product editProduct = ConsoleIO.DisplayProducts(products, "Edit");

            Headers.DisplayHeader(workflow);

            //edit area 

            decimal editArea = ConsoleIO.GetArea("Edit");

            Headers.DisplayHeader(workflow);

            //display order changes

            Order editOrder = new Order(orderResponse.Order);

            if(editName != "")
            {
                editOrder.CustomerName = editName;
            }
            if(editStateTax != null)
            {
                editOrder.State = editStateTax.StateAbbreviation;
                editOrder.TaxRate = editStateTax.TaxRate;
            }
            if(editProduct != null)
            {
                editOrder.ProductType = editProduct.ProductType;
                editOrder.LaborCostPerSquareFoot = editProduct.LaborCostPerSquareFoot;
                editOrder.CostPerSquareFoot = editProduct.CostPerSquareFoot;
            }
            if(editArea != int.MaxValue)
            {
                editOrder.Area = editArea;
            }

            //send it!
            ShowDetails.DisplayOrderDetails(editOrder);

            if(ConsoleIO.GetYesOrNo("Submit changes to order?") == "Y")
            {
                OrderAddEditedResponse response = orderManager.AddEditedOrder(editOrder);
                if (!response.Success)
                {
                    Console.WriteLine("There was an error adding the order:");
                    Console.WriteLine(response.Message);
                }
                else
                {
                    Console.WriteLine("Order added! Press any key to return to main menu...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Edit order cancelled :( Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
