using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IEmployeeLeaveValidator
    {

        bool ValidCreateObject(EmployeeLeave employeeLeave, EmployeeService _employeeService);
        bool ValidUpdateObject(EmployeeLeave employeeLeave, EmployeeService _employeeService);
        bool ValidDeleteObject(EmployeeLeave employeeLeave);
        bool isValid(EmployeeLeave employeeLeave);
        string PrintError(EmployeeLeave employeeLeave);
    }
}