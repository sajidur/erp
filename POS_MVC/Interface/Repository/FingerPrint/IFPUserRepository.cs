using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface IFPUserRepository : IRepository<FPUser>
    {
        IQueryable<FPUser> GetQueryable();
        IList<FPUser> GetAll();
        FPUser GetObjectById(int Id);
        FPUser CreateObject(FPUser fpUser);
        FPUser UpdateObject(FPUser fpUser);
        FPUser SoftDeleteObject(FPUser fpUser);
        bool DeleteObject(int Id);
    }
}