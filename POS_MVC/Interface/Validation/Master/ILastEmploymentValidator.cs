using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ILastEmploymentValidator
    {
        bool ValidCreateObject(LastEmployment lastEmployment, EmployeeService _employeeService);
        bool ValidUpdateObject(LastEmployment lastEmployment, EmployeeService _employeeService);
        bool ValidDeleteObject(LastEmployment lastEmployment);
        bool isValid(LastEmployment lastEmployment);
        string PrintError(LastEmployment lastEmployment);
    }
}