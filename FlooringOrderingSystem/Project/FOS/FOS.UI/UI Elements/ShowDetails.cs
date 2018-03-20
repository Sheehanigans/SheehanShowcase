using FOS.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.UI.UI_Elements
{
    public class ShowDetails
    {
        public static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine($"*****************************************************");
            Console.WriteLine($"Order Number: {order.OrderNumber} | Date: {order.Date}");
            Console.WriteLine($"Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.State}");
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Materials: {order.MaterialCost:c}");
            Console.WriteLine($"Labor: {order.LaborCost:c}");
            Console.WriteLine($"Tax: {order.Tax:c}");
            Console.WriteLine($"Total: {order.Total:c}");
            Console.WriteLine($"******************************************************");
        }
    }
}
