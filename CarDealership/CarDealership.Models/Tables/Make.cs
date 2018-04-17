using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Make
    {
        public int MakeId { get; set; }

        [StringLength(50, ErrorMessage = "make Name cannot be longer than 50 characters.")]
        [Required(ErrorMessage = "Please enter a Make Name")]
        public string MakeName { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserName { get; set; }
    }
}
