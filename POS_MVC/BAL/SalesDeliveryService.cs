using RexERP_MVC.Models;
using RexERP_MVC.Util;
using System;
using System.Collections.Generic;

namespace RexERP_MVC.BAL
{
    public class SalesDeliveryService
    {
        DBService<SalesDelivery> service = new DBService<SalesDelivery>();
        public List<SalesDelivery> GetAll()
        {
            return service.GetAll();
        }
        public SalesDelivery GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public SalesDelivery Save(SalesDelivery cus)
        {
            cus.CreatedDate = DateTime.Now;
            cus.CreatedBy = CurrentSession.GetCurrentSession().UserName;
            service.Save(cus);
            return cus;

        }
        public SalesDelivery Update(SalesDelivery t, int id)
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