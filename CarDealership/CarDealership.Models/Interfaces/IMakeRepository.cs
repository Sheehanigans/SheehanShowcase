using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Interfaces
{
    public interface IMakeRepository
    {
        Make Save(Make make);

        List<Make> GetMakes();
    }
}
