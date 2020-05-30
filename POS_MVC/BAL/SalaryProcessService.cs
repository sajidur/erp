using Core.Interface.Service;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Globalization;
using System.Data.SqlTypes;
using RexERP_MVC.Util;
using RexERP_MVC.Models;
using System.Data.Entity.Core.Objects;
using RexERP_MVC.ViewModel;
using RexERP_MVC.BAL;
using Data.Repository;
using Validation.Validation;
//using WebView.ObjectCopier;

namespace Service.Service
{
    public class SalaryProcessService 
    {
        private IEmployeeAttendanceService _attendanceService;
        private IEmployeeLeaveService _leaveService;
        private DBService<HOLIDAY> _holyDayService = new DBService<HOLIDAY>();
        private BonusDeductionService _bonusDeductionService = new BonusDeductionService();
        private EmployeeRepository _employeeRepository = new EmployeeRepository();
        public SalaryProcessService()
        {
            _attendanceService = new EmployeeAttendanceService(new EmployeeAttendanceRepository(), new EmployeeAttendanceValidator());
            _leaveService = new EmployeeLeaveService(new EmployeeLeaveRepository(), new EmployeeLeaveValidator());
        }
        public List<EmployeeSalaryProcessViewResponse> SalaryProcess(int year,int month,int empId)
        {
            var employeeSalaryProcessResponse = new List<EmployeeSalaryProcessViewResponse>();
            var allemployee = _employeeRepository.GetAll();
            var employeeIds = allemployee.Select(a => a.Id).ToList();
            var attendance = _attendanceService.GetAttendanceCount(year, month);
            var leave = _leaveService.GetAll(employeeIds);
            var bonusDeductionList = _bonusDeductionService.GetAll(month, year);
            foreach (var item in allemployee)
            {
                var holyDays = _holyDayService.GetAll(a => a.HOLIDAYMONTH == month && a.HOLIDAYYEAR == year).ToList();
                var holyDaysCount = 0;
                if (holyDays != null)
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
                response.AbsenceCount = dayInMonth - (holyDaysCount + attendanceCount.Count() + leaveCount);
                response.DeductionAmount = bonusOrDeduction.Select(a => a.DeductionAmount ?? 0).Sum();
                response.AdditionAmount = bonusOrDeduction.Select(a => a.BonusAmount ?? 0).Sum();
                response.Salary = item.Salary - response.DeductionAmount + response.AdditionAmount;
                employeeSalaryProcessResponse.Add(response);
            }
            return employeeSalaryProcessResponse;
        }
    }
}