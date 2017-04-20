using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using CIT280CRM.Models;

namespace CIT280CRM.Controllers
{
    [AuthorizeOrRedirectAttribute(Roles="Admin,Staff")]
    public class InvoiceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public ActionResult EditorRow()
        {
            return PartialView("EditorRow", new SaleItemModels());
        }

        public ViewResult Index(int? page, string searchTerm)
        { 

            int searchID = 0;
            var invoice = from i in db.Invoice
                          select i;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                Convert.ToInt32(searchTerm);
                searchID = 1;
            }

            switch (searchID)
            {
                case 1:
                    invoice = from i in db.Invoice.Include(i => i.ClientModels)
                              where i.PurchaseOrder == searchTerm
                              orderby i.ClientID
                              select i;
                    return View(invoice.ToPagedList((page ?? 1), 15));
                default:
                    invoice = db.Invoice.Include(i => i.ClientModels);
                    invoice = invoice.OrderBy(i => i.ClientID);
                    return View(invoice.ToPagedList((page ?? 1), 15));
            }
        }

        // GET: Invoice
        //public ActionResult Index(int? sortId, int? page, string filter)
        //{
        //    var invoice = db.Invoice.Include(i => i.ClientModels);

        //    if (filter != null)
        //        invoice = invoice.Where(i => i.PurchaseOrder == filter);

        //    switch (sortId)
        //    {
        //        case 1:
        //            invoice = invoice.OrderBy(i => i.ClientModels.CompanyName);
        //            break;
        //        case 2:
        //            invoice = invoice.OrderBy(i => i.TotalAmount);
        //            break;
        //        case 3:
        //            invoice = invoice.OrderBy(i => i.PurchaseOrder);
        //            break;
        //        case 4:
        //            invoice = invoice.OrderBy(i => i.InvoiceDate);
        //            break;
        //        case 5:
        //            invoice = invoice.OrderBy(i => i.ShipDate);
        //            break;
        //        default:
        //            invoice = invoice.OrderBy(i => i.InvoiceID);
        //            break;
        //    }

        //    return View(invoice.ToPagedList((page ?? 1), 15));
        //}

        // GET: Invoice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceModels invoiceModels = db.Invoice.Find(id);
            if (invoiceModels == null)
            {
                return HttpNotFound();
            }
            return View(invoiceModels);
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "CompanyName");

            var model = new InvoiceModels();
            return View(model);
        }

        // POST: Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceID,ClientID,TotalAmount,PurchaseOrder,InvoiceDate,ShipDate,InvoiceStatus")] InvoiceModels invoiceModels)
        {
            if (ModelState.IsValid)
            {
                db.Invoice.Add(invoiceModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "CompanyName", invoiceModels.ClientID);
            return View(invoiceModels);
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceModels invoiceModels = db.Invoice.Find(id);
            if (invoiceModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "CompanyName", invoiceModels.ClientID);
            return View(invoiceModels);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceID,ClientID,TotalAmount,PurchaseOrder,InvoiceDate,ShipDate,InvoiceStatus")] InvoiceModels invoiceModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "CompanyName", invoiceModels.ClientID);
            return View(invoiceModels);
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceModels invoiceModels = db.Invoice.Find(id);
            if (invoiceModels == null)
            {
                return HttpNotFound();
            }
            return View(invoiceModels);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceModels invoiceModels = db.Invoice.Find(id);
            db.Invoice.Remove(invoiceModels);
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
