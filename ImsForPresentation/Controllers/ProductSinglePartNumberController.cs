using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class ProductSinglePartNumberController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ProductSinglePartNumber/
        public ActionResult Index()
        {
            var productsinglepartnumbers = db.ProductSinglePartNumbers.Include(p => p.ApplicationUser).Include(p => p.HouseProduct);
            return View(productsinglepartnumbers.ToList());
        }

        // GET: /ProductSinglePartNumber/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSinglePartNumber productsinglepartnumber = db.ProductSinglePartNumbers.Find(id);
            if (productsinglepartnumber == null)
            {
                return HttpNotFound();
            }
            return View(productsinglepartnumber);
        }

        // GET: /ProductSinglePartNumber/Create
        public ActionResult Create()
        {
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            ViewBag.ProductId = new SelectList(db.HouseProducts, "Id", "ShelfRow");
            return View();
        }

        // POST: /ProductSinglePartNumber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductId,Batch,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] ProductSinglePartNumber productsinglepartnumber)
        {
            if (ModelState.IsValid)
            {
                db.ProductSinglePartNumbers.Add(productsinglepartnumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", productsinglepartnumber.CreatedBy);
            ViewBag.ProductId = new SelectList(db.HouseProducts, "Id", "ShelfRow", productsinglepartnumber.ProductId);
            return View(productsinglepartnumber);
        }

        // GET: /ProductSinglePartNumber/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSinglePartNumber productsinglepartnumber = db.ProductSinglePartNumbers.Find(id);
            if (productsinglepartnumber == null)
            {
                return HttpNotFound();
            }
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", productsinglepartnumber.CreatedBy);
            ViewBag.ProductId = new SelectList(db.HouseProducts, "Id", "ShelfRow", productsinglepartnumber.ProductId);
            return View(productsinglepartnumber);
        }

        // POST: /ProductSinglePartNumber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductId,Batch,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] ProductSinglePartNumber productsinglepartnumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsinglepartnumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", productsinglepartnumber.CreatedBy);
            ViewBag.ProductId = new SelectList(db.HouseProducts, "Id", "ShelfRow", productsinglepartnumber.ProductId);
            return View(productsinglepartnumber);
        }

        // GET: /ProductSinglePartNumber/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSinglePartNumber productsinglepartnumber = db.ProductSinglePartNumbers.Find(id);
            if (productsinglepartnumber == null)
            {
                return HttpNotFound();
            }
            return View(productsinglepartnumber);
        }

        // POST: /ProductSinglePartNumber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSinglePartNumber productsinglepartnumber = db.ProductSinglePartNumbers.Find(id);
            db.ProductSinglePartNumbers.Remove(productsinglepartnumber);
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
