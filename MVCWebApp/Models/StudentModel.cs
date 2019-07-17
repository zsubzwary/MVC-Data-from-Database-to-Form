using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    public class StudentModel
    {
        public int StudentID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String EmailAddress { get; set; }
        public String Password { get; set; }
        public String ConfirmPassword { get; set; }
    }
}