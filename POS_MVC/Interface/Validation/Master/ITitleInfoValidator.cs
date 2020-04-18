using Core.Interface.Service;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ITitleInfoValidator
    {
        //TitleInfo VHasUniqueCode(TitleInfo titleInfo, ITitleInfoService _titleInfoService);
        
        bool ValidCreateObject(TitleInfo titleInfo, ITitleInfoService _titleInfoService);
        bool ValidUpdateObject(TitleInfo titleInfo, ITitleInfoService _titleInfoService);
        bool ValidDeleteObject(TitleInfo titleInfo, EmployeeService _employeeService);
        bool isValid(TitleInfo titleInfo);
        string PrintError(TitleInfo titleInfo);
    }
}