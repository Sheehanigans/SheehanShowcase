using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.MODELS.Interfaces
{
    public interface IStateTaxRepository
    {
        StateTax GetState(string stateAbbr);

        List<StateTax> ListStates();
    }
}
