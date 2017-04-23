using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CIT280CRM.Models;

namespace CIT280CRM.Controllers
{
    [AuthorizeOrRedirectAttribute(Roles = "Admin, Staff")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.ToList();

            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModels productModels = db.Products.Find(id);
            if (productModels == null)
            {
                return HttpNotFound();
            }

            ViewBag.Category = db.Category.Find(productModels.CategoryID).Category;

            return View(productModels);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Category, "CategoryID", "Category");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,Price,CategoryID")] ProductModels productModels)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(productModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productModels);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModels productModels = db.Products.Find(id);
            if (productModels == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = new SelectList(db.Category, "CategoryID", "Category");

            return View(productModels);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,Price,CategoryID")] ProductModels productModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productModels);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModels productModels = db.Products.Find(id);
            if (productModels == null)
            {
                return HttpNotFound();
            }

            ViewBag.Category = db.Category.Find(productModels.CategoryID);

            return View(productModels);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductModels productModels = db.Products.Find(id);
            db.Products.Remove(productModels);
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
