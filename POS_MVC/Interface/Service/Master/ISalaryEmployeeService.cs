using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface ISalaryEmployeeService
    {
        IQueryable<SalaryEmployee> GetQueryable();
        IList<SalaryEmployee> GetAll();
        SalaryEmployee GetActiveObject();
        SalaryEmployee GetObjectById(int Id);
        SalaryEmployee UpdateObject(SalaryEmployee salaryEmployee, EmployeeService _employeeService);
        SalaryEmployee SoftDeleteObject(SalaryEmployee salaryEmployee);
        bool DeleteObject(int Id);
    }
}