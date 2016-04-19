using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class HouseProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /HouseProduct/
        public ActionResult Index()
        {
            var houseproducts = db.HouseProducts.Include(h => h.ApplicationUser);
            return View(houseproducts.ToList());
        }

        // GET: /HouseProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseProduct houseproduct = db.HouseProducts.Find(id);
            if (houseproduct == null)
            {
                return HttpNotFound();
            }
            return View(houseproduct);
        }

        // GET: /HouseProduct/Create
        public ActionResult Create()
        {
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            return View();
        }

        // POST: /HouseProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,HouseId,ProductId,ProductBatchId,OrderId,ShelfId,ShelfRow,ShelfCol,ProductStock,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] HouseProduct houseproduct)
        {
            if (ModelState.IsValid)
            {
                db.HouseProducts.Add(houseproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", houseproduct.CreatedBy);
            return View(houseproduct);
        }

        // GET: /HouseProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseProduct houseproduct = db.HouseProducts.Find(id);
            if (houseproduct == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", houseproduct.CreatedBy);
            return View(houseproduct);
        }

        // POST: /HouseProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,HouseId,ProductId,ProductBatchId,OrderId,ShelfId,ShelfRow,ShelfCol,ProductStock,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] HouseProduct houseproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(houseproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", houseproduct.CreatedBy);
            return View(houseproduct);
        }

        // GET: /HouseProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseProduct houseproduct = db.HouseProducts.Find(id);
            if (houseproduct == null)
            {
                return HttpNotFound();
            }
            return View(houseproduct);
        }

        // POST: /HouseProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseProduct houseproduct = db.HouseProducts.Find(id);
            db.HouseProducts.Remove(houseproduct);
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
