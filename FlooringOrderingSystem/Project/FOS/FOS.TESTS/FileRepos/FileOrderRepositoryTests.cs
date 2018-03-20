using FOS.BLL;
using FOS.DATA.FileRepositories;
using FOS.MODELS;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS.FileRepos
{
    [TestFixture]
    public class FileOrderRepositoryTests
    {
        private const string filePath = @"C:\Repos\ryan-sheehan-individual-work\FlooringOrderingSystem\Data\TestFiles\Orders\Orders_";
        private const string original = @"C:\Repos\ryan-sheehan-individual-work\FlooringOrderingSystem\Data\TestFiles\Orders\OrdersSeed.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(filePath + "06062019.txt"))
            {
                File.Delete(filePath + "06062019.txt");
            }

            File.Copy(original, filePath + "06062019.txt");
        }

        [TestCase(2019,06,06,true)]
        public void CanGetOrderListForDate(int year, int month, int day, bool expetctedValue)
        {
            DateTime date = new DateTime(year, month, day);

            List<Order> orders = new List<Order>();

            FileOrderRepository repo = new FileOrderRepository(filePath);

            var orderList = repo.ListOrdersForDate(date);

            foreach (Order ord in orderList)
            {
                orders.Add(ord);
            }

            Assert.AreEqual(2, orders.Count());
            Assert.IsTrue(expetctedValue);
        }

        [TestCase(2020, 09, 09, 5, "ryan", "OH", 6.25, "Wood", 10, 5.15, 4.75, true)]
        public void CanAddOrder(int year, int month, int day, int orderNumber, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expectedResult)
        {
            DateTime date = new DateTime(year, month, day);

            Order order = new Order();

            order.Date = date;
            order.OrderNumber = orderNumber;
            order.CustomerName = customerName;
            order.State = state;
            order.TaxRate = taxRate;
            order.ProductType = productType;
            order.Area = area;
            order.CostPerSquareFoot = costPerSquareFoot;
            order.LaborCostPerSquareFoot = laborCostPerSquareFoot;

            FileOrderRepository repo = new FileOrderRepository(filePath);

            bool actual = repo.Add(order);

            Assert.AreEqual(expectedResult, actual);
        }

        [TestCase(2019,06,06,"Nikki","Carpet","MI",120.00,true)]
        public void CanEditOrder(int year, int month, int day, string name, string productType, string stateAbrr, decimal area, bool expectedValue)
        {
            FileOrderRepository repo = new FileOrderRepository(filePath);
            DateTime date = new DateTime(year, month, day);

            List<Order> orders = repo.ListOrdersForDate(date);

            Order editedOrder = orders[0];

            editedOrder.CustomerName = name;
            editedOrder.ProductType = productType;
            editedOrder.State = stateAbrr;
            editedOrder.Area = area;

            repo.Edit(editedOrder);

            repo.ListOrdersForDate(date);
            Order check = orders[0];

            Assert.AreEqual("Nikki", check.CustomerName);
            Assert.AreEqual("Carpet", check.ProductType);
            Assert.AreEqual("MI", check.State);
            Assert.AreEqual(120.00, check.Area);
        }

        [TestCase(2019, 06, 06, 2, "bob", "OH", 6.25, "Laminate", 300, 1.75, 2.10, true)]
        public void CanRemoveOrder(int year, int month, int day, int orderNumber, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expectedResult)
        {
            FileOrderRepository repo = new FileOrderRepository(filePath);

            Order order = new Order();

            DateTime date = new DateTime(year, month, day);

            order.Date = date;
            order.OrderNumber = orderNumber;
            order.CustomerName = customerName;
            order.State = state;
            order.TaxRate = taxRate;
            order.ProductType = productType;
            order.Area = area;
            order.CostPerSquareFoot = costPerSquareFoot;
            order.LaborCostPerSquareFoot = laborCostPerSquareFoot;

            repo.Remove(order);

            List <Order> orders = repo.ListOrdersForDate(date);

            Order check = orders[0];

            Assert.AreEqual("Ryan", check.CustomerName);
            Assert.AreEqual("OH", check.State);
            Assert.AreEqual(1, orders.Count());
        }
    }
}
