using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class ShelfController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Shelf/
        public ActionResult Index()
        {
            var shelves = db.Shelves.Include(s => s.ApplicationUser);
            return View(shelves.ToList());
        }

        // GET: /Shelf/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shelf shelf = db.Shelves.Find(id);
            if (shelf == null)
            {
                return HttpNotFound();
            }
            return View(shelf);
        }

        // GET: /Shelf/Create
        public ActionResult Create()
        {
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            return View();
        }

        // POST: /Shelf/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ShelfName,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] Shelf shelf)
        {
            if (ModelState.IsValid)
            {
                db.Shelves.Add(shelf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", shelf.CreatedBy);
            return View(shelf);
        }

        // GET: /Shelf/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shelf shelf = db.Shelves.Find(id);
            if (shelf == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", shelf.CreatedBy);
            return View(shelf);
        }

        // POST: /Shelf/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ShelfName,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] Shelf shelf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shelf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", shelf.CreatedBy);
            return View(shelf);
        }

        // GET: /Shelf/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shelf shelf = db.Shelves.Find(id);
            if (shelf == null)
            {
                return HttpNotFound();
            }
            return View(shelf);
        }

        // POST: /Shelf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shelf shelf = db.Shelves.Find(id);
            db.Shelves.Remove(shelf);
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
