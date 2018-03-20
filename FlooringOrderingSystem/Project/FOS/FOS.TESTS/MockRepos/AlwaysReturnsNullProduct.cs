using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS.MockRepos
{
    public class AlwaysReturnsNullProduct : IProductRepository
    {
        public List<Product> GetProductList()
        {
            return null;
        }
    }
}
