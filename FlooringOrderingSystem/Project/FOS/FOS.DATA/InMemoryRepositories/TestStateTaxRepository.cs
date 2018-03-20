using FOS.MODELS;
using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.DATA
{
    public class TestStateTaxRepository : IStateTaxRepository
    {

        private static List<StateTax> states = new List<StateTax>()
        {
            new StateTax("OH","Ohio",6.00M),
            new StateTax("MI","Michigan",5.75M),
            new StateTax("PA","Pennsylvania",6.75M),
            new StateTax("IN","Indiana",6.00M),
        };

        public StateTax GetState(string stateAbbr)
        {
            StateTax state = null;

            foreach (StateTax st in states)
            {
                if (stateAbbr == st.StateAbbreviation)
                {
                    state = st;
                }
            }

            return state;
        }

        public List<StateTax> ListStates()
        {
            return states;
        }
    }
}
