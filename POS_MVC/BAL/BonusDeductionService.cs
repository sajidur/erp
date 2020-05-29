using RexERP_MVC.Models;
using RexERP_MVC.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.BAL
{
    public class BonusDeductionService
    {
        DBService<BonusDeduction> service = new DBService<BonusDeduction>();
        public List<BonusDeduction> GetAll(int year,int month)
        {
            return service.GetAll(a=>a.Year==year && a.Month==month).ToList();
        }
        public BonusDeduction GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public BonusDeduction Save(BonusDeduction cus)
        {
            cus.CreatedDate = DateTime.Now;
            cus.CreatedBy = CurrentSession.GetCurrentSession().UserId;
            service.Save(cus);
            return cus;

        }
        public BonusDeduction Update(BonusDeduction t, int id)
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