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
    public class Students_AttendanceController : Controller
    {
        private School_Management_SystemEntities db = new School_Management_SystemEntities();

        // GET: Students_Attendance
        public ActionResult Index()
        {
            return View(db.Students_Attendance.ToList());
        }

        // GET: Students_Attendance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_Attendance students_Attendance = db.Students_Attendance.Find(id);
            if (students_Attendance == null)
            {
                return HttpNotFound();
            }
            return View(students_Attendance);
        }

        // GET: Students_Attendance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students_Attendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_ID,Class,Section,Date,Attendance")] Students_Attendance students_Attendance)
        {
            if (ModelState.IsValid)
            {
                db.Students_Attendance.Add(students_Attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students_Attendance);
        }

        // GET: Students_Attendance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_Attendance students_Attendance = db.Students_Attendance.Find(id);
            if (students_Attendance == null)
            {
                return HttpNotFound();
            }
            return View(students_Attendance);
        }

        // POST: Students_Attendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_ID,Class,Section,Date,Attendance")] Students_Attendance students_Attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students_Attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students_Attendance);
        }

        // GET: Students_Attendance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_Attendance students_Attendance = db.Students_Attendance.Find(id);
            if (students_Attendance == null)
            {
                return HttpNotFound();
            }
            return View(students_Attendance);
        }

        // POST: Students_Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students_Attendance students_Attendance = db.Students_Attendance.Find(id);
            db.Students_Attendance.Remove(students_Attendance);
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
