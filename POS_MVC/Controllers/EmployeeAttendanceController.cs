using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Service;
using Core.Interface.Service;
using Data.Repository;
using Validation.Validation;
using System.Data.Entity;
using RexERP_MVC.BAL;
using Core.Interface.Repository;
using Core.Interface.Validation;
using RexERP_MVC.Models;
using System.Data.Entity.Core.Objects;
using RexERP_MVC.Util;
using EmployeeService = RexERP_MVC.BAL.EmployeeService;

namespace RexERP_MVC.Controllers
{
    
    public class EmployeeAttendanceController : Controller
    {
        private readonly static log4net.ILog LOG = log4net.LogManager.GetLogger("EmployeeAttendanceController");
        public IEmployeeAttendanceService _employeeAttendanceService;
        private EmployeeService _employeeService;
        public ITitleInfoService _titleInfoService;
        public IBranchOfficeService _branchOfficeService;
        public IEmployeeWorkingTimeService _employeeWorkingTimeService;

        public EmployeeAttendanceController()
        {
            _employeeService = new RexERP_MVC.BAL.EmployeeService();
            _titleInfoService = new TitleInfoService(new TitleInfoRepository(), new TitleInfoValidator());
            _employeeAttendanceService = new EmployeeAttendanceService(new EmployeeAttendanceRepository(), new EmployeeAttendanceValidator());
            _branchOfficeService = new BranchOfficeService(new BranchOfficeRepository(), new BranchOfficeValidator());
            _employeeWorkingTimeService = new EmployeeWorkingTimeService(new EmployeeWorkingTimeRepository(), new EmployeeWorkingTimeValidator());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(DateTime attendanceDate,int? EmployeeId)
        {
            var q = _employeeAttendanceService.GetQueryable().Where(a=>a.AttendanceDate.Month== attendanceDate.Month && a.AttendanceDate.Year== attendanceDate.Year);

            var query = (from model in q
                         select new
                         {
                             model.Id,
                             model.EmployeeId,
                             EmployeeName = model.Employee.FirstName,
                             AttendanceDate = EntityFunctions.TruncateTime(model.CheckIn),
                             model.Shift,
                             model.Status,
                             model.CheckIn,
                             model.BreakOut,
                             model.BreakIn,
                             model.CheckOut,
                             model.Remark,
                             model.CreatedAt,
                             model.UpdatedAt,
                         }).OrderBy(a=>a.Id); //.ToList();

            var list = query.ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllShift()
        {
            var shifts= _employeeWorkingTimeService.GetAllShift().ToList();
            return Json(shifts, JsonRequestBehavior.AllowGet);
        }
        public dynamic GetInfo(int Id)
        {
            EmployeeAttendance model = new EmployeeAttendance();
            try
            {
                model = _employeeAttendanceService.GetObjectById(Id);
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
               // EmployeeNIK = model.Employee.NIK,
              //  EmployeeName = model.Employee.Name,
               // Title = model.Employee.TitleInfo.Name,
               // Division = model.Employee.Division.Name,
                //Department = model.Employee.Division.Department.Name,
               // BranchOffice = model.Employee.Division.Department.BranchOffice.Name,
                AttendanceDate = model.CheckIn.Date,
                model.Shift,
                model.Status,
                model.CheckIn,
                model.BreakOut,
                model.BreakIn,
                model.CheckOut,
                model.Remark//,
               // model.Errors
            }, JsonRequestBehavior.AllowGet);
        }

        public dynamic GetDefaultInfo()
        {
            EmployeeAttendance model = new EmployeeAttendance();
            try
            {
                model = _employeeAttendanceService.GetQueryable().FirstOrDefault();
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
               // EmployeeNIK = model.Employee.NIK,
                EmployeeName = model.Employee.FirstName,
              //  Title = model.Employee.TitleInfo.Name,
               // Division = model.Employee.Division.Name,
              //  Department = model.Employee..Department.Name,
              //  BranchOffice = model.Employee.Division.Department.BranchOffice.Name,
                AttendanceDate = model.CheckIn.Date,
                model.Shift,
                model.Status,
                model.CheckIn,
                model.BreakOut,
                model.BreakIn,
                model.CheckOut,
                model.Remark//,
               // model.Errors
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public dynamic Insert(EmployeeAttendance model, Nullable<DateTime> AttendanceDateEnd)
        {
            try
            {

                DateTime date = model.AttendanceDate;
                if (AttendanceDateEnd != null)
                {
                    if (AttendanceDateEnd.GetValueOrDefault() < date)
                    {
                        Dictionary<string, string> Errors = new Dictionary<string, string>();
                        Errors.Add("AttendanceDateEnd", "Harus lebih besar atau sama dengan Attendance Date");

                        return Json(new
                        {
                            Errors
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else if (AttendanceDateEnd.GetValueOrDefault().Subtract(date).TotalDays > 366)
                    {
                        Dictionary<string, string> Errors = new Dictionary<string, string>();
                        Errors.Add("AttendanceDateEnd", "Tidak boleh berjarak lebih dari setahun dari Attendance Date");

                        return Json(new
                        {
                            Errors
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                
                do {
                    model.AttendanceDate = date;
                    model = _employeeAttendanceService.CreateObject(model, _employeeService);
                    date = date.AddDays(1);
                } while (AttendanceDateEnd != null && date <= AttendanceDateEnd.GetValueOrDefault());
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
               // model.Errors
            });
        }

        [HttpPost]
        public dynamic Update(EmployeeAttendance model, bool IsDateRange, Nullable<DateTime> AttendanceDateEnd)
        {
            try
            {
                var data = _employeeAttendanceService.GetObjectById(model.Id);
                data.EmployeeId = model.EmployeeId;
                data.AttendanceDate = model.AttendanceDate;
                data.Shift = model.Shift;
                data.Status = model.Status;
                data.CheckIn = model.CheckIn;
                data.CheckOut = model.CheckOut;
                //data.BreakOut = model.BreakOut;
                //data.BreakIn = model.BreakIn;
                data.Remark = model.Remark;
                model = _employeeAttendanceService.UpdateObject(data, _employeeService);
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
            });
        }

        [HttpPost]
        public dynamic Delete(EmployeeAttendance model)
        {
            try
            {
                var data = _employeeAttendanceService.GetObjectById(model.Id);
                model = _employeeAttendanceService.SoftDeleteObject(data);
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
    }
}
