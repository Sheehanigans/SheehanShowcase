using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Attributes
{
    public class ConditionAndMileageAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is Listing)
            {
                Listing model = (Listing)value;

                if (model.Condition == Enums.Condition.New && (model.Mileage > 1000 || model.Mileage < 0))
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
