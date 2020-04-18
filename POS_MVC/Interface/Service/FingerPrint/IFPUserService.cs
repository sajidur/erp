using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;
using Core.Interface.Repository;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface IFPUserService
    {
        IFPUserValidator GetValidator();
        IFPUserRepository GetRepository();
        IQueryable<FPUser> GetQueryable();
        IList<FPUser> GetAll();
        FPUser GetObjectById(int Id);
        FPUser GetObjectByPIN(int PIN);
        FPUser CreateObject(FPUser fpUser, EmployeeService _employeeService);
        FPUser UpdateObject(FPUser fpUser, EmployeeService _employeeService);
        FPUser UpdateOrCreateObject(FPUser fpUser, EmployeeService _employeeService);
        FPUser SoftDeleteObject(FPUser fpUser);
        bool DeleteObject(int Id);
        bool IsPINDuplicated(FPUser fpUser);
    }
}