using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface ITitleInfoService
    {
        ITitleInfoValidator GetValidator();
        IQueryable<TitleInfo> GetQueryable();
        IList<TitleInfo> GetAll();
        TitleInfo GetObjectById(int Id);
        TitleInfo GetObjectByCode(string Code);
        TitleInfo FindOrCreateObject(string Code, string Name, string Description, bool IsShiftable);
        TitleInfo CreateObject(string Code, string Name, string Description, bool IsShiftable);
        TitleInfo CreateObject(TitleInfo titleInfo);
        TitleInfo UpdateObject(TitleInfo titleInfo);
        TitleInfo SoftDeleteObject(TitleInfo titleInfo, EmployeeService _employeeService);
        bool DeleteObject(int Id);
        bool IsCodeDuplicated(TitleInfo titleInfo);
    }
}