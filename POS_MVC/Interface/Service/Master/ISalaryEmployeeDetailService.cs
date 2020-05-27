using RexERP_MVC.Models;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Service
{
    public interface ISalaryEmployeeDetailService
    {
        IQueryable<SalaryEmployeeDetail> GetQueryable();
        IList<SalaryEmployeeDetail> GetAll();
        SalaryEmployeeDetail GetObjectById(int Id);
        SalaryEmployeeDetail GetObjectByEmployeeIdAndSalaryItemId(int employeeId, int salaryItemId, DateTime date);
        SalaryEmployeeDetail SoftDeleteObject(SalaryEmployeeDetail salaryEmployeeDetail);
        bool DeleteObject(int Id);
    }
}