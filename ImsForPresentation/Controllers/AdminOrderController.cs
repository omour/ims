using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class AdminOrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /AdminOrder/
        public ActionResult Index()
        {
            var adminorders = db.AdminOrders.Include(a => a.AdminOrderStatus).Include(a => a.ApplicationUser).Include(a => a.FromHouse).Include(a => a.Product).Include(a => a.RecivedByApplicationUser).Include(a => a.ToHouse);
            return View(adminorders.ToList());
        }

        // GET: /AdminOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminOrder adminorder = db.AdminOrders.Find(id);
            if (adminorder == null)
            {
                return HttpNotFound();
            }
            return View(adminorder);
        }

        // GET: /AdminOrder/Create
        public ActionResult Create()
        {
            ViewBag.AdminOrderStatusId = new SelectList(db.AdminOrderStatuses, "Id", "StatusValue");
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            ViewBag.FromHouseId = new SelectList(db.Houses, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName");
//            ViewBag.ReceivedById = new SelectList(db.IdentityUsers, "Id", "UserName");
            ViewBag.ToHouseId = new SelectList(db.Houses, "Id", "Name");
            return View();
        }

        // POST: /AdminOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,FromHouseId,ProductId,Amount,ToHouseId,AdminOrderStatusId,ReceivedById,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] AdminOrder adminorder)
        {
            if (ModelState.IsValid)
            {
                db.AdminOrders.Add(adminorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdminOrderStatusId = new SelectList(db.AdminOrderStatuses, "Id", "StatusValue", adminorder.AdminOrderStatusId);
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", adminorder.CreatedBy);
            ViewBag.FromHouseId = new SelectList(db.Houses, "Id", "Name", adminorder.FromHouseId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", adminorder.ProductId);
//            ViewBag.ReceivedById = new SelectList(db.IdentityUsers, "Id", "UserName", adminorder.ReceivedById);
            ViewBag.ToHouseId = new SelectList(db.Houses, "Id", "Name", adminorder.ToHouseId);
            return View(adminorder);
        }

        // GET: /AdminOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminOrder adminorder = db.AdminOrders.Find(id);
            if (adminorder == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminOrderStatusId = new SelectList(db.AdminOrderStatuses, "Id", "StatusValue", adminorder.AdminOrderStatusId);
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", adminorder.CreatedBy);
            ViewBag.FromHouseId = new SelectList(db.Houses, "Id", "Name", adminorder.FromHouseId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", adminorder.ProductId);
//            ViewBag.ReceivedById = new SelectList(db.IdentityUsers, "Id", "UserName", adminorder.ReceivedById);
            ViewBag.ToHouseId = new SelectList(db.Houses, "Id", "Name", adminorder.ToHouseId);
            return View(adminorder);
        }

        // POST: /AdminOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FromHouseId,ProductId,Amount,ToHouseId,AdminOrderStatusId,ReceivedById,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] AdminOrder adminorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdminOrderStatusId = new SelectList(db.AdminOrderStatuses, "Id", "StatusValue", adminorder.AdminOrderStatusId);
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", adminorder.CreatedBy);
            ViewBag.FromHouseId = new SelectList(db.Houses, "Id", "Name", adminorder.FromHouseId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", adminorder.ProductId);
//            ViewBag.ReceivedById = new SelectList(db.IdentityUsers, "Id", "UserName", adminorder.ReceivedById);
            ViewBag.ToHouseId = new SelectList(db.Houses, "Id", "Name", adminorder.ToHouseId);
            return View(adminorder);
        }

        // GET: /AdminOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminOrder adminorder = db.AdminOrders.Find(id);
            if (adminorder == null)
            {
                return HttpNotFound();
            }
            return View(adminorder);
        }

        // POST: /AdminOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminOrder adminorder = db.AdminOrders.Find(id);
            db.AdminOrders.Remove(adminorder);
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
