using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.BAL
{
    public class HolidayService
    {
        DBService<HOLIDAY> service = new DBService<HOLIDAY>();
        public List<HOLIDAY> GetAll()
        {
            return service.GetAll().ToList();
        }
        public List<HOLIDAY> GetAll(string nature)
        {
            return service.GetAll().ToList();
            //if (nature == "Dr")
            //{
            //    return service.GetAll(a => a.Nature == "Assets" || a.Nature == "Expenses").ToList();
            //}
            //else
            //{
            //    return service.GetAll(a => a.Nature == "Liabilities" || a.Nature == "Income").ToList();
            //}

        }
        public List<HOLIDAY> GetAll(int groupId)
        {
            return service.GetAll().ToList();
        }
        public HOLIDAY GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public HOLIDAY Save(HOLIDAY cus)
        {
            service.Save(cus);
            return cus;

        }
        public HOLIDAY Update(HOLIDAY t, int id)
        {
            return service.Update(t, id);
        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}