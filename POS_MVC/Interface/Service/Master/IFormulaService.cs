using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Service
{
    public interface IFormulaService
    {
        IFormulaValidator GetValidator();
        IQueryable<Formula> GetQueryable();
        IList<Formula> GetAll();
        Formula GetObjectById(int Id);
        Formula SoftDeleteObject(Formula formula);
        bool DeleteObject(int Id);
        //decimal CalcFormula(int formulaId, int employeeId, DateTime date, ISalaryItemService _salaryItemService, 
        //            ISalaryEmployeeDetailService _salaryEmployeeDetailService, IEmployeeAttendanceDetailService _employeeAttendanceDetailService);
        //bool IsFormulaInfinite(int formulaId, ISalaryItemService _salaryItemService, IList<int> stack = null);
    }
}