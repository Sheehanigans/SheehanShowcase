using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using FOS.MODELS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL.Managers
{
    public class ProductManager
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductListResponse GetProductList()
        {
            ProductListResponse response = new ProductListResponse();

            response.Products = _productRepository.GetProductList();

            if (response.Products == null)
            {
                response.Success = false;
                response.Message = $"File appears to have no products";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
    }
}
