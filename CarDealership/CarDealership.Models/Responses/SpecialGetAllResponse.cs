using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Responses
{
    public class SpecialGetAllResponse : Response
    {
        public List<Special> Specials { get; set; }
    }
}
