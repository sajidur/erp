using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.Models;

namespace Core.Interface.Service
{
    public interface ITHRService
    {
        ITHRValidator GetValidator();
        IQueryable<THR> GetQueryable();
        IList<THR> GetAll();
        THR GetObjectById(int Id);
        THR CreateObject(THR thr, ISalaryItemService _salaryItemService);
        THR UpdateObject(THR thr, ISalaryItemService _salaryItemService);
        THR SoftDeleteObject(THR thr, ISalaryItemService _salaryItemService);
        bool DeleteObject(int Id);
        bool IsCodeDuplicated(THR thr);
    }
}