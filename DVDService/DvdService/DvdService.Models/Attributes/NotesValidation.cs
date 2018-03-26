using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdService.Models.Attributes
{
    public class NotesValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string checkNote = (string)value;
                if (checkNote.Length > 100 || checkNote == null)
                    return false;
                else
                    return true;
            }

            return false;
        }
    }
}
