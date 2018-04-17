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
    [ConditionAndMileage(ErrorMessage = "New listings must have 1000 miles or less")]
    //[ModelYearCharactersAndYear(ErrorMessage = "Year must be less than next year and greater than 2000")]
    [MSRPAndSalePrice(ErrorMessage = "MSRP must be a positive number higher than Sale Price")]
    public class Listing
    {
        public int ListingId { get; set; }

        [Required(ErrorMessage = "Please select a Model")]
        public int ModelId { get; set; }
        public string ModelName { get; set; }

        [Required(ErrorMessage = "Please select a Make")]
        public int MakeId { get; set; }
        public string MakeName { get; set; }

        [Required(ErrorMessage = "Please select a Body Style")]
        public int BodyStyleId { get; set; }
        public string BodyStyleName { get; set; }

        [Required(ErrorMessage = "Please select an Interior Color")]
        public int InteriorColorId { get; set; }
        public string InteriorColorName { get; set; }

        [Required(ErrorMessage = "Please select an Exterior Color")]
        public int ExteriorColorId { get; set; }
        public string ExteriorColorName { get; set; }

        [EnumDataType(typeof(Condition), ErrorMessage = "Please select a condition")]
        public Condition? Condition { get; set; }

        [EnumDataType(typeof(Transmission), ErrorMessage = "Please select a Transmission")]
        public Transmission? Transmission { get; set; }

        [Required(ErrorMessage = "Please select the mileage")]
        [Range(0, 9999999, ErrorMessage = "Please enter valid integer Number")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Please enter a year")]
        [Range(0, 9999, ErrorMessage = "Please enter valid year")]
        public int ModelYear { get; set; }

        public string VIN { get; set; }

        [Required(ErrorMessage = "Please enter an MSRP")]
        [Range(0, 999999999, ErrorMessage = "Please enter valid integer Number")]
        public decimal MSRP { get; set; }

        [Required(ErrorMessage = "Please enter a SalePrice")]
        [Range(0, 999999999, ErrorMessage = "Please enter valid integer Number")]
        public decimal SalePrice { get; set; }

        //[Required(ErrorMessage = "Please enter a Description")]
        public string VehicleDescription { get; set; }

        public string ImageFileUrl { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSold { get; set; }
        public DateTime DateAdded { get; set; }
    }
}