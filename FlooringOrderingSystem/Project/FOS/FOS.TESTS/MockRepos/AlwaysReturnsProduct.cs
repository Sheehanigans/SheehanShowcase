using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS.MockRepos
{
    public class AlwaysReturnsProduct : IProductRepository
    {
        private static List<Product> _mockProducts = new List<Product>()
        {
            new Product
            {
                ProductType = "Wood",
                CostPerSquareFoot = 2.00M,
                LaborCostPerSquareFoot = 3.00M,
            },
            new Product
            {
                ProductType = "Carpet",
                CostPerSquareFoot = 4.00M,
                LaborCostPerSquareFoot = 4.00M,
            },
        };

        public List<Product> GetProductList()
        {
            return _mockProducts;
        }
    }
}
