using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RexERP_MVC.Models;

namespace RexERP_MVC.Controllers
{
    public class ShiftController : Controller
    {
        private Entities db = new Entities();

        // GET: Shift
        public ActionResult Index()
        {
            return View(db.SHIFTs.ToList());
        }

        // GET: Shift/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHIFT sHIFT = db.SHIFTs.Find(id);
            if (sHIFT == null)
            {
                return HttpNotFound();
            }
            return View(sHIFT);
        }

        // GET: Shift/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Startdate,EndDate,Active,InTime,OutTime")] SHIFT sHIFT)
        {
            if (ModelState.IsValid)
            {
                db.SHIFTs.Add(sHIFT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sHIFT);
        }

        // GET: Shift/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHIFT sHIFT = db.SHIFTs.Find(id);
            if (sHIFT == null)
            {
                return HttpNotFound();
            }
            return View(sHIFT);
        }

        // POST: Shift/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Startdate,EndDate,Active,InTime,OutTime")] SHIFT sHIFT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHIFT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sHIFT);
        }

        // GET: Shift/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHIFT sHIFT = db.SHIFTs.Find(id);
            if (sHIFT == null)
            {
                return HttpNotFound();
            }
            return View(sHIFT);
        }

        // POST: Shift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHIFT sHIFT = db.SHIFTs.Find(id);
            db.SHIFTs.Remove(sHIFT);
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
