using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class PaymentService
    {

        DBService<LedgerPosting> service = new DBService<LedgerPosting>();
        DBService<PaymentMaster> _paymentMaster = new DBService<PaymentMaster>();
        DBService<PaymentDetail> _paymentDetails = new DBService<PaymentDetail>();

        public List<LedgerPosting> GetAll()
        {
            return service.GetAll().ToList();
        }
        public LedgerPosting GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        //public LedgerPosting Save(LedgerPosting cus)
        //{
        //    var isExists = service.GetAll().Where(a => a.LedgerId == cus.LedgerId && a.YearId == cus.YearId).FirstOrDefault();
        //    var max = service.LastRow().OrderByDescending(a => a.Id).FirstOrDefault().Id;
        //    cus.Id = max + 1;
        //    if (isExists != null)
        //    {
        //        return null;
        //    }
        //    cus.YearId = CurrentSession.GetCurrentSession().FinancialYear;
        //    cus.IsLastYear = true;
        //    service.Save(cus);
        //    return cus;

        //}
        public PaymentMaster SavePayment(PaymentMaster paymentMaster)
        {
            try
            {
                return _paymentMaster.Save(paymentMaster);

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
        public List<PaymentMaster> GetAllPendingPayment()
        {
            return _paymentMaster.GetAll(a=>a.IsApproved==false).ToList();
        }
        public List<PaymentMaster> GetAllPayment()
        {
            return _paymentMaster.GetAll(a => a.IsApproved == true).ToList();
        }
        public PaymentMaster GetPaymentById(int Id)
        {
            return _paymentMaster.GetAll(a => a.Id == Id).FirstOrDefault();
        }
        public LedgerPosting Update(LedgerPosting t, int id)
        {
            return service.Update(t, id);
        }
        public PaymentMaster Update(PaymentMaster t, int id)
        {
            return _paymentMaster.Update(t, id);
        }
        public PaymentDetail Update(PaymentDetail t, int id)
        {
            return _paymentDetails.Update(t, id);
        }
        public int DeletePayment(PaymentMasterResponse payment)
        {
            //foreach (var item in payment.PaymentDetails)
            //{
            //   _= _paymentDetails.Delete(item.Id);
            //}
            return _paymentMaster.Delete(payment.Id);
        }
    }
}