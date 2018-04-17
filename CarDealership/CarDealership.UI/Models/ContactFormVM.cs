using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class ContactFormVM
    {
        public ContactForm ContactForm { get; set; }
        public string VIN { get; set; }
    }
}