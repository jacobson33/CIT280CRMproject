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
    public class ClientModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClientModels
        public ActionResult Index(int? sortId, int? page)
        {
            var model = from m in db.Client
                        select m;

            switch (sortId)
            {
                case 1:
                    model = model.OrderBy(i => i.CompanyName);
                    break;
                case 2:
                    model = model.OrderBy(i => i.State);
                    break;
                default:
                    model = model.OrderBy(i => i.ClientID);
                    break;
            }

            return View(model.ToPagedList((page ?? 1), 15));
        }

        // GET: ClientModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModels clientModels = db.Client.Find(id);
            if (clientModels == null)
            {
                return HttpNotFound();
            }

            ViewBag.PrimaryPhoneType = clientModels.Phone1Type.ToString();
            ViewBag.SecondaryPhoneType = clientModels.Phone2Type.ToString();

            if (clientModels.Phone1Type == 0) ViewBag.PrimaryPhoneType = "";
            if (clientModels.Phone2Type == 0) ViewBag.SecondaryPhoneType = "";

            return View(clientModels);
        }

        // GET: ClientModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,CompanyName,Address1,Address2,City,State,ZipCode,Phone1,Phone1Type,Phone2,Phone2Type,Email,EffDate,Active,DeleteInd")] ClientModels clientModels)
        {
            if (ModelState.IsValid)
            {
                db.Client.Add(clientModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientModels);
        }

        // GET: ClientModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModels clientModels = db.Client.Find(id);
            if (clientModels == null)
            {
                return HttpNotFound();
            }
            return View(clientModels);
        }

        // POST: ClientModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,CompanyName,Address1,Address2,City,State,ZipCode,Phone1,Phone1Type,Phone2,Phone2Type,Email,EffDate,Active,DeleteInd")] ClientModels clientModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientModels);
        }

        // GET: ClientModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModels clientModels = db.Client.Find(id);
            if (clientModels == null)
            {
                return HttpNotFound();
            }

            ViewBag.PrimaryPhoneType = clientModels.Phone1Type.ToString();
            ViewBag.SecondaryPhoneType = clientModels.Phone2Type.ToString();

            if (clientModels.Phone1Type == 0) ViewBag.PrimaryPhoneType = "";
            if (clientModels.Phone2Type == 0) ViewBag.SecondaryPhoneType = "";

            return View(clientModels);
        }

        // POST: ClientModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientModels clientModels = db.Client.Find(id);
            db.Client.Remove(clientModels);
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
