using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.MODELS.Interfaces
{
    public interface IOrderRepository
    {
        Order GetSingleOrder(DateTime date, int orderNumber);

        List<Order> ListOrdersForDate(DateTime date);

        bool Add(Order order);

        bool Edit(Order order);

        bool Remove(Order order);
    }
}
