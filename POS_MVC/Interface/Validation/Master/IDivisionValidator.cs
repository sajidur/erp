using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IDivisionValidator
    {
        Division VHasUniqueName(Division division, IDivisionService _divisionService);

     
        bool ValidDeleteObject(Division division, EmployeeService _employeeService);
        bool isValid(Division division);
        string PrintError(Division division);
    }
}