using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdService.Models.Attributes
{
    public class RatingValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string checkRating = (string)value;
                if (checkRating.Length > 5 || checkRating == null)
                    return false;
                else
                    return true;
            }

            return false;
        }
    }
}
