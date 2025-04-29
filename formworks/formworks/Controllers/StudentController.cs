using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using formworks.Models;

namespace formworks.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Index(Student s)
        {
            if(ModelState.IsValid) 
            {
                //checking the model validation
                return RedirectToAction("Index", "Home");
            }
            return View(s);

        }
    }
}