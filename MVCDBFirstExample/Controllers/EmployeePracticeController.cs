using MVCDBFirstExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDBFirstExample.Controllers
{
    public class EmployeePracticeController : Controller
    {
        SampleEntities1 db = new SampleEntities1();
        // GET: EmployeePractice
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}