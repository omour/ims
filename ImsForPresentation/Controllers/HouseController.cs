using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class HouseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /House/
        public ActionResult Index()
        {
            var houses = db.Houses.Include(h => h.ApplicationUser).Include(h => h.HouseType);
            return View(houses.ToList());
        }

        // GET: /House/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // GET: /House/Create
        public ActionResult Create()
        {
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            ViewBag.HouseTypeId = new SelectList(db.HouseTypes, "Id", "House");
            return View();
        }

        // POST: /House/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,HouseTypeId,Name,Address,WebSiteUrl,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Add(house);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", house.CreatedBy);
            ViewBag.HouseTypeId = new SelectList(db.HouseTypes, "Id", "House", house.HouseTypeId);
            return View(house);
        }

        // GET: /House/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", house.CreatedBy);
            ViewBag.HouseTypeId = new SelectList(db.HouseTypes, "Id", "House", house.HouseTypeId);
            return View(house);
        }

        // POST: /House/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,HouseTypeId,Name,Address,WebSiteUrl,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", house.CreatedBy);
            ViewBag.HouseTypeId = new SelectList(db.HouseTypes, "Id", "House", house.HouseTypeId);
            return View(house);
        }

        // GET: /House/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: /House/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House house = db.Houses.Find(id);
            db.Houses.Remove(house);
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
