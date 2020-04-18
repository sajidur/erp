using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IFPAttLogValidator
    {

        bool ValidCreateObject(FPAttLog fpAttLog, IFPAttLogService _fpAttLogService, IFPUserService _fpUserService);
        bool ValidUpdateObject(FPAttLog fpAttLog, IFPAttLogService _fpAttLogService, IFPUserService _fpUserService);
        bool ValidDeleteObject(FPAttLog fpAttLog);
        bool isValid(FPAttLog fpAttLog);
        string PrintError(FPAttLog fpAttLog);
    }
}