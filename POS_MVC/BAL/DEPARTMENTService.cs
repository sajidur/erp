using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class DEPARTMENTService
    {
        DBService<Department> service = new DBService<Department>();
        public List<Department> GetAll()
        {
            return service.GetAll().ToList();
        }
        public Department GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public Department Save(Department cus)
        {
            var isExists = service.GetAll().Where(a => a.Name == cus.Name).FirstOrDefault();
            if (isExists != null)
            {
                return null;
            }
            cus.CreatedDate = DateTime.Now;
            cus.Active = true;
            service.Save(cus);
            return cus;

        }
        public Department Update(Department t, int id)
        {
            return service.Update(t, id);
        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}