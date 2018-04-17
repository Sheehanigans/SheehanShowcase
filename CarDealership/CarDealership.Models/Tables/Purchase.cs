using CarDealership.Models.Attributes;
using CarDealership.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    [PhoneOrEmailPurchase(ErrorMessage = "Please enter either an Email or Phone number")]
    public class Purchase
    {
        public int PurchaseId { get; set; }

        public int ListingId { get; set; }

        [Required(ErrorMessage = "Please enter a State")]
        public int StateId { get; set; }

        [StringLength(50, ErrorMessage = "CustomerName cannot be longer than 50 characters.")]
        public string CustomerName { get; set; }

        [StringLength(20, ErrorMessage = "Phone cannot be longer than 20 characters.")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a Street")]
        [StringLength(100, ErrorMessage = "Street cannot be longer than 100 characters.")]
        public string Street1 { get; set; }

        [StringLength(100, ErrorMessage = "Street cannot be longer than 100 characters.")]
        public string Street2 { get; set; }

        [Required(ErrorMessage = "Please enter a City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a Zipcode")]
        [StringLength(5, ErrorMessage = "Zipcode cannot be longer than 5 characters.")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Please enter a Purchase Price")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Please enter a PaymentOption")]
        public PaymentOption? PaymentOption { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserName { get; set; }
    }
}
