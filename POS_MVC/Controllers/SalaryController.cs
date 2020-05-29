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
        public ITitleInfoService _titleInfoService;
        private EmployeeService _employeeService = new EmployeeService();
        private IEmployeeAttendanceService _attendanceService;
        private IEmployeeLeaveService _leaveService;
        private DBService<HOLIDAY> _holyDayService = new DBService<HOLIDAY>();
        private BonusDeductionService _bonusDeductionService = new BonusDeductionService();
        public SalaryController()
        {
            _titleInfoService = new TitleInfoService(new TitleInfoRepository(), new TitleInfoValidator());
             _attendanceService = new EmployeeAttendanceService(new EmployeeAttendanceRepository(),new EmployeeAttendanceValidator());
            _leaveService = new EmployeeLeaveService(new EmployeeLeaveRepository(), new EmployeeLeaveValidator());
        }

        public ActionResult Index()
        {
            //if (!AuthenticationModel.IsAllowed("View", Core.Constants.Constant.MenuName.SalaryStandard, Core.Constants.Constant.MenuGroupName.Setting))
            //{
            //    return Content(Core.Constants.Constant.ErrorPage.PageViewNotAllowed);
            //}

            return View(this);
        }
        public ActionResult Process()
        {
            return View();
        }

        public ActionResult GetAttendance(int year, int month, int employeeId)
        {
            var employeeSalaryProcessResponse = new List<EmployeeSalaryProcessViewResponse>();
            var allemployee = _employeeService.GetAll();
            var employeeIds = allemployee.Select(a => a.Id).ToList();
            var attendance = _attendanceService.GetAttendanceCount(year,month);
            var leave = _leaveService.GetAll(employeeIds);
            var bonusDeductionList = _bonusDeductionService.GetAll(month,year);
            foreach (var item in allemployee)
            {
                var holyDays = _holyDayService.GetAll(a => a.HOLIDAYMONTH == month && a.HOLIDAYYEAR==year).ToList();
                var holyDaysCount = 0;
                if (holyDays!=null)
                {
                    holyDaysCount = holyDays.Sum(a => a.DURATION ?? 0);
                }
                var dayInMonth = DateTime.DaysInMonth(year, month);
                var attendanceCount = attendance.Where(a => a.EmployeeId == item.Id);
               // var lateCount=attendanceCount.Select(a=>a.)
                var leaveCount = leave.Where(a => a.EmployeeId == item.Id).Count();
                var bonusOrDeduction = bonusDeductionList.Where(a => a.EmployeeId == item.Id).ToList();
                var response = new EmployeeSalaryProcessViewResponse();
                response.Id = item.Id;
                response.FirstName = item.FirstName;
                response.LastName = item.LastName;
                response.Code = item.Code;
                response.DesignationName = item.Designationtbl.DesignationName;
                response.DepartmentName = item.Department.Name;
                response.AttendanceCount = attendanceCount.Count();
                response.LeaveCount = leaveCount;
                response.LateCount = attendanceCount.Where(a => a.CheckLateMinutes > 15).Count();
                response.AbsenceCount = dayInMonth-(holyDaysCount + attendanceCount.Count()+leaveCount);
                response.DeductionAmount = bonusOrDeduction.Select(a=>a.DeductionAmount??0).Sum();
                response.AdditionAmount = bonusOrDeduction.Select(a => a.BonusAmount ?? 0).Sum();
                employeeSalaryProcessResponse.Add(response);
            }
            return Json(employeeSalaryProcessResponse, JsonRequestBehavior.AllowGet);
        }


        //public dynamic GetList(string _search, long nd, int rows, int? page, string sidx, string sord, string filters = "", int ParentId = 0)
        //{
        //    // Construct where statement
        //    string strWhere = GeneralFunction.ConstructWhere(filters);
        //    string filter = null;
        //    GeneralFunction.ConstructWhereInLinq(strWhere, out filter);
        //    if (filter == "") filter = "true";

        //    // Get Data
        //    var q = _salaryStandardService.GetQueryable().Include("TitleInfo").Include("SalaryStandardDetails");

        //    var query = (from model in q
        //                 select new
        //                 {
        //                     model.Id,
        //                     model.TitleInfoId,
        //                     TitleInfoName = model.TitleInfo.Name,
        //                     model.EffectiveDate,
        //                     model.Description,
        //                     model.CreatedAt,
        //                     model.UpdatedAt,
        //                 }).Where(filter).OrderBy(sidx + " " + sord); //.ToList();

        //    var list = query.AsEnumerable();

        //    var pageIndex = Convert.ToInt32(page) - 1;
        //    var pageSize = rows;
        //    var totalRecords = query.Count();
        //    var totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
        //    // default last page
        //    if (totalPages > 0)
        //    {
        //        if (!page.HasValue)
        //        {
        //            pageIndex = totalPages - 1;
        //            page = totalPages;
        //        }
        //    }

        //    list = list.Skip(pageIndex * pageSize).Take(pageSize);

        //    return Json(new
        //    {
        //        total = totalPages,
        //        page = page,
        //        records = totalRecords,
        //        rows = (
        //            from model in list
        //            select new
        //            {
        //                id = model.Id,
        //                cell = new object[] {
        //                     model.Id,
        //                     model.TitleInfoId,
        //                     model.TitleInfoName,
        //                     model.EffectiveDate,
        //                     model.Description,
        //                     model.CreatedAt,
        //                     model.UpdatedAt,
        //              }
        //            }).ToArray()
        //    }, JsonRequestBehavior.AllowGet);
        //}

        //public dynamic GetListDynamic(string _search, long nd, int rows, int? page, string sidx, string sord, string filters = "", int ParentId = 0)
        //{
        //    // Construct where statement
        //    string strWhere = GeneralFunction.ConstructWhere(filters);
        //    string filter = null;
        //    GeneralFunction.ConstructWhereInLinq(strWhere, out filter);
        //    if (filter == "") filter = "true";

        //    // Get Data
        //    var q = _salaryStandardService.GetQueryable().Include("TitleInfo").Include("SalaryStandardDetails");

        //    var query = (from model in q
        //                 select new
        //                 {
        //                     model.Id,
        //                     model.TitleInfoId,
        //                     TitleInfoName = model.TitleInfo.Name,
        //                     model.EffectiveDate,
        //                     model.Description,
        //                     model.CreatedAt,
        //                     model.UpdatedAt,
        //                 }).Where(filter).OrderBy(sidx + " " + sord); //.ToList();

        //    var list = query.AsEnumerable();

        //    var pageIndex = Convert.ToInt32(page) - 1;
        //    var pageSize = rows;
        //    var totalRecords = query.Count();
        //    var totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
        //    // default last page
        //    if (totalPages > 0)
        //    {
        //        if (!page.HasValue)
        //        {
        //            pageIndex = totalPages - 1;
        //            page = totalPages;
        //        }
        //    }

        //    list = list.Skip(pageIndex * pageSize).Take(pageSize);

        //    return Json(new
        //    {
        //        total = totalPages,
        //        page = page,
        //        records = totalRecords,
        //        rows = list
        //    }, JsonRequestBehavior.AllowGet);
        //}


        public dynamic GetInfo(int Id)
        {
            SalaryStandard model = new SalaryStandard();
            try
            {
               // model = _salaryStandardService.GetObjectById(Id);
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
                model.TitleInfoId,
                TitleInfoName = model.TitleInfo.Name,
                model.EffectiveDate,
                model.Description//,
             //   model.Errors
            }, JsonRequestBehavior.AllowGet);
        }

        public dynamic GetDefaultInfo()
        {
            SalaryStandard model = new SalaryStandard();
            try
            {
               // model = _salaryStandardService.GetQueryable().FirstOrDefault();
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
                model.TitleInfoId,
                TitleInfoName = model.TitleInfo.Name,
                model.EffectiveDate,
                model.Description//,
               // model.Errors
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public dynamic Insert(SalaryStandard model)
        {
            try
            {
                //if (!AuthenticationModel.IsAllowed("Create", Core.Constants.Constant.MenuName.SalaryStandard, Core.Constants.Constant.MenuGroupName.Setting))
                //{
                //    Dictionary<string, string> Errors = new Dictionary<string, string>();
                //    Errors.Add("Generic", "You are Not Allowed to Add record");

                //    return Json(new
                //    {
                //        Errors
                //    }, JsonRequestBehavior.AllowGet);
                //}

              //  model = _salaryStandardService.CreateObject(model, _titleInfoService, _salaryStandardDetailService, _salaryItemService);
            }
            catch (Exception ex)
            {
                LOG.Error("Insert Failed", ex);
                Dictionary<string, string> Errors = new Dictionary<string, string>();
                Errors.Add("Generic", "Error " + ex);

                return Json(new
                {
                    Errors
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
             //   model.Errors
            });
        }

        [HttpPost]
        public dynamic Update(SalaryStandard model)
        {
            try
            {
                //if (!AuthenticationModel.IsAllowed("Edit", Core.Constants.Constant.MenuName.SalaryStandard, Core.Constants.Constant.MenuGroupName.Setting))
                //{
                //    Dictionary<string, string> Errors = new Dictionary<string, string>();
                //    Errors.Add("Generic", "You are Not Allowed to Edit record");

                //    return Json(new
                //    {
                //        Errors
                //    }, JsonRequestBehavior.AllowGet);
                //}

              //  var data = _salaryStandardService.GetObjectById(model.Id);
              //  data.TitleInfoId = model.TitleInfoId;
              //  data.EffectiveDate = model.EffectiveDate;
              //  data.Description = model.Description;
              //  model = _salaryStandardService.UpdateObject(data, _titleInfoService);
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
        public dynamic Delete(SalaryStandard model)
        {
            try
            {
                //if (!AuthenticationModel.IsAllowed("Delete", Core.Constants.Constant.MenuName.SalaryStandard, Core.Constants.Constant.MenuGroupName.Setting))
                //{
                //    Dictionary<string, string> Errors = new Dictionary<string, string>();
                //    Errors.Add("Generic", "You are Not Allowed to Delete Record");

                //    return Json(new
                //    {
                //        Errors
                //    }, JsonRequestBehavior.AllowGet);
                //}

            //    var data = _salaryStandardService.GetObjectById(model.Id);
            //    model = _salaryStandardService.SoftDeleteObject(data);
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
              //  model.Errors
            });
        }


        //public dynamic GetListDetail(string _search, long nd, int rows, int? page, string sidx, string sord, int id, string filters = "")
        //{
        //    // Construct where statement
        //    string strWhere = GeneralFunction.ConstructWhere(filters);
        //    string filter = null;
        //    GeneralFunction.ConstructWhereInLinq(strWhere, out filter);
        //    if (filter == "") filter = "true";

        //    // Get Data
        //    var q = _salaryStandardDetailService.GetQueryable().Include("SalaryStandard").Include("SalaryItem").Where(x => x.SalaryStandardId == id);

        //    var query = (from model in q
        //                 select new
        //                 {
        //                     model.Id,
        //                     model.SalaryStandardId,
        //                     model.SalaryItemId,
        //                     SalaryItemCode = model.SalaryItem.Code,
        //                     SalaryItemName = model.SalaryItem.Name,
        //                     model.Amount,
        //                 }).Where(filter).OrderBy(sidx + " " + sord); //.ToList();

        //    var list = query.AsEnumerable();

        //    var pageIndex = Convert.ToInt32(page) - 1;
        //    var pageSize = rows;
        //    var totalRecords = query.Count();
        //    var totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
        //    // default last page
        //    if (totalPages > 0)
        //    {
        //        if (!page.HasValue)
        //        {
        //            pageIndex = totalPages - 1;
        //            page = totalPages;
        //        }
        //    }

        //    list = list.Skip(pageIndex * pageSize).Take(pageSize);

        //    return Json(new
        //    {
        //        total = totalPages,
        //        page = page,
        //        records = totalRecords,
        //        rows = (
        //            from model in list
        //            select new
        //            {
        //                id = model.Id,
        //                cell = new object[] {
        //                     model.SalaryStandardId,
        //                     model.SalaryItemId,
        //                     model.SalaryItemCode,
        //                     model.SalaryItemName,
        //                     model.Amount,
        //              }
        //            }).ToArray()
        //    }, JsonRequestBehavior.AllowGet);
        //}

        //public dynamic GetListDetailDynamic(string _search, long nd, int rows, int? page, string sidx, string sord, int id, string filters = "")
        //{
        //    // Construct where statement
        //    string strWhere = GeneralFunction.ConstructWhere(filters);
        //    string filter = null;
        //    GeneralFunction.ConstructWhereInLinq(strWhere, out filter);
        //    if (filter == "") filter = "true";

        //    // Get Data
        //    var q = _salaryStandardDetailService.GetQueryable().Include("SalaryStandard").Include("SalaryItem").Where(x => x.SalaryStandardId == id);

        //    var query = (from model in q
        //                 select new
        //                 {
        //                     model.Id,
        //                     model.SalaryStandardId,
        //                     model.SalaryItemId,
        //                     SalaryItemCode = model.SalaryItem.Code,
        //                     SalaryItemName = model.SalaryItem.Name,
        //                     model.Amount,
        //                 }).Where(filter).OrderBy(sidx + " " + sord); //.ToList();

        //    var list = query.AsEnumerable();

        //    var pageIndex = Convert.ToInt32(page) - 1;
        //    var pageSize = rows;
        //    var totalRecords = query.Count();
        //    var totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
        //    // default last page
        //    if (totalPages > 0)
        //    {
        //        if (!page.HasValue)
        //        {
        //            pageIndex = totalPages - 1;
        //            page = totalPages;
        //        }
        //    }

        //    list = list.Skip(pageIndex * pageSize).Take(pageSize);

        //    return Json(new
        //    {
        //        total = totalPages,
        //        page = page,
        //        records = totalRecords,
        //        rows = list
        //    }, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public dynamic InsertDetail(SalaryStandardDetail model)
        {
            try
            {
                //if (!AuthenticationModel.IsAllowed("Edit", Core.Constants.Constant.MenuName.SalaryStandard, Core.Constants.Constant.MenuGroupName.Utility))
                //{
                //    Dictionary<string, string> Errors = new Dictionary<string, string>();
                //    Errors.Add("Generic", "You are Not Allowed to Edit record");

                //    return Json(new
                //    {
                //        Errors
                //    }, JsonRequestBehavior.AllowGet);
                //}
              //  model = _salaryStandardDetailService.CreateObject(model, _salaryStandardService, _salaryItemService);
            }
            catch (Exception ex)
            {
                LOG.Error("Insert Failed", ex);
                Dictionary<string, string> Errors = new Dictionary<string, string>();
                Errors.Add("Generic", "Error " + ex);

                return Json(new
                {
                    Errors
                }, JsonRequestBehavior.AllowGet);

            }

            return Json(new
            {
               // model.Errors,
            });
        }

        [HttpPost]
        public dynamic UpdateDetail(SalaryStandardDetail model)
        {
            try
            {
                //if (!AuthenticationModel.IsAllowed("Edit", Core.Constants.Constant.MenuName.SalaryStandard, Core.Constants.Constant.MenuGroupName.Utility))
                //{
                //    Dictionary<string, string> Errors = new Dictionary<string, string>();
                //    Errors.Add("Generic", "You are Not Allowed to Edit record");

                //    return Json(new
                //    {
                //        Errors
                //    }, JsonRequestBehavior.AllowGet);
                //}

             //   var data = _salaryStandardDetailService.GetObjectById(model.Id);
            //    data.SalaryItemId = model.SalaryItemId;
              //  data.Amount = model.Amount;
                //data.SalaryStandardId = model.SalaryStandardId;
             //   model = _salaryStandardDetailService.UpdateObject(data, _salaryStandardService, _salaryItemService);
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
               // model.Errors,
            });
        }

        [HttpPost]
        public dynamic DeleteDetail(SalaryStandardDetail model)
        {
            try
            {
                //if (!AuthenticationModel.IsAllowed("Edit", Core.Constants.Constant.MenuName.SalaryStandard, Core.Constants.Constant.MenuGroupName.Utility))
                //{
                //    Dictionary<string, string> Errors = new Dictionary<string, string>();
                //    Errors.Add("Generic", "You are Not Allowed to Edit record");

                //    return Json(new
                //    {
                //        Errors
                //    }, JsonRequestBehavior.AllowGet);
                //}

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
               // model.Errors,
            });
        }


    }
}
