using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdService.Models.Attributes
{
    public class DirectorValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string checkDirector = (string)value;
                if (checkDirector.Length > 50 || checkDirector == null)
                    return false;
                else
                    return true;
            }

            return false;
        }
    }
}
