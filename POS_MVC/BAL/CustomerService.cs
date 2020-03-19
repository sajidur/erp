using RexERP_MVC.Models;
using RexERP_MVC.Util;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RexERP_MVC.BAL
{
    public class CustomerService
    {
        DBService<Customer> service = new DBService<Customer>();
        DBService<rptIndividualLedger_Result> balanceService = new DBService<rptIndividualLedger_Result>();

        public List<Customer> GetAll()
        {
            //return service.GetAll();
            return service.GetAll(a => a.IsActive == true).ToList();
        }
        public Customer GetById(int? id = 0)
        {
            return service.GetById(id);
        }
        public Customer GetByLedgerId(int? id = 0)
        {
            return service.GetAll(a=>a.LedgerId==id&&a.IsActive==true).FirstOrDefault();
        }

        public rptIndividualLedger_Result GetBalance(int ledgerId)
        {
            SqlParameter param = new SqlParameter("@ledgerId", ledgerId);
            List<SqlParameter> paramss = new List<SqlParameter>();
            paramss.Add(param);
            SqlParameter param2 = new SqlParameter("@yearId", CurrentSession.GetCurrentSession().FinancialYear);
            paramss.Add(param2);
            return balanceService.ExecuteProcedure("EXEC GetBalance @ledgerId,@yearId", paramss).FirstOrDefault();
        }
        public Customer Save(Customer cus)
        {                    
            return service.Save(cus);

        }
        public Customer Update(Customer t, int id)
        {
           return service.Update(t, id);      

        }

        public int YearClosed(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {                    
            return service.Delete(id);
        }
    }
}