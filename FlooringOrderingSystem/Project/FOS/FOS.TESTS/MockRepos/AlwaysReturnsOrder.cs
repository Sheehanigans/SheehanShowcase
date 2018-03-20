using FOS.MODELS;
using FOS.MODELS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS.MockRepos
{
    public class AlwaysReturnsOrder : IOrderRepository
    {
        private static List<Order> _mockOrders = new List<Order>();

        public void MockOrderRepository()
        {
            if (!_mockOrders.Any())
            {
                _mockOrders.AddRange(new List<Order>()
                {
                    new Order
                    {
                        Date = new DateTime(2020, 02, 02),
                        OrderNumber = 2,
                        CustomerName = "Ryan",
                        State = "Ohio",
                        TaxRate = 6.25M,
                        ProductType = "Wood",
                        Area = 120,
                        CostPerSquareFoot = 5.00M,
                        LaborCostPerSquareFoot = 4.75M,
                    },

                    new Order
                    {
                        Date = new DateTime(2030, 03, 03),
                        OrderNumber = 3,
                        CustomerName = "Adam",
                        State = "Michigan",
                        TaxRate = 6.00M,
                        ProductType = "Carpet",
                        Area = 150,
                        CostPerSquareFoot = 6.00M,
                        LaborCostPerSquareFoot = 4.00M,
                    }
                });
            }
        }

        public static Order _singleOrder = new Order()
        {
            Date = new DateTime(2040, 04, 04),
            OrderNumber = 4,
            CustomerName = "Aaron",
            State = "Indiana",
            TaxRate = 3.00M,
            ProductType = "Carpet",
            Area = 200,
            CostPerSquareFoot = 7.00M,
            LaborCostPerSquareFoot = 5.00M,
        };

        public bool Add(Order orderToAdd)
        {
            return true;
        }

        public List<Order> ListOrdersForDate(DateTime date)
        {
            var ordersForDate = ListOrders()
                .Where(w => w.Date == date)
                .ToList();

            return ordersForDate;
        }

        public bool Edit(Order orderToEdit)
        {
            return true;
        }

        public Order GetSingleOrder(DateTime date, int orderNumber)
        {
            return _singleOrder;
        }

        public List<Order> ListOrders()
        {
            return _mockOrders;
        }

        public bool Remove(Order orderToRemove)
        {
            return true;
        }
    }
}
