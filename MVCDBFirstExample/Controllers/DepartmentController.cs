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
    public class DepartmentController : Controller
    {
        SampleEntities1 db = new SampleEntities1();
        // GET: Department
        public ActionResult Index()
        {
            return View(db.Depts.ToList());
        }
        //create employee takes to create page
        public ActionResult Create()
        {
            return View();
        }
        //Create new Department and add to DB 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeptId,DeptName,DeptLoc,EmpId")] Dept department)
        {//if everything is correct add to the database,
         //save changes and redirect to the index page
            if (ModelState.IsValid)
            {
                db.Depts.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept department = db.Depts.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //edit and save changes to the Database
        public ActionResult Edit([Bind(Include = "DeptId,DeptName,DeptLoc,EmpId")] Dept department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept department = db.Depts.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept department = db.Depts.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Dept department = db.Depts.Find(id);
            db.Depts.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}