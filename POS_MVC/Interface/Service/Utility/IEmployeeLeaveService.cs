using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface IEmployeeLeaveService
    {
        IEmployeeLeaveValidator GetValidator();
        IQueryable<EmployeeLeave> GetQueryable();
        IList<EmployeeLeave> GetAll();
        IList<EmployeeLeave> GetAll(List<int> employeeIds);

        EmployeeLeave GetObjectById(int Id);
        EmployeeLeave CreateObject(EmployeeLeave employeeLeave, EmployeeService _employeeService);
        EmployeeLeave UpdateObject(EmployeeLeave employeeLeave, EmployeeService _employeeService);
        EmployeeLeave SoftDeleteObject(EmployeeLeave employeeLeave);
        bool DeleteObject(int Id);
    }
}