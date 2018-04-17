using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Model
    {
        public int ModelId { get; set; }

        [StringLength(50, ErrorMessage = "model Name cannot be longer than 50 characters.")]
        [Required(ErrorMessage = "Please enter a Model Name")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "Please select a Make")]
        public Make Make { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserName { get; set; }
    }
}
