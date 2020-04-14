using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;

namespace RexERP_MVC.Controllers
{
    public class UsersController : Controller
    {
        private Entities db = new Entities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.UserRole);
            return View(users.ToList());
        }
        public ActionResult Users()
        {
            var users = db.Users.ToList();
            var usersRes = AutoMapper.Mapper.Map<List<UserInfoResponse>>(users);
            return Json(usersRes,JsonRequestBehavior.AllowGet);
        }
        public ActionResult MenuPermission()
        {
            return View();
        }
        public ActionResult CreateRoles()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRoles([Bind(Include = "RoleName")] UserRole role)
        {
            role.TenancyId = 1;
            role.SetDate = DateTime.Now;
            db.UserRoles.Add(role);
            db.SaveChanges();
            return RedirectToAction("MenuPermission");
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.UserRoleId = new SelectList(db.UserRoles, "Id", "RoleName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,UserPassword,UserRoleId,UserStatus,SetDate,ModifyUser,BranchId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserRoleId = new SelectList(db.UserRoles, "Id", "RoleName", user.UserRoleId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserRoleId = new SelectList(db.UserRoles, "Id", "RoleName", user.UserRoleId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,UserPassword,UserRoleId,UserStatus,SetDate,ModifyUser,BranchId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserRoleId = new SelectList(db.UserRoles, "Id", "RoleName", user.UserRoleId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Users/Delete/5
        [HttpGet, ActionName("Screen")]
        public ActionResult Screen()
        {
            var screen = db.Screens.ToList();
            var response = AutoMapper.Mapper.Map<List<MenuResponse>>(screen);
            return Json(response,JsonRequestBehavior.AllowGet);
        }

        // POST: Users/Delete/5
        [HttpGet, ActionName("Roles")]
        public ActionResult Roles()
        {
            var permission = db.UserRoles.ToList();
            var response = AutoMapper.Mapper.Map<List<UserRoleResponse>>(permission);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MenuUsers()
        {
            var permission = db.RoleWiseScreenPermissions.ToList();
            return Json(permission,JsonRequestBehavior.AllowGet);
        }


        // POST: Users/Delete/5
        [HttpPost, ActionName("MenuPermission")]
        public ActionResult MenuPermission([Bind(Include = "RoleId,ScreenId")] RoleWiseScreenPermission roleWiseScreen)
        {
            var permission = db.RoleWiseScreenPermissions.Where(a => a.RoleId == roleWiseScreen.RoleId && a.ScreenId == roleWiseScreen.ScreenId).FirstOrDefault();
            if (permission==null)
            {
                db.RoleWiseScreenPermissions.Add(roleWiseScreen);
                db.SaveChanges();
                return Json("Sucess", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Already Exists", JsonRequestBehavior.AllowGet);

            }
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
