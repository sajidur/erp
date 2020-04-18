using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IFPTemplateValidator
    {

        bool ValidCreateObject(FPTemplate fpTemplate, IFPTemplateService _fpTemplateService, IFPUserService _fpUserService);
        bool ValidUpdateObject(FPTemplate fpTemplate, IFPTemplateService _fpTemplateService, IFPUserService _fpUserService);
        bool ValidDeleteObject(FPTemplate fpTemplate);
        bool isValid(FPTemplate fpTemplate);
        string PrintError(FPTemplate fpTemplate);
    }
}