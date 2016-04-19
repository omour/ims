using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class ProductListInOrderScriptController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ProductListInOrderScript/
        public ActionResult Index()
        {
            var productlistinorderscripts = db.ProductListInOrderScripts.Include(p => p.Product).Include(p => p.ProductOrder);
            return View(productlistinorderscripts.ToList());
        }

        // GET: /ProductListInOrderScript/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductListInOrderScript productlistinorderscript = db.ProductListInOrderScripts.Find(id);
            if (productlistinorderscript == null)
            {
                return HttpNotFound();
            }
            return View(productlistinorderscript);
        }

        // GET: /ProductListInOrderScript/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName");
            ViewBag.ProductOrderId = new SelectList(db.ProductOrders, "Id", "Description");
            return View();
        }

        // POST: /ProductListInOrderScript/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductOrderId,ProductId,Amount")] ProductListInOrderScript productlistinorderscript)
        {
            if (ModelState.IsValid)
            {
                db.ProductListInOrderScripts.Add(productlistinorderscript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", productlistinorderscript.ProductId);
            ViewBag.ProductOrderId = new SelectList(db.ProductOrders, "Id", "Description", productlistinorderscript.ProductOrderId);
            return View(productlistinorderscript);
        }

        // GET: /ProductListInOrderScript/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductListInOrderScript productlistinorderscript = db.ProductListInOrderScripts.Find(id);
            if (productlistinorderscript == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", productlistinorderscript.ProductId);
            ViewBag.ProductOrderId = new SelectList(db.ProductOrders, "Id", "Description", productlistinorderscript.ProductOrderId);
            return View(productlistinorderscript);
        }

        // POST: /ProductListInOrderScript/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductOrderId,ProductId,Amount")] ProductListInOrderScript productlistinorderscript)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productlistinorderscript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", productlistinorderscript.ProductId);
            ViewBag.ProductOrderId = new SelectList(db.ProductOrders, "Id", "Description", productlistinorderscript.ProductOrderId);
            return View(productlistinorderscript);
        }

        // GET: /ProductListInOrderScript/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductListInOrderScript productlistinorderscript = db.ProductListInOrderScripts.Find(id);
            if (productlistinorderscript == null)
            {
                return HttpNotFound();
            }
            return View(productlistinorderscript);
        }

        // POST: /ProductListInOrderScript/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductListInOrderScript productlistinorderscript = db.ProductListInOrderScripts.Find(id);
            db.ProductListInOrderScripts.Remove(productlistinorderscript);
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
