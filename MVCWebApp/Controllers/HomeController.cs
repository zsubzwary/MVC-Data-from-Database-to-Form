using MVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWebApp.HelperClasses;

namespace MVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult SignUp()
        {
            ViewBag.Message = "Student SignUp page.";

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DBHelper.insertIntoStudents(student);
                }
                catch (Exception ex)
                {
                    return RedirectToAction("error");
                }
                return RedirectToAction("index");
            }
            return View();
        }
    }
}