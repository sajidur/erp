using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Service
{
    public interface IOtherIncomeService
    {
        IOtherIncomeValidator GetValidator();
        IQueryable<OtherIncome> GetQueryable();
        IList<OtherIncome> GetAll();
        OtherIncome GetObjectById(int Id);
        OtherIncome CreateObject(OtherIncome otherIncome, ISalaryItemService _salaryItemService);
        OtherIncome UpdateObject(OtherIncome otherIncome, ISalaryItemService _salaryItemService);
        OtherIncome SoftDeleteObject(OtherIncome otherIncome, ISalaryItemService _salaryItemService);
        bool DeleteObject(int Id);
        bool IsCodeDuplicated(OtherIncome otherIncome);
    }
}