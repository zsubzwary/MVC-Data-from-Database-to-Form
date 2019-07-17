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


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            string email = collection["EmailAddress"];
            string password = collection["Password"];
            string studentEmail = DBHelper.GetStudent(email, password);
            if (String.IsNullOrWhiteSpace(studentEmail))
            {
                ViewBag.ShowErrorMsg = true;
                ViewBag.ErrorMessage = "Your email OR password doesn’t exist!!";
                Session.Remove("email");
                return View();
            }
            else
            {
                Session["email"] = studentEmail;
                return RedirectToAction("index");
            }
        }
    }
}