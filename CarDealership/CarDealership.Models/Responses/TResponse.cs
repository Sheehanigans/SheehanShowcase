using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Responses
{
    public class TResponse<T> : Response
    {
        public T Payload { get; set; }
    }
}