using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImsForPresentation.Models;
using Microsoft.AspNet.Identity;

namespace ImsForPresentation.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ApplicationUser).Include(p => p.Brand).Include(p => p.Category).Include(p => p.FeaturePalette).Include(p => p.SiUnit);
            return View(products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            ViewBag.FeaturePaletteId = new SelectList(db.FeaturePalettes, "Id", "FeatureName");
            ViewBag.SiUnitId = new SelectList(db.SiUnits, "Id", "UnitName");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,ProductModel,CategoryId,BrandId,SiUnitId,FeaturePaletteId,Stock,ProductImage,Description,ActiveStatus")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = HttpContext.Server.MapPath("~/Images/ProductImages/" + file.FileName);
                    file.SaveAs(path);
                    product.ProductImage = file.FileName;
                }

                string currentUser = User.Identity.GetUserId();
                product.CreatedBy = currentUser;
                product.CreatedAt = DateTime.Now;
                product.UpdatedAt = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
            ViewBag.FeaturePaletteId = new SelectList(db.FeaturePalettes, "Id", "FeatureName", product.FeaturePaletteId);
            ViewBag.SiUnitId = new SelectList(db.SiUnits, "Id", "UnitName", product.SiUnitId);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
           
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
            ViewBag.FeaturePaletteId = new SelectList(db.FeaturePalettes, "Id", "FeatureName", product.FeaturePaletteId);
            ViewBag.SiUnitId = new SelectList(db.SiUnits, "Id", "UnitName", product.SiUnitId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,ProductModel,CategoryId,BrandId,SiUnitId,FeaturePaletteId,Stock,ProductImage,Description,ActiveStatus, CreatedAt")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = HttpContext.Server.MapPath("~/Images/BrandImages/" + file.FileName);
                    file.SaveAs(path);
                    product.ProductImage = file.FileName;
                }
                string currentUser = User.Identity.GetUserId();
                product.CreatedBy = currentUser;
                product.UpdatedAt = (DateTime)DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
            ViewBag.FeaturePaletteId = new SelectList(db.FeaturePalettes, "Id", "FeatureName", product.FeaturePaletteId);
            ViewBag.SiUnitId = new SelectList(db.SiUnits, "Id", "UnitName", product.SiUnitId);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
