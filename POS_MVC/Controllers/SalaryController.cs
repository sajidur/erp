using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Service.Service;
using Core.Interface.Service;
using Data.Repository;
using Validation.Validation;
using System.Data.Entity;
using RexERP_MVC.Models;
using RexERP_MVC.BAL;
using RexERP_MVC.ViewModel;
using System.Globalization;

namespace RexERP_MVC.Controllers
{

    public class SalaryController : Controller
    {
        private readonly static log4net.ILog LOG = log4net.LogManager.GetLogger("SalaryStandardController");
        private SalaryProcessService _employeeService = new SalaryProcessService();

        public ActionResult Index()
        {
            return View(this);
        }
        public ActionResult Process()
        {
            return View();
        }

        public ActionResult ProcessAttendance(int year, int month, int employeeId)
        {
            var allemployee = _employeeService.SalaryProcess(year,month,employeeId);          
            return Json(allemployee, JsonRequestBehavior.AllowGet);
        }
    }
}
