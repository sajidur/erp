﻿using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        BrandService service = new BrandService();

        public ActionResult Index()
        {
            return View(new Brand());
        }
        // GET: /Category/Details/5
        public ActionResult GetAll()
        {
            List<Brand> category = service.GetAll();
            if (category == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<Brand>, List<BrandResponse>>(category);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // GET: /Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand category = service.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<Brand, BrandResponse>(category);

            return View(category);
        }

        // GET: /Category/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: /Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Brand category, int create)
        {
            var result = 0;
            if (ModelState.IsValid)
            {
                service.Save(category);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}