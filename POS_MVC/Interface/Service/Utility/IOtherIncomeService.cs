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
        bool DeleteObject(int Id);
        bool IsCodeDuplicated(OtherIncome otherIncome);
    }
}