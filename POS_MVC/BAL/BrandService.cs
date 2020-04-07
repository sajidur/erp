using RexERP_MVC.Models;
using RexERP_MVC.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.BAL
{
    public class BrandService
    {
        DBService<Brand> service = new DBService<Brand>();
        public List<Brand> GetAll()
        {
            return service.GetAll();
        }
        public Brand GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public Brand Save(Brand cus)
        {
            cus.Active = true;
            cus.CreatedDate = DateTime.Now;
            cus.CreatedBy= CurrentSession.GetCurrentSession().UserName;
            service.Save(cus);
            return cus;

        }
        public Brand Update(Brand t, int id)
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