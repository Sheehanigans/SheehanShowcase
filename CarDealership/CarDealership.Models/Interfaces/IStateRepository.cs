﻿using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Interfaces
{
    public interface IStateRepository
    {
        List<State> GetAll();

        State GetState(int stateId);
    }
}
