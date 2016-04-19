using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ImsForPresentation.Models;

namespace ImsForPresentation.Controllers
{
    public class MessageStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /MessageStatus/
        public ActionResult Index()
        {
            var messagestatuses = db.MessageStatuses.Include(m => m.ApplicationUser);
            return View(messagestatuses.ToList());
        }

        // GET: /MessageStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageStatus messagestatus = db.MessageStatuses.Find(id);
            if (messagestatus == null)
            {
                return HttpNotFound();
            }
            return View(messagestatus);
        }

        // GET: /MessageStatus/Create
        public ActionResult Create()
        {
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName");
            return View();
        }

        // POST: /MessageStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,StatusValue,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] MessageStatus messagestatus)
        {
            if (ModelState.IsValid)
            {
                db.MessageStatuses.Add(messagestatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", messagestatus.CreatedBy);
            return View(messagestatus);
        }

        // GET: /MessageStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageStatus messagestatus = db.MessageStatuses.Find(id);
            if (messagestatus == null)
            {
                return HttpNotFound();
            }
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", messagestatus.CreatedBy);
            return View(messagestatus);
        }

        // POST: /MessageStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,StatusValue,Description,ActiveStatus,CreatedBy,CreatedAt,UpdatedAt")] MessageStatus messagestatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messagestatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
//            ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", messagestatus.CreatedBy);
            return View(messagestatus);
        }

        // GET: /MessageStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageStatus messagestatus = db.MessageStatuses.Find(id);
            if (messagestatus == null)
            {
                return HttpNotFound();
            }
            return View(messagestatus);
        }

        // POST: /MessageStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageStatus messagestatus = db.MessageStatuses.Find(id);
            db.MessageStatuses.Remove(messagestatus);
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
