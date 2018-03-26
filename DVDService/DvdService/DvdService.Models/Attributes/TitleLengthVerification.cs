using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdService.Models.Attributes
{
    public class TitleLengthVerification : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string checkTitle = (string)value;
                if (checkTitle.Length > 50 || checkTitle == null)
                    return false;
                else
                    return true;
            }

            return false;
        }
    }
}
