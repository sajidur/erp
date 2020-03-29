using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class SizeSetupController : Controller
    {
        SizeService service = new SizeService();

        public ActionResult Index()
        {
            return View(new Design());
        }
        // GET: /Category/Details/5
        public ActionResult GetAll()
        {
            List<Design> category = service.GetAll();
            if (category == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<Design>, List<SizeResponse>>(category);
            return Json(category, JsonRequestBehavior.AllowGet);
        }
        // GET: /Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size category = service.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<Size, BrandResponse>(category);

            return View(category);
        }

        // GET: /Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Design category, int create)
        {
            var result = 0;
            if (ModelState.IsValid)
            {
                service.Save(category);
                return RedirectToAction("Index");
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}