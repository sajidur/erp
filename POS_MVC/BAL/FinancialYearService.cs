using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class FinancialYearService
    {
        DBService<FinancialYear> service = new DBService<FinancialYear>();
        public List<FinancialYear> GetAll()
        {
            return service.GetAll().ToList();
        }
        public FinancialYear GetById(int? id = 0)
        {
            return service.GetById(id);
        }
        //public FinancialYear GetLatest()
        //{
        //    return service.GetAll().OrderByDescending(a=>a.Id).FirstOrDefault();
        //}

        public FinancialYear Save(FinancialYear cus)
        {
            return service.Save(cus);

        }
        public FinancialYear Update(FinancialYear t, int id)
        {
            return service.Update(t, id);

        }
        public int CustomerWiseYearClosed(int customerId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            // var date = fromDate.Date.Date.ToString("yyyy-MM-dd");
            var get = service.ExecuteNonQuery("Exec YearClosed '" + customerId + "'");
            return 1;

        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}