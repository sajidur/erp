﻿using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class SupplierService
    {
        DBService<Supplier> service = new DBService<Supplier>();
        PartyBalanceService partyBalanceService = new PartyBalanceService();
        public List<Supplier> GetAll()
        {
            //return service.GetAll();
            return service.GetAll(a => a.IsActive == true).ToList();
        }
        public List<Supplier> GetAllRiceSupplier()
        {
            return service.GetAll(a => a.IsActive == true && a.SupplierType== "Rice Supplier").ToList();
        }
        public List<Supplier> GetAllPaddySupplier()
        {
            return service.GetAll(a => a.IsActive == true && a.SupplierType == "Padday Supplier").ToList();
        }
        public Supplier GetById(int? id = 0)
        {
            return service.GetById(id);
        }
        public int LastId()
        {
            var data= service.GetAll().OrderByDescending(a=>a.Id).FirstOrDefault();
            if (data==null)
            {
                return 1;
            }
            else
            {
              return  data.Id + 1;
            }

        }

        public Supplier Save(Supplier cus)
        {
            var max = service.LastRow().OrderByDescending(a => a.Id).FirstOrDefault();
            if (max==null)
            {
                cus.Id = 1;
            }
            else
            {
                cus.Id = max.Id + 1;

            }
            return service.Save(cus);

        }
        public Supplier Update(Supplier t, int id)
        {
            return service.Update(t, id);

        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}