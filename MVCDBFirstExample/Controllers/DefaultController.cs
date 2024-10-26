using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDBFirstExample.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewData["EmpName"] = "Dasharad.Kona";
            ViewData["SkillSet"] = new List<string>()
            {
                "MVC",
                "SQL",
                "API",
            };

            ViewBag.EmpName = "Dasharad.Kona";
            ViewBag.SkillSet = new List<string>()
            {
                "MVC",
                "SQL",
                "API"

            };

            TempData["EmpName"] = "Dasharad.Kona";
            TempData["SkillSet"] = new List<string>()
            {
                "MVC",
                "SQL",
                "API",
            };

            //return RedirectToAction("About","Home");

            return View();
        }
    }
}