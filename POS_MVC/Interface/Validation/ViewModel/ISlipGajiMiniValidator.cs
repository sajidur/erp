using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ISlipGajiMiniValidator
    {

        bool ValidCreateObject(SlipGajiMini slipGajiMini, EmployeeService _employeeService);
        bool ValidUpdateObject(SlipGajiMini slipGajiMini, EmployeeService _employeeService);
        bool ValidDeleteObject(SlipGajiMini slipGajiMini);
        bool isValid(SlipGajiMini slipGajiMini);
        string PrintError(SlipGajiMini slipGajiMini);
    }
}