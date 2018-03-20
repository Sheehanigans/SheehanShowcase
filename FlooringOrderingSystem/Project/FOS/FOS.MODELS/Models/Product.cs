using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.MODELS.Models
{
    public class Product
    {
        public string ProductType { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }

        public Product(string productType, decimal costPerSquareFoot, decimal laborCostPerSquareFoot)
        {
            ProductType = productType;
            CostPerSquareFoot = costPerSquareFoot;
            LaborCostPerSquareFoot = laborCostPerSquareFoot;
        }

        public Product() { }
    }
}
