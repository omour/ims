using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class ProductOrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ProductOrder/
        public ActionResult Index()
        {
            var productorders = db.ProductOrders.Include(p => p.ApplicationUser).Include(p => p.Producer).Include(p => p.ProductOrderStatus);
            return View(productorders.ToList());
        }

        // GET: /ProductOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrder productorder = db.ProductOrders.Find(id);
            if (productorder == null)
            {
                return HttpNotFound();
            }
            return View(productorder);
        }

        // GET: /ProductOrder/Create
        public ActionResult Create()
        {
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name");
            ViewBag.ProductOrderStatusId = new SelectList(db.ProductOrderStatuses, "Id", "StatusValue");
            return View();
        }

        // POST: /ProductOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductOrderStatusId,ProducerId,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] ProductOrder productorder)
        {
            if (ModelState.IsValid)
            {
                db.ProductOrders.Add(productorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", productorder.CreatedBy);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", productorder.ProducerId);
            ViewBag.ProductOrderStatusId = new SelectList(db.ProductOrderStatuses, "Id", "StatusValue", productorder.ProductOrderStatusId);
            return View(productorder);
        }

        // GET: /ProductOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrder productorder = db.ProductOrders.Find(id);
            if (productorder == null)
            {
                return HttpNotFound();
            }
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", productorder.CreatedBy);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", productorder.ProducerId);
            ViewBag.ProductOrderStatusId = new SelectList(db.ProductOrderStatuses, "Id", "StatusValue", productorder.ProductOrderStatusId);
            return View(productorder);
        }

        // POST: /ProductOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductOrderStatusId,ProducerId,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] ProductOrder productorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", productorder.CreatedBy);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", productorder.ProducerId);
            ViewBag.ProductOrderStatusId = new SelectList(db.ProductOrderStatuses, "Id", "StatusValue", productorder.ProductOrderStatusId);
            return View(productorder);
        }

        // GET: /ProductOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrder productorder = db.ProductOrders.Find(id);
            if (productorder == null)
            {
                return HttpNotFound();
            }
            return View(productorder);
        }

        // POST: /ProductOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductOrder productorder = db.ProductOrders.Find(id);
            db.ProductOrders.Remove(productorder);
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
