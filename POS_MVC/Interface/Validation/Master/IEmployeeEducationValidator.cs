using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IEmployeeEducationValidator
    {
        bool ValidCreateObject(EmployeeEducation employeeEducation, EmployeeService _employeeService);
        bool ValidUpdateObject(EmployeeEducation employeeEducation, EmployeeService _employeeService);
        bool ValidDeleteObject(EmployeeEducation employeeEducation);
        bool isValid(EmployeeEducation employeeEducation);
        string PrintError(EmployeeEducation employeeEducation);
    }
}