using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ISalaryItemValidator
    {
        
        bool ValidCreateObject(SalaryItem salaryItem, ISalaryItemService _salaryItemService);
        bool ValidUpdateObject(SalaryItem salaryItem, ISalaryItemService _salaryItemService);
        bool ValidDeleteObject(SalaryItem salaryItem);
        bool isValid(SalaryItem salaryItem);
        string PrintError(SalaryItem salaryItem);
    }
}