using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ISPKLValidator
    {

        bool ValidCreateObject(SPKL spkl, EmployeeService _employeeService);
        bool ValidUpdateObject(SPKL spkl, EmployeeService _employeeService);
        bool ValidDeleteObject(SPKL spkl);
        bool isValid(SPKL spkl);
        string PrintError(SPKL spkl);
    }
}