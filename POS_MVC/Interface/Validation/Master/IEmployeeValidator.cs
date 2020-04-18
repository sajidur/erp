using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IEmployeeValidator
    {
        Employee VHasUniqueNIK(Employee employee, EmployeeService _employeeService);

        bool ValidCreateObject(Employee employee, EmployeeService _employeeService, IDivisionService _divisionService, ITitleInfoService _titleInfoService);
        bool ValidUpdateObject(Employee employee, EmployeeService _employeeService, IDivisionService _divisionService, ITitleInfoService _titleInfoService);
        bool ValidDeleteObject(Employee employee);
        bool isValid(Employee employee);
        string PrintError(Employee employee);
    }
}