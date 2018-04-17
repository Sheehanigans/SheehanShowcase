using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class MakesVM
    {
        public List<Make> Makes { get; set; }
        public Make NewMake { get; set; }

        public MakesVM()
        {
            Makes = new List<Make>();
            NewMake = new Make();
        }

        public void SetMakeItems(IEnumerable<Make> makes)
        {
            foreach (var make in makes)
            {
                Makes.Add(make);
            }
        }
    }
}