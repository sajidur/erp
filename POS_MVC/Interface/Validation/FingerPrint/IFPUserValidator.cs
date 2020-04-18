using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IFPUserValidator
    {

        bool ValidCreateObject(FPUser fpUser, IFPUserService _fpUserService, EmployeeService _employeeService);
        bool ValidUpdateObject(FPUser fpUser, IFPUserService _fpUserService, EmployeeService _employeeService);
        bool ValidDeleteObject(FPUser fpUser);
        bool isValid(FPUser fpUser);
        string PrintError(FPUser fpUser);
    }
}