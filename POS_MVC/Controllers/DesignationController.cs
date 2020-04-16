using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class DesignationController : Controller
    {
        private DEPARTMENTService dbDepartment = new DEPARTMENTService();
        // GET: /Designation/
        public ActionResult Designation()
        {
            //List<DEPARTMENTResponse> resultCompany = null;
            //List<DEPARTMENT> products = dbDepartment.GetAll();
            //resultCompany = Mapper.Map<IEnumerable<DEPARTMENT>, IEnumerable<DEPARTMENTResponse>>(products).ToList();
            //DEPARTMENTResponse objCompany = new DEPARTMENTResponse();
            ////objCompany.DEPTID = 0;
            ////objCompany.DEPTNAME = "Select";
            ////products.Insert(0, objCompany);
            //ViewBag.DepartmentList = new SelectList(products, "DEPTID", "DEPTNAME");

            return View();
        }
	}
}