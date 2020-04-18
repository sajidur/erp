using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Service
{
    public interface IEmployeeLoanDetailService
    {
        IEmployeeLoanDetailValidator GetValidator();
        IQueryable<EmployeeLoanDetail> GetQueryable();
        IList<EmployeeLoanDetail> GetAll();
        EmployeeLoanDetail GetObjectById(int Id);
        EmployeeLoanDetail CreateObject(EmployeeLoanDetail employeeLoanDetail, IEmployeeLoanService _employeeLoanService);
        EmployeeLoanDetail UpdateObject(EmployeeLoanDetail employeeLoanDetail, IEmployeeLoanService _employeeLoanService);
        EmployeeLoanDetail SoftDeleteObject(EmployeeLoanDetail employeeLoanDetail);
        bool DeleteObject(int Id);
    }
}