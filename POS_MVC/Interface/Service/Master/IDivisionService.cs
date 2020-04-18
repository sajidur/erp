using Core.Interface.Validation;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Service
{
    public interface IDivisionService
    {
        IDivisionValidator GetValidator();
        IQueryable<Division> GetQueryable();
        IList<Division> GetAll();
        IList<Division> GetObjectsByDepartmentId(int DepartmentId);
        Division GetObjectById(int Id);
        Division GetObjectByCode(string Code);
        Division GetObjectByName(string Name);
        //Division FindOrCreateObject(int departmentId, string Code, string Name, string Description, IDepartmentService _departmentService);
        //Division CreateObject(Division division, IDepartmentService _departmentService);
        //Division CreateObject(int departmentId, string Code, string Name, string Description, IDepartmentService _departmentService);
        //Division UpdateObject(Division division, IDepartmentService _departmentService);
        Division SoftDeleteObject(Division division, EmployeeService _employeeService);
        bool DeleteObject(int Id);
        bool IsCodeDuplicated(Division division);
        bool IsNameDuplicated(Division division);
    }
}