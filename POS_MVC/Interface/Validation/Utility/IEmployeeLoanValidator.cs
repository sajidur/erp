using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IEmployeeLoanValidator
    {

        bool ValidCreateObject(EmployeeLoan employeeLoan, EmployeeService _employeeService, ISalaryItemService _salaryItemService);
        bool ValidUpdateObject(EmployeeLoan employeeLoan, EmployeeService _employeeService, ISalaryItemService _salaryItemService);
        bool ValidDeleteObject(EmployeeLoan employeeLoan);
        bool isValid(EmployeeLoan employeeLoan);
        string PrintError(EmployeeLoan employeeLoan);
    }
}