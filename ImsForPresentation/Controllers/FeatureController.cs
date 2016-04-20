using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImsForPresentation.Models;
using Microsoft.AspNet.Identity;

namespace ImsForPresentation.Controllers
{
    public class FeatureController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Feature
        public ActionResult Index()
        {
            var features = db.Features.Include(f => f.ApplicationUser).Include(f => f.FeaturePalette);
            return View(features.ToList());
        }

        // GET: Feature/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature feature = db.Features.Find(id);
            if (feature == null)
            {
                return HttpNotFound();
            }
            return View(feature);
        }

        // GET: Feature/Create
        public ActionResult Create()
        {
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            ViewBag.FeaturePaletteId = new SelectList(db.FeaturePalettes, "Id", "FeatureName");
            return View();
        }

        // POST: Feature/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FeaturePaletteId,ProductFeatureName,ProductFeature,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] Feature feature)
        {
            if (ModelState.IsValid)
            {
                string currentUser = User.Identity.GetUserId();
                feature.CreatedBy = currentUser;
                feature.CreatedAt = DateTime.Now;
                feature.UpdatedAt = DateTime.Now;
                db.Features.Add(feature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", feature.CreatedBy);
            ViewBag.FeaturePaletteId = new SelectList(db.FeaturePalettes, "Id", "FeatureName", feature.FeaturePaletteId);
            return View(feature);
        }

        // GET: Feature/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature feature = db.Features.Find(id);
            if (feature == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", feature.CreatedBy);
            ViewBag.FeaturePaletteId = new SelectList(db.FeaturePalettes, "Id", "FeatureName", feature.FeaturePaletteId);
            return View(feature);
        }

        // POST: Feature/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FeaturePaletteId,ProductFeatureName,ProductFeature,Description,ActiveStatus,CreatedAt")] Feature feature)
        {
            if (ModelState.IsValid)
            {
                string currentUser = User.Identity.GetUserId();
                feature.CreatedBy = currentUser;
                feature.UpdatedAt = (DateTime)DateTime.Now;
                db.Entry(feature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", feature.CreatedBy);
            ViewBag.FeaturePaletteId = new SelectList(db.FeaturePalettes, "Id", "FeatureName", feature.FeaturePaletteId);
            return View(feature);
        }

        // GET: Feature/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature feature = db.Features.Find(id);
            if (feature == null)
            {
                return HttpNotFound();
            }
            return View(feature);
        }

        // POST: Feature/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feature feature = db.Features.Find(id);
            db.Features.Remove(feature);
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
