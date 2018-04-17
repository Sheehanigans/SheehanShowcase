using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CarDealership.Models.Attributes;

namespace CarDealership.Models.Tables
{
    [PhoneOrEmail(ErrorMessage = "Must include Email or Phone or both.")]
    public class ContactForm
    {
        public int? ContactFormId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string CustomerName { get; set; }

        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Phone cannot be longer than 20 characters.")]
        public string Phone { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Message cannot be longer than 1000 characters.")]
        public string FormMessage { get; set; }
    }
}
