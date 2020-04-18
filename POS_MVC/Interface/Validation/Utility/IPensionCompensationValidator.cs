using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IPensionCompensationValidator
    {
        bool ValidCreateObject(PensionCompensation pensionCompensation, EmployeeService _employeeService);
        bool ValidUpdateObject(PensionCompensation pensionCompensation, EmployeeService _employeeService);
        bool ValidDeleteObject(PensionCompensation pensionCompensation);
        bool isValid(PensionCompensation pensionCompensation);
        string PrintError(PensionCompensation pensionCompensation);
    }
}