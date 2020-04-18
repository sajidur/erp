using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.Models;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface ISPKLService
    {
        ISPKLValidator GetValidator();
        IQueryable<SPKL> GetQueryable();
        IList<SPKL> GetAll();
        SPKL GetObjectById(int Id);
        SPKL CreateObject(SPKL spkl, EmployeeService _employeeService);
        SPKL UpdateObject(SPKL spkl, EmployeeService _employeeService);
        SPKL SoftDeleteObject(SPKL spkl);
        bool DeleteObject(int Id);
    }
}