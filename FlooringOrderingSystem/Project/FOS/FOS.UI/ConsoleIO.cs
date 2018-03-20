using FOS.MODELS;
using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.UI
{
    public class ConsoleIO
    {
        public static DateTime GetNewOrderDate(string prompt)
        {
            bool isValid = false;
            DateTime date = DateTime.Now;
            while (!isValid)
            {
                Console.WriteLine(prompt);

                string orderDate = Console.ReadLine();

                if (string.IsNullOrEmpty(orderDate))
                {
                    Console.WriteLine("Enter a valid order date!");
                }
                else
                {
                    if (!DateTime.TryParse(orderDate, out date))
                    {
                        Console.WriteLine("Enter a valid order date!");
                    }
                    else if (date < DateTime.Now)
                    {
                        Console.WriteLine($"The date entered must be greater than {DateTime.Now.ToString("MM/dd/yyyy")}");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
            }

            return date;
        }

        internal static int GetOrderNumberFromUser(string prompt)
        {
            bool validInput = false;
            int choice = 0;

            while (!validInput)
            {
                Console.WriteLine($"{prompt}");

                string userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Blank input.");
                }
                else
                {
                    if (!int.TryParse(userInput, out choice))
                    {
                        Console.WriteLine("Invalid choice: not a number.");
                    }
                    else if (choice < 0)
                    {
                        Console.WriteLine("Invalid choice: cannot be negative");

                    }
                    else
                    {
                        validInput = true;
                    }
                }
            }
            return choice;            
        }

        public static DateTime GetExistingOrderDate(string prompt)
        {
            bool isValid = false;
            DateTime date = DateTime.Now;
            while (!isValid)
            {
                Console.WriteLine(prompt);

                string orderDate = Console.ReadLine();

                if (string.IsNullOrEmpty(orderDate))
                {
                    Console.WriteLine("Enter a valid order date!");
                }
                else
                {
                    if (!DateTime.TryParse(orderDate, out date))
                    {
                        Console.WriteLine("Enter a valid order date!");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
            }

            return date;
        }

        public static decimal GetArea(string workflow)
        {
            bool validInput = false;
            decimal area = 0;

            while (!validInput)
            {
                decimal output = 0;

                Console.WriteLine("Enter the area amount in square feet:");
                string input = Console.ReadLine();
                if(string.IsNullOrEmpty(input) && workflow == "Edit")
                {
                    validInput = true;
                    area = int.MaxValue;
                }
                else if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input is blank");
                }
                else
                {
                    if (!decimal.TryParse(input, out output))
                    {
                        Console.WriteLine("Not a valid number.");
                    }
                    else if (output < 0)
                    {
                        Console.WriteLine("Area must be positive.");
                    }
                    else if (output < 100)
                    {
                        Console.WriteLine("Minimum area 100sq ft.");
                    }
                    else
                    {
                        area = output;
                        validInput = true;
                    }
                }
            }
            return area;
        }

        public static Product DisplayProducts(List<Product> products, string workflow)
        {
            bool validInput = false;
            Product product = null;
            int choice = 0;

            while (!validInput)
            {
                int listNumber = 1;
                foreach (Product prod in products)
                {
                    Console.WriteLine($"#{listNumber} **{prod.ProductType}** ${prod.CostPerSquareFoot} per sq ft. ${prod.LaborCostPerSquareFoot} labor cost per sq ft.");
                    listNumber++;
                }

                Console.WriteLine("\nType the number that corresponds to the product you would like to select:");

                string userInput = Console.ReadLine();

                if (workflow == "Edit" && string.IsNullOrEmpty(userInput))
                {
                    validInput = true;
                }
                else if(string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Blank input.");
                }
                else
                {
                    if (!int.TryParse(userInput, out choice))
                    {
                        Console.WriteLine("Invalid choice: not a number.");
                    }
                    else if (choice > listNumber - 1)
                    {
                        Console.WriteLine("Invalid choice: number too high.");
                    }
                    else
                    {
                        product = products.ElementAt(choice - 1);
                        validInput = true;
                    }
                }
            }
            return product;
        }

        public static string GetStateInputFromUser(string workflow)
        {
            bool isValidState = false;
            string state = "";

            while (!isValidState)
            {
                Console.WriteLine("Please enter a two letter state code:");
                string tempState = Console.ReadLine().ToUpper();
                if(workflow == "Edit" && tempState == "")
                {
                    isValidState = true;
                }
                else if (string.IsNullOrEmpty(tempState))
                {
                    Console.WriteLine("State input blank.");
                }
                else if (tempState.Length > 2 || tempState.Length < 2)
                {
                    Console.WriteLine("State input incorrect length.");
                }
                else if (tempState.Any(char.IsNumber))
                {
                    Console.WriteLine("State input cannot contain numbers.");
                }
                else
                {
                    state = tempState;
                    isValidState = true;
                }
            }

            return state;
        }

        public static string GetCustomerName(string workflow, string name)
        {
            bool validName = false;
            string nameToReturn = "";

            while (!validName)
            {
                if(workflow == "Edit")
                {
                    Console.WriteLine($"Please enter the customer name ({name}):");
                }
                else
                {
                    Console.WriteLine("Please enter the customer name:");
                }
                string tempName = Console.ReadLine();

                if (string.IsNullOrEmpty(tempName) && workflow != "Edit")
                {
                    Console.WriteLine("Enter a valid name!");
                }
                else
                {
                    validName = true;
                    return tempName;
                }
            }
            return nameToReturn;
        }

        public static string GetYesOrNo(string prompt)
        {

            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    return input;
                }
            }
        }
    }
}
