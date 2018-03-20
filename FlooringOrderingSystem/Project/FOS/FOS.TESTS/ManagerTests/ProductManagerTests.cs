using FOS.BLL.Managers;
using FOS.TESTS.MockRepos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS.ManagerTests
{
    [TestFixture]
    public class ProductManagerTests
    {
        [Test]
        public static void GetProductListWithProducts()
        {
            ProductManager manager = new ProductManager(new AlwaysReturnsProduct());

            var test = manager.GetProductList();

            Assert.IsNotNull(test.Products);
            Assert.IsTrue(test.Success);
        }

        [Test]
        public static void GetProductListWithNull()
        {
            ProductManager manager = new ProductManager(new AlwaysReturnsNullProduct());

            var test = manager.GetProductList();

            Assert.IsNull(test.Products);
            Assert.IsFalse(test.Success);
        }

    }
}
