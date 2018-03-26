using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdService.Models.Attributes
{
    public class ReleaseYearValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int)
            {
                int checkYear = (int)value;
                if (checkYear.ToString().Length > 4 || checkYear == 0)
                    return false;
                else
                    return true;
            }

            return false;
        }
    }
}
