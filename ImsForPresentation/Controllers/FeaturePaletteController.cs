using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class FeaturePaletteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /FeaturePalette/
        public ActionResult Index()
        {
            var featurepalettes = db.FeaturePalettes.Include(f => f.ApplicationUser);
            return View(featurepalettes.ToList());
        }

        // GET: /FeaturePalette/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturePalette featurepalette = db.FeaturePalettes.Find(id);
            if (featurepalette == null)
            {
                return HttpNotFound();
            }
            return View(featurepalette);
        }

        // GET: /FeaturePalette/Create
        public ActionResult Create()
        {
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            return View();
        }

        // POST: /FeaturePalette/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,FeatureName,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] FeaturePalette featurepalette)
        {
            if (ModelState.IsValid)
            {
                db.FeaturePalettes.Add(featurepalette);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", featurepalette.CreatedBy);
            return View(featurepalette);
        }

        // GET: /FeaturePalette/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturePalette featurepalette = db.FeaturePalettes.Find(id);
            if (featurepalette == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", featurepalette.CreatedBy);
            return View(featurepalette);
        }

        // POST: /FeaturePalette/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FeatureName,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] FeaturePalette featurepalette)
        {
            if (ModelState.IsValid)
            {
                db.Entry(featurepalette).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", featurepalette.CreatedBy);
            return View(featurepalette);
        }

        // GET: /FeaturePalette/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturePalette featurepalette = db.FeaturePalettes.Find(id);
            if (featurepalette == null)
            {
                return HttpNotFound();
            }
            return View(featurepalette);
        }

        // POST: /FeaturePalette/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeaturePalette featurepalette = db.FeaturePalettes.Find(id);
            db.FeaturePalettes.Remove(featurepalette);
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
