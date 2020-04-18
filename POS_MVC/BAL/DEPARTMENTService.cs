using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class DEPARTMENTService
    {
        DBService<DEPARTMENT> service = new DBService<DEPARTMENT>();
        public List<DEPARTMENT> GetAll()
        {
            return service.GetAll().ToList();
        }
        public DEPARTMENT GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public DEPARTMENT Save(DEPARTMENT cus)
        {
            var isExists = service.GetAll().Where(a => a.DEPTNAME == cus.DEPTNAME).FirstOrDefault();
            if (isExists != null)
            {
                return null;
            }
            service.Save(cus);
            return cus;

        }
        public DEPARTMENT Update(DEPARTMENT t, int id)
        {
            return service.Update(t, id);
        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}