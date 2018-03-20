using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS.MockRepos
{
    public class AlwaysReturnsNullStateTax : IStateTaxRepository
    {
        public StateTax GetState(string stateAbbr)
        {
            return null;
        }

        public List<StateTax> ListStates()
        {
            return null;
        }
    }
}
