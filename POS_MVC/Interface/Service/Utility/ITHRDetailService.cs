using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.Models;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface ITHRDetailService
    {
        ITHRDetailValidator GetValidator();
        IQueryable<THRDetail> GetQueryable();
        IList<THRDetail> GetAll();
        THRDetail GetObjectById(int Id);
        THRDetail GetObjectByEmployeeIdAndSalaryItemId(int employeeId, int salaryItemId, DateTime date);
        THRDetail GetObjectByEmployeeIdAndTHRId(int employeeId, int THRId);
        THRDetail CreateObject(THRDetail thrDetail, ITHRService _thrService, EmployeeService _employeeService);
        THRDetail UpdateObject(THRDetail thrDetail, ITHRService _thrService, EmployeeService _employeeService);
        THRDetail SoftDeleteObject(THRDetail thrDetail);
        bool DeleteObject(int Id);
    }
}