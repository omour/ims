using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class DifferentProducerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /DifferentProducer/
        public ActionResult Index()
        {
            var differentproducers = db.DifferentProducers.Include(d => d.ApplicationUser);
            return View(differentproducers.ToList());
        }

        // GET: /DifferentProducer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DifferentProducer differentproducer = db.DifferentProducers.Find(id);
            if (differentproducer == null)
            {
                return HttpNotFound();
            }
            return View(differentproducer);
        }

        // GET: /DifferentProducer/Create
        public ActionResult Create()
        {
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            return View();
        }

        // POST: /DifferentProducer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProducerType,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] DifferentProducer differentproducer)
        {
            if (ModelState.IsValid)
            {
                db.DifferentProducers.Add(differentproducer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", differentproducer.CreatedBy);
            return View(differentproducer);
        }

        // GET: /DifferentProducer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DifferentProducer differentproducer = db.DifferentProducers.Find(id);
            if (differentproducer == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", differentproducer.CreatedBy);
            return View(differentproducer);
        }

        // POST: /DifferentProducer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProducerType,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] DifferentProducer differentproducer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(differentproducer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", differentproducer.CreatedBy);
            return View(differentproducer);
        }

        // GET: /DifferentProducer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DifferentProducer differentproducer = db.DifferentProducers.Find(id);
            if (differentproducer == null)
            {
                return HttpNotFound();
            }
            return View(differentproducer);
        }

        // POST: /DifferentProducer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DifferentProducer differentproducer = db.DifferentProducers.Find(id);
            db.DifferentProducers.Remove(differentproducer);
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
