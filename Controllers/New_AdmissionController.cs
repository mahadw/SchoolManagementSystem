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
    public class New_AdmissionController : Controller
    {
        private School_Management_SystemEntities db = new School_Management_SystemEntities();

        // GET: New_Admission
        public ActionResult Index()
        {
            return View(db.New_Admission.ToList());
        }

        // GET: New_Admission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New_Admission new_Admission = db.New_Admission.Find(id);
            if (new_Admission == null)
            {
                return HttpNotFound();
            }
            return View(new_Admission);
        }

        // GET: New_Admission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: New_Admission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_ID,First_Name,Last_Name,Father_Name,Mobile_No,Previous_Class,Previous_Result,Admission_Class")] New_Admission new_Admission)
        {
            if (ModelState.IsValid)
            {
                db.New_Admission.Add(new_Admission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(new_Admission);
        }

        // GET: New_Admission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New_Admission new_Admission = db.New_Admission.Find(id);
            if (new_Admission == null)
            {
                return HttpNotFound();
            }
            return View(new_Admission);
        }

        // POST: New_Admission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_ID,First_Name,Last_Name,Father_Name,Mobile_No,Previous_Class,Previous_Result,Admission_Class")] New_Admission new_Admission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(new_Admission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(new_Admission);
        }

        // GET: New_Admission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New_Admission new_Admission = db.New_Admission.Find(id);
            if (new_Admission == null)
            {
                return HttpNotFound();
            }
            return View(new_Admission);
        }

        // POST: New_Admission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            New_Admission new_Admission = db.New_Admission.Find(id);
            db.New_Admission.Remove(new_Admission);
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
