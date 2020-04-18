using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface IEmployeeLoanDetailRepository : IRepository<EmployeeLoanDetail>
    {
        IQueryable<EmployeeLoanDetail> GetQueryable();
        IList<EmployeeLoanDetail> GetAll();
        EmployeeLoanDetail GetObjectById(int Id);
        EmployeeLoanDetail CreateObject(EmployeeLoanDetail employeeLoanDetail);
        EmployeeLoanDetail UpdateObject(EmployeeLoanDetail employeeLoanDetail);
        EmployeeLoanDetail SoftDeleteObject(EmployeeLoanDetail employeeLoanDetail);
        bool DeleteObject(int Id);
    }
}