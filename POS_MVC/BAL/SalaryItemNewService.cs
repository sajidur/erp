using RexERP_MVC.Models;
using RexERP_MVC.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.BAL
{
    public class SalaryItemNewService
    {
        DBService<PayHead> service = new DBService<PayHead>();
        public List<PayHead> GetAll()
        {
            return service.GetAll();
        }
        public PayHead GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public PayHead Save(PayHead cus)
        {
            //cus.Active = true;
            cus.CreatedDate = DateTime.Now;
            cus.CreatedBy = CurrentSession.GetCurrentSession().UserId;
            service.Save(cus);
            return cus;

        }

        public SalaryPackage SaveFinally(SalaryPackage cus)
        {
            //cus.Active = true;
            cus.CreateDate = DateTime.Now;
            cus.CreateBy = CurrentSession.GetCurrentSession().UserName;
          //  service.Save(cus);
            return cus;

        }
        public PayHead Update(PayHead t, int id)
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