using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IEmployeeAttendanceValidator
    {

        bool ValidCreateObject(EmployeeAttendance employeeAttendance, EmployeeService _employeeService, IEmployeeAttendanceService _employeeAttendanceService);
        bool ValidUpdateObject(EmployeeAttendance employeeAttendance, EmployeeService _employeeService, IEmployeeAttendanceService _employeeAttendanceService);
        bool ValidDeleteObject(EmployeeAttendance employeeAttendance);
        bool isValid(EmployeeAttendance employeeAttendance);
        string PrintError(EmployeeAttendance employeeAttendance);
    }
}