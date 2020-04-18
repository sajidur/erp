using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IOtherExpenseDetailValidator
    {

        bool ValidCreateObject(OtherExpenseDetail otherExpenseDetail, IOtherExpenseService _otherExpenseService, EmployeeService _employeeService);
        bool ValidUpdateObject(OtherExpenseDetail otherExpenseDetail, IOtherExpenseService _otherExpenseService, EmployeeService _employeeService);
        bool ValidDeleteObject(OtherExpenseDetail otherExpenseDetail);
        bool isValid(OtherExpenseDetail otherExpenseDetail);
        string PrintError(OtherExpenseDetail otherExpenseDetail);
    }
}