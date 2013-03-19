using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LIMS.Filters;
using LIMS.Models;

namespace LIMS.Controllers
{
    [InitializeSimpleMembership]
    public class AssetsController : Controller
    {
        private LIMSContext db = new LIMSContext();

        //
        // GET: /Asset/

        public ActionResult Index()
        {
            return View(db.LabAssets.ToList());
        }

        //
        // GET: /Asset/Details/5

        public ActionResult Details(int id = 0)
        {
            LabAsset labasset = db.LabAssets.Find(id);
            if (labasset == null)
            {
                return HttpNotFound();
            }
            return View(labasset);
        }

        //
        // GET: /Asset/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Asset/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(LabAsset labasset, string tagList)
        {
            labasset.Created = DateTime.Now;
            if (ModelState.IsValid)
            {
                UpdateAssetTagsFromString(labasset, tagList);

                db.LabAssets.Add(labasset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(labasset);
        }

        //
        // GET: /Asset/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LabAsset labasset = db.LabAssets.Find(id);
            if (labasset == null)
            {
                return HttpNotFound();
            }

            PopulateTagList(labasset);
            return View(labasset);
        }

        //
        // POST: /Asset/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(LabAsset labasset, string tagList)
        {
            if (ModelState.IsValid)
            {
                UpdateAssetTagsFromString(labasset, tagList);
                db.Entry(labasset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(labasset);
        }

        //
        // GET: /Asset/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    LabAsset labasset = db.LabAssets.Find(id);
        //    if (labasset == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(labasset);
        //}

        //
        // POST: /Asset/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    LabAsset labasset = db.LabAssets.Find(id);
        //    db.LabAssets.Remove(labasset);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void PopulateTagList(LabAsset asset)
        {
            ViewBag.tagList = asset.GetTagString();
        }

        private void UpdateAssetTagsFromString(LabAsset asset, string tagList)
        {
            string[] tagtoks = tagList.Split(',');
            foreach (string tag in tagtoks)
            {
                LabAssetTag assetTag = (from at in db.LabAssetTags where at.Name.Equals(tag.Trim(), StringComparison.OrdinalIgnoreCase) select at).FirstOrDefault();
                if (assetTag == null)
                {
                    assetTag = new LabAssetTag();
                    assetTag.Name = tag.Trim();
                }
                asset.LabAssetTags.Add(assetTag);
            }
        }
    }
}