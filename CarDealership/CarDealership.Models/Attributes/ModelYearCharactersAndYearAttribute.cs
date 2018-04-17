using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Attributes
{
    public class ModelYearCharactersAndYearAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is int)
            {
                int model = (int)value;

                if (model < 2000 || model > DateTime.Now.Year + 1)
                {
                    return false;
                }
                else if (model.ToString().Length > 4)
                {
                    return false;
                }
                else
                    return true;
            }

            return false;
        }
    }
}
