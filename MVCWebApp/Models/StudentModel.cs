using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    public class StudentModel
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Student ID")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Student ID")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Student ID")]
        [DataType(DataType.EmailAddress)]
        public String EmailAddress { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Student ID")]
        public String Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Student ID")]
        [Compare("Password", ErrorMessage = "Both password should be same.")]
        public String ConfirmPassword { get; set; }
    }
}