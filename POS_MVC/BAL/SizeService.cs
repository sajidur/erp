using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.BAL
{
    public class SizeService
    {
        DBService<Design> service = new DBService<Design>();
        public List<Design> GetAll()
        {
            return service.GetAll();
        }
        public Design GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public Design Save(Design cus)
        {
            service.Save(cus);
            return cus;

        }
        public Design Update(Design t, int id)
        {
            service.Update(t, id);
            return t;

        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}