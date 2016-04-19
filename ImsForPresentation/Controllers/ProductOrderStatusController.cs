
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class ProductOrderStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ProductOrderStatus/
        public ActionResult Index()
        {
            var productorderstatuses = db.ProductOrderStatuses.Include(p => p.ApplicationUser);
            return View(productorderstatuses.ToList());
        }

        // GET: /ProductOrderStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrderStatus productorderstatus = db.ProductOrderStatuses.Find(id);
            if (productorderstatus == null)
            {
                return HttpNotFound();
            }
            return View(productorderstatus);
        }

        // GET: /ProductOrderStatus/Create
        public ActionResult Create()
        {
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            return View();
        }

        // POST: /ProductOrderStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,StatusValue,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] ProductOrderStatus productorderstatus)
        {
            if (ModelState.IsValid)
            {
                db.ProductOrderStatuses.Add(productorderstatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", productorderstatus.CreatedBy);
            return View(productorderstatus);
        }

        // GET: /ProductOrderStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrderStatus productorderstatus = db.ProductOrderStatuses.Find(id);
            if (productorderstatus == null)
            {
                return HttpNotFound();
            }
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", productorderstatus.CreatedBy);
            return View(productorderstatus);
        }

        // POST: /ProductOrderStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,StatusValue,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] ProductOrderStatus productorderstatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productorderstatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", productorderstatus.CreatedBy);
            return View(productorderstatus);
        }

        // GET: /ProductOrderStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrderStatus productorderstatus = db.ProductOrderStatuses.Find(id);
            if (productorderstatus == null)
            {
                return HttpNotFound();
            }
            return View(productorderstatus);
        }

        // POST: /ProductOrderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductOrderStatus productorderstatus = db.ProductOrderStatuses.Find(id);
            db.ProductOrderStatuses.Remove(productorderstatus);
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
