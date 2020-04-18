using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ISlipGajiDetail1Validator
    {
        
        bool ValidCreateObject(SlipGajiDetail1 slipGajiDetail1, ISlipGajiDetailService _slipGajiDetailService);
        bool ValidUpdateObject(SlipGajiDetail1 slipGajiDetail1, ISlipGajiDetailService _slipGajiDetailService);
        bool ValidDeleteObject(SlipGajiDetail1 slipGajiDetail1);
        bool isValid(SlipGajiDetail1 slipGajiDetail1);
        string PrintError(SlipGajiDetail1 slipGajiDetail1);
    }

}