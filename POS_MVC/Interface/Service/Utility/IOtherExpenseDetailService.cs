using RexERP_MVC.Models;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface IOtherExpenseDetailService
    {
        IOtherExpenseDetailValidator GetValidator();
        IQueryable<OtherExpenseDetail> GetQueryable();
        IList<OtherExpenseDetail> GetAll();
        OtherExpenseDetail GetObjectById(int Id);
        OtherExpenseDetail GetObjectByEmployeeIdAndSalaryItemId(int employeeId, int salaryItemId, DateTime date);
        OtherExpenseDetail CreateObject(OtherExpenseDetail otherExpenseDetail, IOtherExpenseService _otherExpenseService, EmployeeService _employeeService);
        OtherExpenseDetail UpdateObject(OtherExpenseDetail otherExpenseDetail, IOtherExpenseService _otherExpenseService, EmployeeService _employeeService);
        OtherExpenseDetail SoftDeleteObject(OtherExpenseDetail otherExpenseDetail);
        bool DeleteObject(int Id);
    }
}