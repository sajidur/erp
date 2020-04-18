using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface IOtherIncomeRepository : IRepository<OtherIncome>
    {
        IQueryable<OtherIncome> GetQueryable();
        IList<OtherIncome> GetAll();
        OtherIncome GetObjectById(int Id);
        OtherIncome CreateObject(OtherIncome otherIncome);
        OtherIncome UpdateObject(OtherIncome otherIncome);
        OtherIncome SoftDeleteObject(OtherIncome otherIncome);
        bool DeleteObject(int Id);
    }
}