using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class ProducerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Producer/
        public ActionResult Index()
        {
            var producers = db.Producers.Include(p => p.ApplicationUser).Include(p => p.DifferentProducer);
            return View(producers.ToList());
        }

        // GET: /Producer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producer producer = db.Producers.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // GET: /Producer/Create
        public ActionResult Create()
        {
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            ViewBag.DifferentProducerId = new SelectList(db.DifferentProducers, "Id", "ProducerType");
            return View();
        }

        // POST: /Producer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DifferentProducerId,Name,Website,Contact,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                db.Producers.Add(producer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", producer.CreatedBy);
            ViewBag.DifferentProducerId = new SelectList(db.DifferentProducers, "Id", "ProducerType", producer.DifferentProducerId);
            return View(producer);
        }

        // GET: /Producer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producer producer = db.Producers.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", producer.CreatedBy);
            ViewBag.DifferentProducerId = new SelectList(db.DifferentProducers, "Id", "ProducerType", producer.DifferentProducerId);
            return View(producer);
        }

        // POST: /Producer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DifferentProducerId,Name,Website,Contact,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", producer.CreatedBy);
            ViewBag.DifferentProducerId = new SelectList(db.DifferentProducers, "Id", "ProducerType", producer.DifferentProducerId);
            return View(producer);
        }

        // GET: /Producer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producer producer = db.Producers.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // POST: /Producer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producer producer = db.Producers.Find(id);
            db.Producers.Remove(producer);
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
