using RexERP_MVC.Models;
using RexERP_MVC.Util;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.BAL
{
    public class SalaryItemService
    {
        DBService<PayHead> service = new DBService<PayHead>();
        DBService<SalaryPackage> _salaryPackageservice = new DBService<SalaryPackage>();

        public List<PayHeadViewModel> GetAll()
        {
            var payHeads = service.GetAll();
            return AutoMapper.Mapper.Map<List<PayHeadViewModel>>(payHeads);
        }
        public List<SalaryPackageResponse> GetAllPackage()
        {
            var payHeads = _salaryPackageservice.GetAll();
            return AutoMapper.Mapper.Map<List<SalaryPackageResponse>>(payHeads);
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

        public SalaryPackage PackageSave(SalaryPackage cus)
        {
            //cus.Active = true;
            cus.CreateDate = DateTime.Now;
            cus.CreateBy = CurrentSession.GetCurrentSession().UserName;
            foreach (var item in cus.SalaryPackageDetails)
            {
                item.SalaryPackageId = cus.Id;
            }
            _salaryPackageservice.Save(cus);
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