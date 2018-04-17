using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class SpecialListVM
    {
        public List<Special> Specials { get; set; }

        public SpecialListVM()
        {
            Specials = new List<Special>();
        }

        public void SetSpecialItems(IEnumerable<Special> specials)
        {
            foreach (var special in specials)
            {
                Specials.Add(special);
            }
        }
    }
}