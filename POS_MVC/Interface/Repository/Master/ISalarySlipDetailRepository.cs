using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface ISalarySlipDetailRepository : IRepository<SalarySlipDetail>
    {
        IQueryable<SalarySlipDetail> GetQueryable();
        IList<SalarySlipDetail> GetAll();
        SalarySlipDetail GetObjectById(int Id);
        SalarySlipDetail CreateObject(SalarySlipDetail salarySlipDetail);
        SalarySlipDetail UpdateObject(SalarySlipDetail salarySlipDetail);
        SalarySlipDetail SoftDeleteObject(SalarySlipDetail salarySlipDetail);
        bool DeleteObject(int Id);
    }
}