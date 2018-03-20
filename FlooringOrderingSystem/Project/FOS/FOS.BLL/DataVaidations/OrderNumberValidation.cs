using FOS.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL.DataValidations
{
    public class OrderNumberValidation
    {
        public static int CreateOrderNumber(DateTime date)
        {
            OrderManager manager = OrderManagerFactory.Create();

            List<Order> orders = manager.GetOrderList(date).Orders;

            int newOrderNumber = 0;

            if (orders != null)
            {
                newOrderNumber = orders.Count();

                foreach (var ord in orders)
                {
                    newOrderNumber = Math.Max(newOrderNumber, ord.OrderNumber);
                }
            }

            return newOrderNumber + 1;
        }
    }
}
