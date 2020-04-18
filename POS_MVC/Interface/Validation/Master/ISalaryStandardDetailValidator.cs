using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ISalaryStandardDetailValidator
    {

        bool ValidCreateObject(SalaryStandardDetail salaryStandardDetail, ISalaryStandardService _salaryStandardService, ISalaryItemService _salaryItemService);
        bool ValidUpdateObject(SalaryStandardDetail salaryStandardDetail, ISalaryStandardService _salaryStandardService, ISalaryItemService _salaryItemService);
        bool ValidDeleteObject(SalaryStandardDetail salaryStandardDetail);
        bool isValid(SalaryStandardDetail salaryStandardDetail);
        string PrintError(SalaryStandardDetail salaryStandardDetail);
    }
}