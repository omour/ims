using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class AdminOrderStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /AdminOrderStatus/
        public ActionResult Index()
        {
            var adminorderstatuses = db.AdminOrderStatuses.Include(a => a.ApplicationUser);
            return View(adminorderstatuses.ToList());
        }

        // GET: /AdminOrderStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminOrderStatus adminorderstatus = db.AdminOrderStatuses.Find(id);
            if (adminorderstatus == null)
            {
                return HttpNotFound();
            }
            return View(adminorderstatus);
        }

        // GET: /AdminOrderStatus/Create
        public ActionResult Create()
        {
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            return View();
        }

        // POST: /AdminOrderStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,StatusValue,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] AdminOrderStatus adminorderstatus)
        {
            if (ModelState.IsValid)
            {
                db.AdminOrderStatuses.Add(adminorderstatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", adminorderstatus.CreatedBy);
            return View(adminorderstatus);
        }

        // GET: /AdminOrderStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminOrderStatus adminorderstatus = db.AdminOrderStatuses.Find(id);
            if (adminorderstatus == null)
            {
                return HttpNotFound();
            }
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", adminorderstatus.CreatedBy);
            return View(adminorderstatus);
        }

        // POST: /AdminOrderStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,StatusValue,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] AdminOrderStatus adminorderstatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminorderstatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", adminorderstatus.CreatedBy);
            return View(adminorderstatus);
        }

        // GET: /AdminOrderStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminOrderStatus adminorderstatus = db.AdminOrderStatuses.Find(id);
            if (adminorderstatus == null)
            {
                return HttpNotFound();
            }
            return View(adminorderstatus);
        }

        // POST: /AdminOrderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminOrderStatus adminorderstatus = db.AdminOrderStatuses.Find(id);
            db.AdminOrderStatuses.Remove(adminorderstatus);
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
