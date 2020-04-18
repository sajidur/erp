using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface IEmployeeAttendanceService
    {
        IEmployeeAttendanceValidator GetValidator();
        IQueryable<EmployeeAttendance> GetQueryable();
        IList<EmployeeAttendance> GetAll();
        EmployeeAttendance GetObjectById(int Id);
        EmployeeAttendance CreateObject(EmployeeAttendance employeeAttendance, EmployeeService _employeeService);
        EmployeeAttendance UpdateObject(EmployeeAttendance employeeAttendance, EmployeeService _employeeService);
        EmployeeAttendance SoftDeleteObject(EmployeeAttendance employeeAttendance);
        bool DeleteObject(int Id);
    }
}