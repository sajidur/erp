using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface ISalaryItemRepository : IRepository<SalaryItem>
    {
        IQueryable<SalaryItem> GetQueryable();
        IList<SalaryItem> GetAll();
        SalaryItem GetObjectById(int Id);
        SalaryItem GetObjectByCode(string Code);
        SalaryItem CreateObject(SalaryItem salaryItem);
        SalaryItem UpdateObject(SalaryItem salaryItem);
        SalaryItem SoftDeleteObject(SalaryItem salaryItem);
        bool DeleteObject(int Id);
        bool IsCodeDuplicated(SalaryItem salaryItem);
    }
}