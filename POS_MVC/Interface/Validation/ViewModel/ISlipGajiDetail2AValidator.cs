﻿using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ISlipGajiDetail2AValidator
    {
        
        bool ValidCreateObject(SlipGajiDetail2A slipGajiDetail2A, ISlipGajiDetailService _slipGajiDetailService);
        bool ValidUpdateObject(SlipGajiDetail2A slipGajiDetail2A, ISlipGajiDetailService _slipGajiDetailService);
        bool ValidDeleteObject(SlipGajiDetail2A slipGajiDetail2A);
        bool isValid(SlipGajiDetail2A slipGajiDetail2A);
        string PrintError(SlipGajiDetail2A slipGajiDetail2A);
    }

}