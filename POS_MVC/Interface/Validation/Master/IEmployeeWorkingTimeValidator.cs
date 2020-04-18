using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IEmployeeWorkingTimeValidator
    {

        bool ValidCreateObject(EmployeeWorkingTime employeeWorkingTime, IWorkingTimeService _workingTimeService, EmployeeService _employeeService);
        bool ValidUpdateObject(EmployeeWorkingTime employeeWorkingTime, IWorkingTimeService _workingTimeService, EmployeeService _employeeService);
        bool ValidDeleteObject(EmployeeWorkingTime employeeWorkingTime, EmployeeService _employeeService);
        bool isValid(EmployeeWorkingTime employeeWorkingTime);
        string PrintError(EmployeeWorkingTime employeeWorkingTime);
    }
}