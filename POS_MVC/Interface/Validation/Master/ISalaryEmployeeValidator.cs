using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ISalaryEmployeeValidator
    {

        bool ValidCreateObject(SalaryEmployee salaryEmployee, EmployeeService _employeeService, ISalaryEmployeeService _salaryEmployeeService);
        bool ValidUpdateObject(SalaryEmployee salaryEmployee, EmployeeService _employeeService, ISalaryEmployeeService _salaryEmployeeService);
        bool ValidDeleteObject(SalaryEmployee salaryEmployee);
        bool isValid(SalaryEmployee salaryEmployee);
        string PrintError(SalaryEmployee salaryEmployee);
    }
}