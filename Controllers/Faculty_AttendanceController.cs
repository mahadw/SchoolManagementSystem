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
    public class Faculty_AttendanceController : Controller
    {
        private School_Management_SystemEntities db = new School_Management_SystemEntities();

        // GET: Faculty_Attendance
        public ActionResult Index()
        {
            return View(db.Faculty_Attendance.ToList());
        }

        // GET: Faculty_Attendance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty_Attendance faculty_Attendance = db.Faculty_Attendance.Find(id);
            if (faculty_Attendance == null)
            {
                return HttpNotFound();
            }
            return View(faculty_Attendance);
        }

        // GET: Faculty_Attendance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faculty_Attendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Faculty_ID,Department,Date,Attendance")] Faculty_Attendance faculty_Attendance)
        {
            if (ModelState.IsValid)
            {
                db.Faculty_Attendance.Add(faculty_Attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faculty_Attendance);
        }

        // GET: Faculty_Attendance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty_Attendance faculty_Attendance = db.Faculty_Attendance.Find(id);
            if (faculty_Attendance == null)
            {
                return HttpNotFound();
            }
            return View(faculty_Attendance);
        }

        // POST: Faculty_Attendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Faculty_ID,Department,Date,Attendance")] Faculty_Attendance faculty_Attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty_Attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faculty_Attendance);
        }

        // GET: Faculty_Attendance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty_Attendance faculty_Attendance = db.Faculty_Attendance.Find(id);
            if (faculty_Attendance == null)
            {
                return HttpNotFound();
            }
            return View(faculty_Attendance);
        }

        // POST: Faculty_Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculty_Attendance faculty_Attendance = db.Faculty_Attendance.Find(id);
            db.Faculty_Attendance.Remove(faculty_Attendance);
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
