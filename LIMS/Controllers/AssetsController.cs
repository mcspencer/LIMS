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
                ICollection<LabAssetTag> tags = ParseAssetTagsFromString(tagList);

                // Attach the labasset object to the context.
                db.LabAssets.Add(labasset);

                // Add tags to its list
                labasset.AddTags(tags);
                                
                // Save the changes
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
                // Reattach the labasset object to the context and save its internal data
                db.Entry(labasset).State = EntityState.Modified;
                db.SaveChanges();

                // Reload the entity from the database, including its list of tags
                labasset = db.LabAssets.Include(la => la.LabAssetTags).Where(la => (la.LabAssetId == labasset.LabAssetId)).FirstOrDefault();
                    
                // Add all the tags on the form to the list
                ICollection<LabAssetTag> tags = ParseAssetTagsFromString(tagList);
                labasset.AddTags(tags);

                // Save the changes to the entity and the list
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

        /// <summary>
        /// Parses a string of comma separated tags and attaches them to tags stored in the database, creating new tags when necessary
        /// </summary>
        /// <param name="tagList"></param>
        /// <returns></returns>
        private ICollection<LabAssetTag> ParseAssetTagsFromString(string tagList)
        {
            ICollection<LabAssetTag> tags = new List<LabAssetTag>();

            string[] tagtoks = tagList.Split(',');
            foreach (string tag in tagtoks)
            {
                LabAssetTag assetTag = (from at in db.LabAssetTags where at.Name.Equals(tag.Trim(), StringComparison.OrdinalIgnoreCase) select at).FirstOrDefault();
                if (assetTag == null)
                {
                    assetTag = new LabAssetTag();
                    assetTag.Name = tag.Trim();
                    db.LabAssetTags.Add(assetTag);
                    db.SaveChanges();
                }
                tags.Add(assetTag);
            }
            return tags;
        }
    }
}