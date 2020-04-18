using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface ISlipGajiMiniRepository : IRepository<SlipGajiMini>
    {
        IQueryable<SlipGajiMini> GetQueryable();
        IList<SlipGajiMini> GetAll();
        SlipGajiMini GetObjectById(int Id);
        SlipGajiMini CreateObject(SlipGajiMini slipGajiMini);
        SlipGajiMini UpdateObject(SlipGajiMini slipGajiMini);
        bool DeleteObject(int Id);
    }
}