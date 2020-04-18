using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ISlipGajiDetailValidator
    {

        bool ValidCreateObject(SlipGajiDetail slipGajiDetail, EmployeeService _employeeService,
                                ISlipGajiDetail1Service _slipGajiDetail1Service, ISlipGajiDetail2AService _slipGajiDetail2AService);
        bool ValidUpdateObject(SlipGajiDetail slipGajiDetail, EmployeeService _employeeService,
                                ISlipGajiDetail1Service _slipGajiDetail1Service, ISlipGajiDetail2AService _slipGajiDetail2AService);
        bool ValidDeleteObject(SlipGajiDetail slipGajiDetail);
        bool isValid(SlipGajiDetail slipGajiDetail);
        string PrintError(SlipGajiDetail slipGajiDetail);
    }

}