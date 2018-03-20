using FOS.BLL.Factories;
using FOS.BLL.Managers;
using FOS.MODELS.Models;
using FOS.MODELS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL.DataVaidations
{
    public class ProductListValidation
    {
        public static List<Product> CreateProductList()
        {
            ProductManager manager = ProductManagerFactory.Create();

            ProductListResponse plResponse = manager.GetProductList();

            if (plResponse.Success)
            {
                return plResponse.Products;
            }
            else
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(plResponse.Message);
            }

            return plResponse.Products;
        }
    }
}
