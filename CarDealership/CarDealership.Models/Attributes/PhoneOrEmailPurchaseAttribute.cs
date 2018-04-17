using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Attributes
{
    public class PhoneOrEmailPurchaseAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is Purchase)
            {
                Purchase model = (Purchase)value;

                if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Phone))
                    return false;
                else
                    return true;

            }

            return false;
        }
    }
}
