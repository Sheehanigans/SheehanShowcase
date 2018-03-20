using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.DATA.FileRepositories
{
    public class FileProductRepository : IProductRepository
    {
        private string _productFilePath = @"C:\Repos\ryan-sheehan-individual-work\FlooringOrderingSystem\Data\Products.txt";

        public FileProductRepository(string productFilePath)
        {
            _productFilePath = productFilePath;
        }

        public List<Product> GetProductList()
        {
            List<Product> products = new List<Product>();

            if (File.Exists(_productFilePath))
            {
                using (StreamReader sr = new StreamReader(_productFilePath, true))
                {
                    sr.ReadLine();
                    string line;

                    while((line = sr.ReadLine()) != null)
                    {
                        Product productInFile = new Product();

                        string[] columns = line.Split(',');

                        productInFile.ProductType = columns[0];
                        productInFile.CostPerSquareFoot = decimal.Parse(columns[1]);
                        productInFile.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                        products.Add(productInFile);
                    }

                }
            }
            else
            {
                products = null;
            }

            return products;
        }
    }
}
