using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Special
    {
        public int SpecialId { get; set; }

        [StringLength(50, ErrorMessage = "Special cannot be longer than 50 characters.")]
        [Required(ErrorMessage = "Please enter a Special Title")]
        public string SpecialTitle { get; set; }

        [StringLength(400, ErrorMessage = "Message cannot be longer than 400 characters.")]
        [Required(ErrorMessage = "Please enter a Message")]
        public string SpecialMessage { get; set; }
    }
}
