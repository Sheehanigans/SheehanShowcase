using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.DATA
{
    public class TestProductRepository : IProductRepository
    {
        public static List<Product> products = new List<Product>()
        {
            new Product("Wood",2.15M,4.75M),
            new Product("Carpet",2.25M,2.10M),
            new Product("Tile",3.50M,4.15M),
            new Product("Laminate",1.75M,2.10M),
        };

        public List<Product> GetProductList()
        {
            return products;
        }
    }
}
