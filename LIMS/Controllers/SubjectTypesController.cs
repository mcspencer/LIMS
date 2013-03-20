using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIMS.Models;
using LIMS.Filters;

namespace LIMS.Controllers
{
    [InitializeSimpleMembership]
    public class SubjectTypesController : Controller
    {
        private LIMSContext db = new LIMSContext();

        //
        // GET: /SubjectTypes/

        public ActionResult Index()
        {
            return View(db.SubjectTypes.ToList());
        }

        //
        // GET: /SubjectTypes/Details/5

        public ActionResult Details(int id = 0)
        {
            SubjectType subjecttype = db.SubjectTypes.Find(id);
            if (subjecttype == null)
            {
                return HttpNotFound();
            }
            return View(subjecttype);
        }

        //
        // GET: /SubjectTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SubjectTypes/Create

        [HttpPost]
        public ActionResult Create(SubjectType subjecttype)
        {
            if (ModelState.IsValid)
            {
                db.SubjectTypes.Add(subjecttype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subjecttype);
        }

        //
        // GET: /SubjectTypes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SubjectType subjecttype = db.SubjectTypes.Find(id);
            if (subjecttype == null)
            {
                return HttpNotFound();
            }
            return View(subjecttype);
        }

        //
        // POST: /SubjectTypes/Edit/5

        [HttpPost]
        public ActionResult Edit(SubjectType subjecttype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjecttype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subjecttype);
        }

        //
        // GET: /SubjectTypes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SubjectType subjecttype = db.SubjectTypes.Find(id);
            if (subjecttype == null)
            {
                return HttpNotFound();
            }
            return View(subjecttype);
        }

        //
        // POST: /SubjectTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectType subjecttype = db.SubjectTypes.Find(id);
            db.SubjectTypes.Remove(subjecttype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}