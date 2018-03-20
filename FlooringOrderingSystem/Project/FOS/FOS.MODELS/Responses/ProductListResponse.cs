using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.MODELS.Responses
{
    public class ProductListResponse : Response
    {
        public List<Product> Products { get; set; }
    }
}
