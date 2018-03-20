using Exercises.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [GPAVerification(ErrorMessage = "GPA must be between no more than 4 or less than 0")]
        public decimal GPA { get; set; }

        public Address Address { get; set; }

        public Major Major { get; set; }
        public List<Course> Courses { get; set; }
    }
}