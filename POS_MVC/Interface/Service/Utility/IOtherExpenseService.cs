using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Service
{
    public interface IOtherExpenseService
    {
        IOtherExpenseValidator GetValidator();
        IQueryable<OtherExpense> GetQueryable();
        IList<OtherExpense> GetAll();
        OtherExpense GetObjectById(int Id);
        bool DeleteObject(int Id);
        bool IsCodeDuplicated(OtherExpense otherExpense);
    }
}