using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IOtherExpenseValidator
    {

        bool ValidCreateObject(OtherExpense otherExpense, IOtherExpenseService _otherExpenseService);
        bool ValidUpdateObject(OtherExpense otherExpense, IOtherExpenseService _otherExpenseService);
        bool ValidDeleteObject(OtherExpense otherExpense);
        bool isValid(OtherExpense otherExpense);
        string PrintError(OtherExpense otherExpense);
    }
}