using RexERP_MVC.Models;
using System.Collections.Generic;

namespace RexERP_MVC.BAL
{
    public class UnitService
    {
        DBService<Unit> service = new DBService<Unit>();
        public List<Unit> GetAll()
        {
            return service.GetAll();
        }

        public Unit Save(Unit cus)
        {
            return service.Save(cus);

        }
        public Unit Update(Unit t, int id)
        {
            return service.Update(t, id);

        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}