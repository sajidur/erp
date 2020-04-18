using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface ISalarySlipRepository : IRepository<SalarySlip>
    {
        IQueryable<SalarySlip> GetQueryable();
        IList<SalarySlip> GetAll();
        SalarySlip GetObjectById(int Id);
        SalarySlip CreateObject(SalarySlip salarySlip);
        SalarySlip UpdateObject(SalarySlip salarySlip);
        SalarySlip SoftDeleteObject(SalarySlip salarySlip);
        bool DeleteObject(int Id);
    }
}