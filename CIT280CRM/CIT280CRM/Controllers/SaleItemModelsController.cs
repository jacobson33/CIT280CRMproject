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
    public class SaleItemModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SaleItemModels
        public ActionResult Index()
        {
            return View(db.SaleItem.ToList());
        }

        // GET: SaleItemModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleItemModels saleItemModels = db.SaleItem.Find(id);
            if (saleItemModels == null)
            {
                return HttpNotFound();
            }
            return View(saleItemModels);
        }

        // GET: SaleItemModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleItemModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleItemID,ProductID,InvoiceID,Quantity,Price")] SaleItemModels saleItemModels)
        {
            if (ModelState.IsValid)
            {
                db.SaleItem.Add(saleItemModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saleItemModels);
        }

        // GET: SaleItemModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleItemModels saleItemModels = db.SaleItem.Find(id);
            if (saleItemModels == null)
            {
                return HttpNotFound();
            }
            return View(saleItemModels);
        }

        // POST: SaleItemModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleItemID,ProductID,InvoiceID,Quantity,Price")] SaleItemModels saleItemModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleItemModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saleItemModels);
        }

        // GET: SaleItemModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleItemModels saleItemModels = db.SaleItem.Find(id);
            if (saleItemModels == null)
            {
                return HttpNotFound();
            }
            return View(saleItemModels);
        }

        // POST: SaleItemModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleItemModels saleItemModels = db.SaleItem.Find(id);
            db.SaleItem.Remove(saleItemModels);
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
