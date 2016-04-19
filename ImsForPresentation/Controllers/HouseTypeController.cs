using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web;
using ImsForPresentation.Models;
using Microsoft.AspNet.Identity;

namespace ImsForPresentation.Controllers
{
    public class HouseTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: /HouseType/
        public ActionResult Index()
        {
            var housetypes = db.HouseTypes.Include(u => u.ApplicationUser).Where(h => h.ActiveStatus == true);
            return View(housetypes.ToList());
        }

        // GET: /HouseType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseType housetype = db.HouseTypes.Find(id);
            if (housetype == null)
            {
                return HttpNotFound();
            }
            return View(housetype);
        }

        // GET: /HouseType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /HouseType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "ActiveStatus, CreatedBy, CreatedAt, UpdatedAt")] HouseType housetype, HttpPostedFileBase imgHouseTypeLogo)
        {
            if (ModelState.IsValid)
            {

                GetLogoName(housetype, imgHouseTypeLogo, "Image Not Found");

                string currentUser = User.Identity.GetUserId();

                housetype.ActiveStatus = true;
                housetype.CreatedAt = DateTime.Now;
                housetype.UpdatedAt = DateTime.Now;
                housetype.CreatedBy = currentUser;

                db.HouseTypes.Add(housetype);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(housetype);
        }

        private void GetLogoName(HouseType housetype, HttpPostedFileBase imgLogo, string emptyMessage)
        {
            if (imgLogo != null && imgLogo.ContentLength > 0)
            {
                string path = Server.MapPath("~/Images/HouseImages/" + imgLogo.FileName);
                imgLogo.SaveAs(path);
                housetype.Logo = imgLogo.FileName;
            }
            else
            {
                housetype.Logo = emptyMessage;
            }
        }

        // GET: /HouseType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseType housetype = db.HouseTypes.Find(id);
            if (housetype == null)
            {
                return HttpNotFound();
            }

            Session["CreatedBy"] = housetype.CreatedBy;
            Session["CreatedAt"] = housetype.CreatedAt;
            Session["Logo"] = housetype.Logo;

            return View(housetype);
        }

        // POST: /HouseType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "CreatedBy, CreatedAt, UpdatedAt")] HouseType housetype, HttpPostedFileBase imgHouseTypeLogo)
        {
            if (ModelState.IsValid)
            {

                GetLogoName(housetype, imgHouseTypeLogo, (string)Session["Logo"]);

                housetype.UpdatedAt = DateTime.Now;
                housetype.CreatedBy = (string)Session["CreatedBy"];
                Session.Remove("CreatedBy");
                housetype.CreatedAt = (DateTime)Session["CreatedAt"];
                Session.Remove("CreatedAt");
                Session.Remove("Logo");

                db.Entry(housetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CreatedBy = new SelectList(db.IdentityUsers, "Id", "UserName", housetype.CreatedBy);
            return View(housetype);
        }

        // GET: /HouseType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseType housetype = db.HouseTypes.Find(id);
            if (housetype == null)
            {
                return HttpNotFound();
            }
            return View(housetype);
        }

        // POST: /HouseType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseType housetype = db.HouseTypes.Find(id);
            db.HouseTypes.Remove(housetype);
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
