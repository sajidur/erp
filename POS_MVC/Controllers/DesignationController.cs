using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class DesignationController : Controller
    {
        private DBService<Designationtbl> designationService = new DBService<Designationtbl>();
        private DBService<Department> deptService = new DBService<Department>();
        // GET: /Designation/
        public ActionResult Designation()
        {
            List<Department> products = deptService.GetAll();
            var depts= AutoMapper.Mapper.Map<List<DEPARTMENTResponse>>(products);
            DEPARTMENTResponse deptCompany = new DEPARTMENTResponse();
            deptCompany.Id = 0;
            deptCompany.Name = "Select";
            depts.Insert(0, deptCompany);
            ViewBag.DepartmentList = new SelectList(products, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Designationtbl category)
        {
            var result = category;
            if (ModelState.IsValid)
            {

                result = designationService.Save(category);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult List()
        {
            List<Designationtbl> products = designationService.GetAll();
            var depts = AutoMapper.Mapper.Map<List<DesignationtblResponse>>(products);
            return Json(depts,JsonRequestBehavior.AllowGet);
        }
    }
}