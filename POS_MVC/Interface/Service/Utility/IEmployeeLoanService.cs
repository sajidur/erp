using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface IEmployeeLoanService
    {
        IEmployeeLoanValidator GetValidator();
        IQueryable<EmployeeLoan> GetQueryable();
        IList<EmployeeLoan> GetAll();
        EmployeeLoan GetObjectById(int Id);
        EmployeeLoan CreateObject(EmployeeLoan employeeLoan, EmployeeService _employeeService, ISalaryItemService _salaryItemService);
        EmployeeLoan UpdateObject(EmployeeLoan employeeLoan, EmployeeService _employeeService, ISalaryItemService _salaryItemService);
        EmployeeLoan SoftDeleteObject(EmployeeLoan employeeLoan);
        bool DeleteObject(int Id);
    }
}