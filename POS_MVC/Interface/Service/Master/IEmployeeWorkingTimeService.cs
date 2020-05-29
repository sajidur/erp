using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface IEmployeeWorkingTimeService
    {
        IEmployeeWorkingTimeValidator GetValidator();
        IQueryable<EmployeeWorkingTime> GetQueryable();
        IList<EmployeeWorkingTime> GetAll();
        IList<SHIFT> GetAllShift();
        SHIFT AddShift(SHIFT sHIFT);
        IList<EmployeeWorkingTime> GetObjectsByWorkingTimeId(int WorkingTimeId);
        EmployeeWorkingTime GetObjectById(int Id);
        EmployeeWorkingTime CreateObject(EmployeeWorkingTime employeeWorkingTime, IWorkingTimeService _workingTimeService, EmployeeService _employeeService);
        EmployeeWorkingTime UpdateObject(EmployeeWorkingTime employeeWorkingTime, IWorkingTimeService _workingTimeService, EmployeeService _employeeService);
        EmployeeWorkingTime SoftDeleteObject(EmployeeWorkingTime employeeWorkingTime, EmployeeService _employeeService);
        bool DeleteObject(int Id);
    }
}