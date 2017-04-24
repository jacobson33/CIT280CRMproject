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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CIT280CRM.Controllers
{
    [AuthorizeOrRedirectAttribute(Roles="Admin,Staff")]
    public class InvoiceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public async Task<JsonResult> SaveLineItems(List<LineItemViewModel> LineItems)
        {
            if (ModelState.IsValid)
            {
                int invoiceId = LineItems.First().InvoiceID;
                db.SaleItem.RemoveRange(db.SaleItem.Where(s => s.InvoiceID == invoiceId));

                foreach (LineItemViewModel item in LineItems)
                {
                    SaleItemModels si = new SaleItemModels();
                    si.InvoiceID = item.InvoiceID;
                    si.ProductID = item.ProductID;
                    si.Quantity = item.Quantity;
                    si.Price = item.Price;

                    db.SaleItem.Add(si);
                }
                db.SaveChanges();
                return Json("Line Items saved");
            }
            else
            {
                return Json("Line Items not saved");
            }
        }

        [HttpPost]
        public ActionResult EditorRow(SaleItemModels model = null)
        {
            ViewBag.Products = db.Products.ToList().OrderBy(p => p.Name);

            if (model == null)
                return PartialView("EditorRow", new SaleItemModels());
            else
                return PartialView("EditorRow", model);
        }

        // Invoice Search Function
        public ViewResult Index(int? page, string searchTerm)
        {
            string searchPattern = @"^[0-9]+$";
            int searchID = 0;
            var invoice = from i in db.Invoice
                          select i;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                if (Regex.IsMatch(searchTerm, searchPattern))
                {
                    Convert.ToInt32(searchTerm);
                    searchID = 1;
                }

                else
                {
                    searchID = 2;
                }
            }

            switch (searchID)
            {
                case 1:
                    invoice = from i in db.Invoice.Include(i => i.ClientModels)
                              where i.PurchaseOrder == searchTerm
                              orderby i.ClientID
                              select i;
                    return View(invoice.ToPagedList((page ?? 1), 15));
                case 2:
                    invoice = from i in db.Invoice.Include(i => i.ClientModels)
                              where i.ClientModels.CompanyName == searchTerm
                              orderby i.ClientID
                              select i;
                    return View(invoice.ToPagedList((page ?? 1), 15));
                default:
                    invoice = db.Invoice.Include(i => i.ClientModels);
                    invoice = invoice.OrderBy(i => i.ClientID);
                    return View(invoice.ToPagedList((page ?? 1), 15));
            }
        }

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

            ClientModels client = db.Client.Find(invoiceModels.ClientID);

            ViewBag.LineItems = db.SaleItem.Where(li => li.InvoiceID == invoiceModels.InvoiceID).ToList();
            ViewBag.CompanyName = client.CompanyName;

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
        public ActionResult Create([Bind(Include = "InvoiceID,ClientID,PurchaseOrder")] InvoiceModels invoice)
        { 
            if (ModelState.IsValid)
            {
                invoice.InvoiceDate = DateTime.Now.ToString("MM/dd/yyyy");                

                db.Invoice.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Edit", "Invoice", new { id = invoice.InvoiceID });
            }

            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "CompanyName", invoice.ClientID);

            return View(invoice);
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
            ViewBag.InvoiceID = invoiceModels.InvoiceID;
            ViewBag.Products = db.Products.ToList().OrderBy(p => p.Name);

            invoiceModels.LineItems = db.SaleItem.Where(i => i.InvoiceID == invoiceModels.InvoiceID).ToList();

            return View(invoiceModels);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceID,ClientID,TotalAmount,PurchaseOrder,InvoiceStatus,InvoiceDate,ShipDate")] InvoiceModels invoice)
        {
            if (ModelState.IsValid)
            {
                if (db.Invoice.Any(i => i.InvoiceID == invoice.InvoiceID && (int)i.InvoiceStatus != 2 && (int)invoice.InvoiceStatus == 2)) {
                    invoice.ShipDate = DateTime.Now.ToString("MM/dd/yyyy");
                }
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "CompanyName", invoice.ClientID);
            return View(invoice);
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

            ClientModels client = db.Client.Find(invoiceModels.ClientID);
            ViewBag.CompanyName = client.CompanyName;

            return View(invoiceModels);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceModels invoiceModels = db.Invoice.Find(id);
            db.Invoice.Remove(invoiceModels);

            //TODO: Remove SaleItems from db when Invoice is removed
            //List<SaleItemModels> saleItems = db.SaleItem.Where(s => s.InvoiceID == invoiceModels.InvoiceID).ToList();
            //saleItems.ForEach(si => saleItems.Remove(si));

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
