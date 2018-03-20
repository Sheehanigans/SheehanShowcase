using FOS.MODELS;
using FOS.MODELS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS.MockRepos
{
    public class AlwaysReturnsNullOrder : IOrderRepository
    {
        public bool Add(Order order)
        {
            return false;
        }

        public List<Order> ListOrdersForDate(DateTime date)
        {
            return null;
        }

        public bool Edit(Order order)
        {
            return false;
        }

        public Order GetSingleOrder(DateTime date, int orderNumber)
        {
            return null;
        }

        public List<Order> ListOrders()
        {
            return null;
        }

        public bool Remove(Order order)
        {
            return false;
        }
    }
}
