using RexERP_MVC.Models;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface IEmployeeEducationService
    {
        IEmployeeEducationValidator GetValidator();
        IQueryable<EmployeeEducation> GetQueryable();
        IList<EmployeeEducation> GetAll();
        IList<EmployeeEducation> GetObjectsByEmployeeId(int EmployeeId);
        EmployeeEducation GetObjectById(int Id);
        EmployeeEducation CreateObject(EmployeeEducation employeeEducation, EmployeeService _employeeService);
        EmployeeEducation CreateObject(string Institute, string Major, string Level, DateTime EnrollmentDate, Nullable<DateTime> GraduationDate, EmployeeService _employeeService);
        EmployeeEducation UpdateObject(EmployeeEducation employeeEducation, EmployeeService _employeeService);
        EmployeeEducation SoftDeleteObject(EmployeeEducation employeeEducation);
        bool DeleteObject(int Id);
    }
}