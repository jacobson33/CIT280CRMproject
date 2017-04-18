using CIT280CRM.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CIT280CRM.Controllers
{
    public class IdentityRoleController : Controller
    {
        // GET: IdentityRole
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IdentityRoles
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: IdentityRoles/Details/5
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: IdentityRoles/Create
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: IdentityRoles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ID,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: IdentityRoles/Edit/5
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: IdentityRoles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ID, Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: IdentityRoles/Delete/5
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: IdentityRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult DeleteConfirmed(string id)
        {
            IdentityRole identityRoleTemp = db.Roles.Find(id);
            db.Roles.Remove(identityRoleTemp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult ViewUserRoles(string userName = null)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                List<string> userRoles;
                //List<string> roles;
                //List<string> users;
                using (var context = new ApplicationDbContext())
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);

                    //roles = (from r in roleManager.Roles select r.Name).ToList();

                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore);

                    //users = (from u in userManager.Users select u.UserName).ToList();

                    var user = userManager.FindByName(userName);
                    if (user == null)
                        throw new Exception("User not found!");

                    var userRoleIds = (from r in user.Roles select r.RoleId);
                    userRoles = (from id in userRoleIds
                                 let r = roleManager.FindById(id)
                                 select r.Name).ToList();
                }

                //ViewBag.Roles = new SelectList(roles);
                //ViewBag.Users = new SelectList(users);
                ViewBag.UserName = userName;
                ViewBag.RolesForThisUser = userRoles;
            }
            return View();
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