using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.BAL
{
    public class SizeService
    {
        DBService<Size> service = new DBService<Size>();
        public List<Size> GetAll()
        {
            return service.GetAll();
        }
        public Size GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public Size Save(Size cus)
        {
            service.Save(cus);
            return cus;

        }
        public Size Update(Size t, int id)
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