
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.MODELS
{
    public class Order
    { 

        public DateTime Date { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; } 
        public string ProductType { get; set; }
        public decimal Area { get; set; } 
        public decimal CostPerSquareFoot { get; set; } 
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost => Area * CostPerSquareFoot;
        public decimal LaborCost => Area * LaborCostPerSquareFoot;
        public decimal Tax => ((MaterialCost + LaborCost) * (TaxRate / 100));
        public decimal Total => MaterialCost + LaborCost + Tax;

        public Order() { }

        public Order(Order that) //copy constructor
        {
            Date = that.Date;
            OrderNumber = that.OrderNumber;
            CustomerName = that.CustomerName;
            State = that.State;
            TaxRate = that.TaxRate;
            ProductType = that.ProductType;
            Area = that.Area;
            CostPerSquareFoot = that.CostPerSquareFoot;
            LaborCostPerSquareFoot = that.LaborCostPerSquareFoot;
        }

        public Order(DateTime dateTime, int orderNumber, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot)
        {
            Date = dateTime;
            OrderNumber = orderNumber;
            CustomerName = customerName;
            State = state;
            TaxRate = taxRate;
            ProductType = productType;
            Area = area;
            CostPerSquareFoot = costPerSquareFoot;
            LaborCostPerSquareFoot = laborCostPerSquareFoot;
        }
    }
}
