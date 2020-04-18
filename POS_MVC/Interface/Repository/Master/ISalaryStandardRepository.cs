using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface ISalaryStandardRepository : IRepository<SalaryStandard>
    {
        IQueryable<SalaryStandard> GetQueryable();
        IList<SalaryStandard> GetAll();
        SalaryStandard GetObjectById(int Id);
        SalaryStandard CreateObject(SalaryStandard salaryStandard);
        SalaryStandard UpdateObject(SalaryStandard salaryStandard);
        SalaryStandard SoftDeleteObject(SalaryStandard salaryStandard);
        bool DeleteObject(int Id);
    }
}