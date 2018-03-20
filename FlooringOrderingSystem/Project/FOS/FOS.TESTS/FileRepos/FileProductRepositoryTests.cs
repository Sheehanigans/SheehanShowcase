using FOS.DATA.FileRepositories;
using FOS.MODELS.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS.FileRepos
{
    [TestFixture]
    public class FileProductRepositoryTests
    {
        private const string filePath = @"C:\Repos\ryan-sheehan-individual-work\FlooringOrderingSystem\Data\TestFiles\Products\TestProducts";

        public void CanGetProductList()
        {
            FileProductRepository repo = new FileProductRepository(filePath);

            List<Product> products = repo.GetProductList();

            Assert.IsNotNull(products);
        }
    }
}
