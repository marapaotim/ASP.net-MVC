using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class EmployeeModel
    {
        [Key]
        public int id;

        [Required(ErrorMessage = "Name field is empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender field is empty")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email field is empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age field is empty")]
        public string Age { get; set; }
    }
}