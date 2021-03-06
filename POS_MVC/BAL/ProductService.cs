﻿using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class ProductService
    {
        DBService<Product> service = new DBService<Product>();
        DBService<PriceSetup> _priceSetupService = new DBService<PriceSetup>();

        public List<Product> GetAll(int type)
        {
            if (type==0)
            {
                return service.GetAll(a => a.IsActive == true).ToList();

            }
            //return service.GetAll();
            return service.GetAll(a => a.IsActive == true && a.ProductTypeId==type).ToList();
        }

        public List<Product> GetAllProductForStockIn()
        {
            return service.GetAll(p => p.ProductTypeId == 2 && p.IsActive == true).ToList();
        }

        public Product GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public Product Save(Product cus)
        {
            return service.Save(cus);

        }
        public PriceSetup SavePrice(PriceSetup cus)
        {
            return _priceSetupService.Save(cus);

        }
        public Product Update(Product t, int id)
        {
            return service.Update(t, id);

        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}