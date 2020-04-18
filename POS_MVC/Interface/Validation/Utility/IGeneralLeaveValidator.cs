using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IGeneralLeaveValidator
    {
        
        bool ValidCreateObject(GeneralLeave generalLeave);
        bool ValidUpdateObject(GeneralLeave generalLeave);
        bool ValidDeleteObject(GeneralLeave generalLeave);
        bool isValid(GeneralLeave generalLeave);
        string PrintError(GeneralLeave generalLeave);
    }
}