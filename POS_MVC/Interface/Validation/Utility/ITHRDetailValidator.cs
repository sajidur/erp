using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ITHRDetailValidator
    {

        bool ValidCreateObject(THRDetail thrDetail, ITHRService _thrService, EmployeeService _employeeService, ITHRDetailService _thrDetailService);
        bool ValidUpdateObject(THRDetail thrDetail, ITHRService _thrService, EmployeeService _employeeService, ITHRDetailService _thrDetailService);
        bool ValidDeleteObject(THRDetail thrDetail);
        bool isValid(THRDetail thrDetail);
        string PrintError(THRDetail thrDetail);
    }
}