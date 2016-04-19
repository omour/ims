using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class SIUniController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /SIUni/
        public ActionResult Index()
        {
            var siunits = db.SiUnits.Include(s => s.ApplicationUser);
            return View(siunits.ToList());
        }

        // GET: /SIUni/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiUnit siunit = db.SiUnits.Find(id);
            if (siunit == null)
            {
                return HttpNotFound();
            }
            return View(siunit);
        }

        // GET: /SIUni/Create
        public ActionResult Create()
        {
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            return View();
        }

        // POST: /SIUni/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UnitName,Sign,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] SiUnit siunit)
        {
            if (ModelState.IsValid)
            {
                db.SiUnits.Add(siunit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", siunit.CreatedBy);
            return View(siunit);
        }

        // GET: /SIUni/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiUnit siunit = db.SiUnits.Find(id);
            if (siunit == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", siunit.CreatedBy);
            return View(siunit);
        }

        // POST: /SIUni/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UnitName,Sign,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] SiUnit siunit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siunit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", siunit.CreatedBy);
            return View(siunit);
        }

        // GET: /SIUni/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiUnit siunit = db.SiUnits.Find(id);
            if (siunit == null)
            {
                return HttpNotFound();
            }
            return View(siunit);
        }

        // POST: /SIUni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiUnit siunit = db.SiUnits.Find(id);
            db.SiUnits.Remove(siunit);
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
