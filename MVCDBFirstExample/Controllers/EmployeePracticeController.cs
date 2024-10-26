using MVCDBFirstExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        //create employee takes to create page
        public ActionResult Create()   //Load the design 
        {
            return View();
        }
        //Create new employee and add to DB 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,EmpName,EmpSal,EmpAdd")] Employee employee)
        {//if everything is correct add to the database,
         //save changes and redirect to the index page
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        //Get the employee details by Id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        //edit the employee based on the id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //edit and save changes to the Database
        public ActionResult Edit([Bind(Include = "EmpId,EmpName,EmpSal,EmpAdd")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        //delete employee  based on the id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);    
            }
            Employee employee=db.Employees.Find(id); 
            if (employee == null)
            {
                return HttpNotFound(); 
            }
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}