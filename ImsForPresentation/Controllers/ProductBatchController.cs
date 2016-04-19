using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class ProductBatchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ProductBatch/
        public ActionResult Index()
        {
            var productbatches = db.ProductBatches.Include(p => p.ApplicationUser);
            return View(productbatches.ToList());
        }

        // GET: /ProductBatch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBatch productbatch = db.ProductBatches.Find(id);
            if (productbatch == null)
            {
                return HttpNotFound();
            }
            return View(productbatch);
        }

        // GET: /ProductBatch/Create
        public ActionResult Create()
        {
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            return View();
        }

        // POST: /ProductBatch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,BatchInfo,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] ProductBatch productbatch)
        {
            if (ModelState.IsValid)
            {
                db.ProductBatches.Add(productbatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", productbatch.CreatedBy);
            return View(productbatch);
        }

        // GET: /ProductBatch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBatch productbatch = db.ProductBatches.Find(id);
            if (productbatch == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", productbatch.CreatedBy);
            return View(productbatch);
        }

        // POST: /ProductBatch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,BatchInfo,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] ProductBatch productbatch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productbatch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", productbatch.CreatedBy);
            return View(productbatch);
        }

        // GET: /ProductBatch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBatch productbatch = db.ProductBatches.Find(id);
            if (productbatch == null)
            {
                return HttpNotFound();
            }
            return View(productbatch);
        }

        // POST: /ProductBatch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductBatch productbatch = db.ProductBatches.Find(id);
            db.ProductBatches.Remove(productbatch);
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
