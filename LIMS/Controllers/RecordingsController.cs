using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIMS.Models;

namespace LIMS.Controllers
{
    public class RecordingsController : Controller
    {
        private LIMSContext db = new LIMSContext();

        //
        // GET: /Recordings/

        public ActionResult Index()
        {
            return View(db.Recordings.ToList());
        }

        //
        // GET: /Recordings/Details/5

        public ActionResult Details(int id = 0)
        {
            Recording recording = db.Recordings.Find(id);
            if (recording == null)
            {
                return HttpNotFound();
            }
            return View(recording);
        }

        //
        // GET: /Recordings/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Recordings/Create

        [HttpPost]
        public ActionResult Create(Recording recording)
        {
            if (ModelState.IsValid)
            {
                db.Recordings.Add(recording);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recording);
        }

        //
        // GET: /Recordings/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Recording recording = db.Recordings.Find(id);
            if (recording == null)
            {
                return HttpNotFound();
            }
            return View(recording);
        }

        //
        // POST: /Recordings/Edit/5

        [HttpPost]
        public ActionResult Edit(Recording recording)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recording).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recording);
        }

        //
        // GET: /Recordings/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Recording recording = db.Recordings.Find(id);
            if (recording == null)
            {
                return HttpNotFound();
            }
            return View(recording);
        }

        //
        // POST: /Recordings/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Recording recording = db.Recordings.Find(id);
            db.Recordings.Remove(recording);
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