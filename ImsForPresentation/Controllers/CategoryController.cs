using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImsForPresentation.Models;
using Microsoft.AspNet.Identity;

namespace ImsForPresentation.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Category/
        public ActionResult Index()
        {
            var categories = db.Categories.Include(u => u.ApplicationUser).Where(c => c.ActiveStatus == true);
            return View(categories);
        }

        //
        // GET: /Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Category/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create([Bind(Exclude = "ActiveStatus, CreatedBy, CreatedAt, UpdatedAt")] Category category, HttpPostedFileBase imgCategoryLogo) 
        {
            if (ModelState.IsValid)
            {
                if (imgCategoryLogo != null && imgCategoryLogo.ContentLength > 0)
                {
                    string path = Server.MapPath("~/Images/CategoryImages/" + imgCategoryLogo.FileName);
                    imgCategoryLogo.SaveAs(path);
                    category.CategoryLogo = imgCategoryLogo.FileName;
                }
                else
                {
                    category.CategoryLogo = "No Image Found";
                }

                string currentUser = User.Identity.GetUserId();

                category.ActiveStatus = true;
                category.CreatedAt = DateTime.Now;
                category.UpdatedAt = DateTime.Now;
                category.CreatedBy = currentUser;

                db.Categories.Add(category);
                db.SaveChanges();    
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
