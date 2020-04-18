using RexERP_MVC.Models;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface IOtherIncomeDetailService
    {
        IOtherIncomeDetailValidator GetValidator();
        IQueryable<OtherIncomeDetail> GetQueryable();
        IList<OtherIncomeDetail> GetAll();
        OtherIncomeDetail GetObjectById(int Id);
        OtherIncomeDetail GetObjectByEmployeeIdAndSalaryItemId(int employeeId, int salaryItemId, DateTime date);
        OtherIncomeDetail CreateObject(OtherIncomeDetail otherIncomeDetail, IOtherIncomeService _otherIncomeService, EmployeeService _employeeService);
        OtherIncomeDetail UpdateObject(OtherIncomeDetail otherIncomeDetail, IOtherIncomeService _otherIncomeService, EmployeeService _employeeService);
        OtherIncomeDetail SoftDeleteObject(OtherIncomeDetail otherIncomeDetail);
        bool DeleteObject(int Id);
    }
}