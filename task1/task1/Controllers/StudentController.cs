using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using task1.Models;

namespace task1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {

            return View();
        }
        public ActionResult Educations()
        {
            Education e1 = new Education()
            {
                Degree = "BSc",
                Institution = "AIUB",
                Year = 2020
            };

            Education e2 = new Education()
            {
                Degree = "Bsc",
                Institution = "AIUB",
                Year = 2022
            };
            Education e3 = new Education()
            {
                Degree = "Bsc",
                Institution = "NSU",
                Year = 2026
            };

            Education[] e = new Education[] { e1, e2, e3 };

            return View(e);
        }
        public ActionResult Projects()
        {
            Project p1 = new Project()
            {
                Course = "OOP1",
                Title = "Java",
                Grade = "A"
            };
            Project p2 = new Project()
            {
                Course = "OOP2",
                Title = "C#",
                Grade = "B+"
            };
            Project p3 = new Project()
            {
                Course = "Web Technology",
                Title = "Web app",
                Grade = "A+"
            };
            Project[] p = new Project[] { p1, p2, p3 };
            return View(p);
        }
        public ActionResult Ref()
        {
            return View();
        }
    }
}