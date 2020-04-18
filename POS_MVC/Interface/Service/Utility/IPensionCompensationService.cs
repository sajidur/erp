using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.Models;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface IPensionCompensationService
    {
        IPensionCompensationValidator GetValidator();
        IQueryable<PensionCompensation> GetQueryable();
        IList<PensionCompensation> GetAll();
        PensionCompensation GetObjectById(int Id);
        PensionCompensation CreateObject(PensionCompensation pensionCompensation, EmployeeService _employeeService);
        PensionCompensation UpdateObject(PensionCompensation pensionCompensation, EmployeeService _employeeService);
        PensionCompensation SoftDeleteObject(PensionCompensation pensionCompensation);
        bool DeleteObject(int Id);
    }
}