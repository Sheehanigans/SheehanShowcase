using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Address
    {
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string Street1 { get; set; }
        public string Street2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public State State { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        public string PostalCode { get; set; }
    }
}