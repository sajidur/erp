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
        // GET: /Designation/
        public ActionResult Designation()
        {
            //List<DEPARTMENTResponse> resultCompany = null;
            List<Designationtbl> products = designationService.GetAll();
            var depts= AutoMapper.Mapper.Map<List<DEPARTMENTResponse>>(products);
            //resultCompany = Mapper.Map<IEnumerable<DEPARTMENT>, IEnumerable<DEPARTMENTResponse>>(products).ToList();
            DEPARTMENTResponse objCompany = new DEPARTMENTResponse();
            objCompany.Id = 0;
            objCompany.Name = "Select";
            depts.Insert(0, objCompany);
            ViewBag.DepartmentList = new SelectList(products, "Id", "DEPTNAME");
            return View();
        }
	}
}