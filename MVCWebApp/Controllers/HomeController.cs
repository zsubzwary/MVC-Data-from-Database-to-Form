﻿using MVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                return RedirectToAction("index");
            }
            return View();
        }
    }
}