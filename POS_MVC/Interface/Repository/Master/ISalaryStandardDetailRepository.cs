using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface ISalaryStandardDetailRepository : IRepository<SalaryStandardDetail>
    {
        IQueryable<SalaryStandardDetail> GetQueryable();
        IList<SalaryStandardDetail> GetAll();
        IList<SalaryStandardDetail> GetObjectsByTitleInfoId(int TitleInfoId);
        SalaryStandardDetail GetObjectById(int Id);
        SalaryStandardDetail CreateObject(SalaryStandardDetail salaryStandardDetail);
        SalaryStandardDetail UpdateObject(SalaryStandardDetail salaryStandardDetail);
        SalaryStandardDetail SoftDeleteObject(SalaryStandardDetail salaryStandardDetail);
        bool DeleteObject(int Id);
    }
}