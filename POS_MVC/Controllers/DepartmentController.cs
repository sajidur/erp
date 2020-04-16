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
    public class DepartmentController : Controller
    {
        private DEPARTMENTService db = new DEPARTMENTService();
        public ActionResult Department()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DEPARTMENT category, int create)
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
            List<DEPARTMENT> products = db.GetAll();
            if (products == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<DEPARTMENT>, List<DEPARTMENTResponse>>(products);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT product = db.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<DEPARTMENT, DEPARTMENTResponse>(product);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(DEPARTMENT model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT product = db.GetById(model.DEPTID);
            if (product == null)
            {
                return HttpNotFound();
            }
            //model.IsActive = true;
            //model.UpdateDate = DateTime.Now;
            //model.UpdateBy = CurrentSession.GetCurrentSession().UserName;
            db.Update(model, model.DEPTID);
            return Json("Updated", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT product = db.GetById(id);
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