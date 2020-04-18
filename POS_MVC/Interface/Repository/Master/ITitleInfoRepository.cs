using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface ITitleInfoRepository : IRepository<TitleInfo>
    {
        IQueryable<TitleInfo> GetQueryable();
        IList<TitleInfo> GetAll();
        TitleInfo GetObjectById(int Id);
        TitleInfo GetObjectByCode(string Code);
        TitleInfo CreateObject(TitleInfo titleInfo);
        TitleInfo UpdateObject(TitleInfo titleInfo);
        TitleInfo SoftDeleteObject(TitleInfo titleInfo);
        bool DeleteObject(int Id);
        bool IsCodeDuplicated(TitleInfo titleInfo);
    }
}