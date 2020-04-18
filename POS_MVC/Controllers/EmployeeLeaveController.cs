using Core.Interface.Service;
using Data.Repository;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.ResponseModel;
using RexERP_MVC.Util;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validation.Validation;
namespace RexERP_MVC.Controllers
{
    public class EmployeeLeaveController : Controller
    {
        private readonly static log4net.ILog LOG = log4net.LogManager.GetLogger("EmployeeLeaveController");
        public IEmployeeLeaveService _employeeLeaveService;
        public EmployeeService _employeeService;
        public ISalaryItemService _salaryItemService;
        public ISalaryStandardDetailService _salaryStandardDetailService;

        public EmployeeLeaveController()
        {
            _employeeLeaveService = new EmployeeLeaveService(new EmployeeLeaveRepository(), new EmployeeLeaveValidator());
            _employeeService = new EmployeeService();
            _salaryItemService = new SalaryItemService(new SalaryItemRepository(), new SalaryItemValidator());
            _salaryStandardDetailService = new SalaryStandardDetailService(new SalaryStandardDetailRepository(), new SalaryStandardDetailValidator());
        }

        public ActionResult Index()
        {
            return View(this);
        }

        public dynamic GetList(string _search, long nd, int rows, int? page, string sidx, string sord, string filters = "", int ParentId = 0)
        {
            // Construct where statement
            string strWhere = GeneralFunction.ConstructWhere(filters);
            string filter = null;
            GeneralFunction.ConstructWhereInLinq(strWhere, out filter);
            if (filter == "") filter = "true";

            // Get Data
            var q = _employeeLeaveService.GetQueryable().Include("Employee").Include("EmployeeLeaveDetails").Include("TitleInfo");

            var query = (from model in q
                         select new
                         {
                             model.Id,
                             model.EmployeeId,
                             EmployeeName = model.Employee.FirstName+" "+model.Employee.LastName,
                             model.StartDate,
                             model.EndDate,
                             model.Remark,
                             model.CreatedAt,
                             model.UpdatedAt,
                         }).OrderBy(a=>a.Id); //.ToList();

            var list = query.AsEnumerable();

            var pageIndex = Convert.ToInt32(page) - 1;
            var pageSize = rows;
            var totalRecords = query.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
            // default last page
            if (totalPages > 0)
            {
                if (!page.HasValue)
                {
                    pageIndex = totalPages - 1;
                    page = totalPages;
                }
            }

            list = list.Skip(pageIndex * pageSize).Take(pageSize);

            return Json(new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = (
                    from model in list
                    select new
                    {
                        id = model.Id,
                        cell = new object[] {
                             model.Id,
                             model.EmployeeId,
                             model.EmployeeName,
                             model.StartDate,
                             model.EndDate,
                             model.Remark,
                             model.CreatedAt,
                             model.UpdatedAt,
                      }
                    }).ToArray()
            }, JsonRequestBehavior.AllowGet);
        }


        public dynamic GetInfo(int Id)
        {
            EmployeeLeave model = new EmployeeLeave();
            try
            {
                model = _employeeLeaveService.GetObjectById(Id);
            }
            catch (Exception ex)
            {
                LOG.Error("GetInfo", ex);
                Dictionary<string, string> Errors = new Dictionary<string, string>();
                Errors.Add("Generic", "Error " + ex);

                return Json(new
                {
                    Errors
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                model.Id,
                model.EmployeeId,
                EmployeeName = model.Employee.FirstName,
                model.StartDate,
                model.EndDate,
                model.Remark
            }, JsonRequestBehavior.AllowGet);
        }

        public dynamic GetDefaultInfo()
        {
            EmployeeLeave model = new EmployeeLeave();
            try
            {
                model = _employeeLeaveService.GetQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                LOG.Error("GetInfo", ex);
                Dictionary<string, string> Errors = new Dictionary<string, string>();
                Errors.Add("Generic", "Error " + ex);

                return Json(new
                {
                    Errors
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                model.Id,
                model.EmployeeId,
                model.StartDate,
                model.EndDate,
                model.Remark
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public dynamic Insert(EmployeeLeave model)
        {
            var res = new BaseResponse() { };
            try
            {
                model = _employeeLeaveService.CreateObject(model, _employeeService);
                res.MessageId = 1;
                res.Message = "Data Saved Sucess";
            }
            catch (Exception ex)
            {
                LOG.Error("Insert Failed", ex);
                res.MessageId = 1;
                res.Message = "Data Saved failed";
                res.Data = ex;
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public dynamic Update(EmployeeLeave model)
        {
            try
            {
               
                var data = _employeeLeaveService.GetObjectById(model.Id);
                data.EmployeeId = model.EmployeeId;
                data.StartDate = model.StartDate;
                data.EndDate = model.EndDate;
                data.Remark = model.Remark;
                model = _employeeLeaveService.UpdateObject(data, _employeeService);
            }
            catch (Exception ex)
            {
                LOG.Error("Update Failed", ex);
                Dictionary<string, string> Errors = new Dictionary<string, string>();
                Errors.Add("Generic", "Error " + ex);

                return Json(new
                {
                    Errors
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
              //  model.Errors
            });
        }

        [HttpPost]
        public dynamic Delete(EmployeeLeave model)
        {
            try
            {
               

                var data = _employeeLeaveService.GetObjectById(model.Id);
                model = _employeeLeaveService.SoftDeleteObject(data);
            }

            catch (Exception ex)
            {
                LOG.Error("Delete Failed", ex);
                Dictionary<string, string> Errors = new Dictionary<string, string>();
                Errors.Add("Generic", "Error " + ex);

                return Json(new
                {
                    Errors
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
               // model.Errors
            });
        }





    }
}