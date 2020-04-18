using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ITHRValidator
    {

        bool ValidCreateObject(THR thr, ITHRService _thrService);
        bool ValidUpdateObject(THR thr, ITHRService _thrService);
        bool ValidDeleteObject(THR thr);
        bool isValid(THR thr);
        string PrintError(THR thr);
    }
}