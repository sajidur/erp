using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface ISalaryEmployeeService
    {
        ISalaryEmployeeValidator GetValidator();
        IQueryable<SalaryEmployee> GetQueryable();
        IList<SalaryEmployee> GetAll();
        SalaryEmployee GetActiveObject();
        SalaryEmployee GetObjectById(int Id);
        SalaryEmployee CreateObject(SalaryEmployee salaryEmployee, EmployeeService _employeeService,
                            ISalaryEmployeeDetailService _salaryEmployeeDetailService, ISalaryItemService _salaryItemService,
                            ISalaryStandardDetailService _salaryStandardDetailService);
        SalaryEmployee UpdateObject(SalaryEmployee salaryEmployee, EmployeeService _employeeService);
        SalaryEmployee SoftDeleteObject(SalaryEmployee salaryEmployee);
        bool DeleteObject(int Id);
    }
}