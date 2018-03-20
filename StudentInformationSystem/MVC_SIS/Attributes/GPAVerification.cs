using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Attributes
{
    public class GPAVerification : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is decimal)
            {
                decimal checkGPA = (decimal)value;
                if (checkGPA > 4 || checkGPA < 0)
                    return false;
                else
                    return true;
            }

            return false;
        }
    }
}