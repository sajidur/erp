using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.BAL
{
    public class CompanyService
    {
        DBService<Company> service = new DBService<Company>();
        public List<Company> GetAll()
        {
            return service.GetAll();
        }
        public Company GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public Company Save(Company cus)
        {
            service.Save(cus);
            return cus;

        }
        public Company Update(Company t, int id)
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