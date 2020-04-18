using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;
using Core.Interface.Repository;
using RexERP_MVC.Models;

namespace Core.Interface.Service
{
    public interface ISlipGajiDetail1Service
    {
        ISlipGajiDetail1Validator GetValidator();
        ISlipGajiDetail1Repository GetRepository();
        IQueryable<SlipGajiDetail1> GetQueryable();
        IList<SlipGajiDetail1> GetAll();
        IList<SlipGajiDetail1> GetObjectsBySlipGajiDetailId(int SlipGajiDetailId);
        SlipGajiDetail1 GetObjectById(int Id);
        SlipGajiDetail1 CreateOrUpdateObject(SlipGajiDetail1 slipGajiDetail1, ISlipGajiDetailService _slipGajiDetailService);
        SlipGajiDetail1 CreateObject(SlipGajiDetail1 slipGajiDetail1, ISlipGajiDetailService _slipGajiDetailService);
        SlipGajiDetail1 UpdateObject(SlipGajiDetail1 slipGajiDetail1, ISlipGajiDetailService _slipGajiDetailService);
        bool DeleteObject(int Id);
    }

}