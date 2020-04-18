using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IOtherIncomeDetailValidator
    {

        bool ValidCreateObject(OtherIncomeDetail otherIncomeDetail, IOtherIncomeService _otherIncomeService, EmployeeService _employeeService);
        bool ValidUpdateObject(OtherIncomeDetail otherIncomeDetail, IOtherIncomeService _otherIncomeService, EmployeeService _employeeService);
        bool ValidDeleteObject(OtherIncomeDetail otherIncomeDetail);
        bool isValid(OtherIncomeDetail otherIncomeDetail);
        string PrintError(OtherIncomeDetail otherIncomeDetail);
    }
}