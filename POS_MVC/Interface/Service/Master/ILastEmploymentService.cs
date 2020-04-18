using RexERP_MVC.Models;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface ILastEmploymentService
    {
        ILastEmploymentValidator GetValidator();
        IQueryable<LastEmployment> GetQueryable();
        IList<LastEmployment> GetAll();
        IList<LastEmployment> GetObjectsByEmployeeId(int EmployeeId);
        LastEmployment GetObjectById(int Id);
        LastEmployment CreateObject(LastEmployment lastEmployment, EmployeeService _employeeService);
        LastEmployment CreateObject(string Company, string Title, DateTime StartDate, Nullable<DateTime> EndDate, string ResignReason, EmployeeService _employeeService);
        LastEmployment UpdateObject(LastEmployment lastEmployment, EmployeeService _employeeService);
        LastEmployment SoftDeleteObject(LastEmployment lastEmployment);
        bool DeleteObject(int Id);
    }
}