using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS.MockRepos
{
    public class AlwaysReturnsStateTax : IStateTaxRepository
    {
        private static StateTax state = new StateTax()
        {
            StateAbbreviation = "OH",
            StateName = "Ohio",
            TaxRate = 6.00M,
        };

        public StateTax GetState(string stateAbbr)
        {
            return state;
        }

        public List<StateTax> ListStates()
        {
            List<StateTax> states = new List<StateTax>();

            states.Add(state);

            return states;
        }
    }
}
