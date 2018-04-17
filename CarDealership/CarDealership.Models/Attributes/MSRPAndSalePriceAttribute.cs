using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Attributes
{
    public class MSRPAndSalePriceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is Listing)
            {
                Listing model = (Listing)value;

                if (model.MSRP < model.SalePrice)
                {
                    return false;
                }
                else if (model.MSRP < 0 || model.SalePrice < 0)
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
