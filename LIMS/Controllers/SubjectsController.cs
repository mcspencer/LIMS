using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIMS.Models;
using WebMatrix.WebData;
using LIMS.Filters;

namespace LIMS.Controllers
{
    [InitializeSimpleMembership]
    public class SubjectsController : Controller
    {
        private LIMSContext db = new LIMSContext();

        //
        // GET: /Subjects/

        public ActionResult Index()
        {
            return View(db.Subjects.ToList());
        }

        //
        // GET: /Subjects/Details/5

        public ActionResult Details(int id = 0)
        {
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }

            return View(subject);
        }

        //
        // GET: /Subjects/Create

        public ActionResult Create()
        {
            PopulateSubjectTypesList();
            return View();
        }

        //
        // POST: /Subjects/Create

        [HttpPost]
        public ActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                subject.Created = DateTime.Now;
                subject.UserProfileId = WebSecurity.CurrentUserId;
                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateSubjectTypesList(subject.SubjectTypeId);
            return View(subject);
        }

        //
        // GET: /Subjects/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }

            PopulateSubjectTypesList(subject.SubjectTypeId);
            return View(subject);
        }

        //
        // POST: /Subjects/Edit/5

        [HttpPost]
        public ActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateSubjectTypesList(subject.SubjectTypeId);
            return View(subject);
        }

        //
        // GET: /Subjects/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        //
        // POST: /Subjects/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        protected void PopulateSubjectTypesList(int selected = 0)
        {
            ViewBag.SubjectTypeId = new SelectList(db.SubjectTypes.OrderBy(s => s.Name), "SubjectTypeId", "Name", selected);
        }
    }
}