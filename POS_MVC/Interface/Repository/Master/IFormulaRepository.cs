using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface IFormulaRepository : IRepository<Formula>
    {
        IQueryable<Formula> GetQueryable();
        IList<Formula> GetAll();
        Formula GetObjectById(int Id);
        //Formula GetObjectByCode(string Code);
        Formula CreateObject(Formula formula);
        Formula UpdateObject(Formula formula);
        Formula SoftDeleteObject(Formula formula);
        bool DeleteObject(int Id);
        //bool IsCodeDuplicated(Formula formula);
    }
}