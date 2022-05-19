using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    public class Students_MarksController : Controller
    {
        private School_Management_SystemEntities db = new School_Management_SystemEntities();

        // GET: Students_Marks
        public ActionResult Index()
        {
            return View(db.Students_Marks.ToList());
        }

        // GET: Students_Marks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_Marks students_Marks = db.Students_Marks.Find(id);
            if (students_Marks == null)
            {
                return HttpNotFound();
            }
            return View(students_Marks);
        }

        // GET: Students_Marks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students_Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_ID,Subject,Marks")] Students_Marks students_Marks)
        {
            if (ModelState.IsValid)
            {
                db.Students_Marks.Add(students_Marks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students_Marks);
        }

        // GET: Students_Marks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_Marks students_Marks = db.Students_Marks.Find(id);
            if (students_Marks == null)
            {
                return HttpNotFound();
            }
            return View(students_Marks);
        }

        // POST: Students_Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_ID,Subject,Marks")] Students_Marks students_Marks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students_Marks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students_Marks);
        }

        // GET: Students_Marks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_Marks students_Marks = db.Students_Marks.Find(id);
            if (students_Marks == null)
            {
                return HttpNotFound();
            }
            return View(students_Marks);
        }

        // POST: Students_Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students_Marks students_Marks = db.Students_Marks.Find(id);
            db.Students_Marks.Remove(students_Marks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
