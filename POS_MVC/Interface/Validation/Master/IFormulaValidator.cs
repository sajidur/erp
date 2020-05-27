using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IFormulaValidator
    {
        bool ValidDeleteObject(Formula formula);
        bool isValid(Formula formula);
        string PrintError(Formula formula);
    }
}