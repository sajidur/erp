using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ISalarySlipValidator
    {

        bool ValidCreateObject(SalarySlip salarySlip, ISalarySlipService _salarySlipService, ISalaryItemService _salaryItemService);
        bool ValidUpdateObject(SalarySlip salarySlip, ISalarySlipService _salarySlipService, ISalaryItemService _salaryItemService);
        bool ValidDeleteObject(SalarySlip salarySlip);
        bool isValid(SalarySlip salarySlip);
        string PrintError(SalarySlip salarySlip);
    }
}