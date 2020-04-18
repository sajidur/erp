using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Service
{
    public interface ISalarySlipService
    {
        ISalarySlipValidator GetValidator();
        IQueryable<SalarySlip> GetQueryable();
        IList<SalarySlip> GetAll();
        SalarySlip GetObjectById(int Id);
        SalarySlip CreateObject(string Code, string Name, int SalarySign, int SalaryStatus, bool IsMainSalary, bool IsDetailSalary,
                        bool IsEnabled, bool IsPTKP, bool IsPPH21, ISalaryItemService _salaryItemService);
        SalarySlip CreateObject(SalarySlip salarySlip, ISalaryItemService _salaryItemService);
        SalarySlip UpdateObject(SalarySlip salarySlip, ISalaryItemService _salaryItemService);
        SalarySlip SoftDeleteObject(SalarySlip salarySlip, ISalaryItemService _salaryItemService);
        bool DeleteObject(int Id);
        bool IsCodeDuplicated(SalarySlip salarySlip);
    }
}