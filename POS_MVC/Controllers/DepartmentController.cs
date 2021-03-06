﻿using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private DEPARTMENTService db = new DEPARTMENTService();
        public ActionResult Department()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department category, int create)
        {
            var result = category;
            if (ModelState.IsValid)
            {
               
                result = db.Save(category);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAll()
        {
            List<Department> products = db.GetAll();
            if (products == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<Department>, List<DEPARTMENTResponse>>(products);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department product = db.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<Department, DEPARTMENTResponse>(product);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department product = db.GetById(model.Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            //model.IsActive = true;
            //model.UpdateDate = DateTime.Now;
            //model.UpdateBy = CurrentSession.GetCurrentSession().UserName;
            db.Update(model, model.Id);
            return Json("Updated", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department product = db.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
           // product.IsActive = false;
            db.Update(product, id ?? 0);
            //int delete = db.Delete(id ?? 0);
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
	}
}