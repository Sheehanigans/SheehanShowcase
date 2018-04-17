﻿using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Interfaces
{
    public interface ISpecialRepository
    {
        List<Special> GetSpecials();
        Special Save(Special special);
        bool DeleteSpecial(int id);
    }
}
