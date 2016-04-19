using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class PrivilegedRouteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /PrivilegedRoute/
        public ActionResult Index()
        {
            var privilegedroutes = db.PrivilegedRoutes.Include(p => p.ApplicationUser);
            return View(privilegedroutes.ToList());
        }

        // GET: /PrivilegedRoute/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivilegedRoute privilegedroute = db.PrivilegedRoutes.Find(id);
            if (privilegedroute == null)
            {
                return HttpNotFound();
            }
            return View(privilegedroute);
        }

        // GET: /PrivilegedRoute/Create
        public ActionResult Create()
        {
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            return View();
        }

        // POST: /PrivilegedRoute/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,RouteName,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] PrivilegedRoute privilegedroute)
        {
            if (ModelState.IsValid)
            {
                db.PrivilegedRoutes.Add(privilegedroute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", privilegedroute.CreatedBy);
            return View(privilegedroute);
        }

        // GET: /PrivilegedRoute/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivilegedRoute privilegedroute = db.PrivilegedRoutes.Find(id);
            if (privilegedroute == null)
            {
                return HttpNotFound();
            }
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", privilegedroute.CreatedBy);
            return View(privilegedroute);
        }

        // POST: /PrivilegedRoute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,RouteName,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] PrivilegedRoute privilegedroute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(privilegedroute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", privilegedroute.CreatedBy);
            return View(privilegedroute);
        }

        // GET: /PrivilegedRoute/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivilegedRoute privilegedroute = db.PrivilegedRoutes.Find(id);
            if (privilegedroute == null)
            {
                return HttpNotFound();
            }
            return View(privilegedroute);
        }

        // POST: /PrivilegedRoute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrivilegedRoute privilegedroute = db.PrivilegedRoutes.Find(id);
            db.PrivilegedRoutes.Remove(privilegedroute);
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
