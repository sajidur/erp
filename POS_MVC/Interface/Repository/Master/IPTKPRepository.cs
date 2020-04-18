using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface IPTKPRepository : IRepository<PTKP>
    {
        IQueryable<PTKP> GetQueryable();
        IList<PTKP> GetAll();
        PTKP GetObjectById(int Id);
        PTKP GetObjectByCode(string code);
        PTKP CreateObject(PTKP ptkp);
        PTKP UpdateObject(PTKP ptkp);
        PTKP SoftDeleteObject(PTKP ptkp);
        bool DeleteObject(int Id);
    }
}