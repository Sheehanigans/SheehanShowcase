using FOS.MODELS;
using FOS.MODELS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL.DataVaidations
{
    public class OrderAddValidation
    {
        public static void AddOrder(Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderAddResponse response = manager.AddOrder(order);

            if (!response.Success)
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(response.Message);
            }
        }

        //Order Manager add method has same validation
        public static bool ValidateOrder(Order order)
        {
            //valid order
            bool validOrder = false;

            //valid name
            bool validName = false;
            while (!validName)
            {
                if (string.IsNullOrEmpty(order.CustomerName))
                {
                    validOrder = false;
                    return validOrder;
                }
                else
                {
                    validName = true;                    
                }
            }

            //validate area
            bool validArea = false;
            while (!validArea)
            {
                if (order.Area < 0 || order.Area < 100)
                {
                    validOrder = false;
                    return validOrder;
                }
                else
                {
                    validArea = true;
                }
            }

            if(validName && validArea)
            {
                validOrder = true;
            }

            return validOrder;
        }
    }
}
