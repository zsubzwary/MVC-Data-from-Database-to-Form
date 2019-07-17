using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApp.HelperClasses
{
    public class Student
    {
        public int StudentID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String EmailAddress { get; set; }
        public String Password { get; set; }
    }
}