using RexERP_MVC.BAL;
using RexERP_MVC.BLL;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RexERP_MVC.Util;
using AutoMapper;

namespace RexERP_MVC.Controllers
{
    public class GoodsReceiveController : Controller
    {
        // GET: Brand
        GoodsReceiveService service = new GoodsReceiveService();
        LedgerPostingService ledgerService = new LedgerPostingService();
        public ActionResult Index()
        {
            ViewBag.Title = "Receive";
            return View(new ReceiveMaster());
        }
        // GET: /Category/Details/5
        //public ActionResult GetAll()
        //{
        //    List<ReceiveMaster> category = service.GetAll();
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var result = AutoMapper.Mapper.Map<List<ReceiveMaster>, List<ReceiveMasterResponse>>(category);
        //    return Json(category, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetInvoiceNumber()
        {
            string invoiceNumber =
                new GlobalClass().GetMaxIdWithPrfix("InvoiceNo", "8", "00000001", "ReceiveMaster", "GR");
            return Json(invoiceNumber, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(string totalAmount, string PONo,int supplierId,string descriptions,string LcNo,int WarehouseId,DateTime dates, List<GoodsReceiveResponse> response,List<AdditionalCost> additionalCosts,decimal Discount)
        {           
            string ID = "";
            ReceiveMaster master = new ReceiveMaster();
            master.InvoiceNoPaper= LcNo;
            master.InvoiceDate = dates;
          //  master.TotalAmount = decimal.Parse(totalAmount);
            master.InvoiceNo = new GlobalClass().GetMaxIdWithPrfix("InvoiceNo", "8", "00000001", "ReceiveMaster", "GR");
            master.SupplierID = supplierId;
            ID = master.InvoiceNo;
            foreach (var item in response)
            {
                ReceiveDetail details = new ReceiveDetail();
                //details.Id = item.Id;
                details.ReceiveMasterId = master.Id;
                details.BrandId = item.BrandId;
                details.SizeId = item.SizeId;
                details.ProductId = item.ProductId;
                details.WarehouseId = item.WarehouseId;
                details.APIId = item.APIId;
                details.Qty = item.QTY;
                details.Rate = item.Amount;             
                details.Amount = details.Qty*details.Rate??0;
                details.IsActive = true;
                details.CreatedBy = CurrentSession.GetCurrentSession().UserName;
                details.CreatedDate = DateTime.Now;                
                master.ReceiveDetails.Add(details);
               // total += details.QTY??0 * details.RetailPrice??0;
            }
            master.RecieveFrom = CurrentSession.GetCurrentSession().UserName;
            master.BillDiscount = Discount;
            if (additionalCosts!=null && additionalCosts.Count>0)
            {
                master.AdditionalCost = additionalCosts.Select(a => a.Debit).Sum(a => a.Value);
            }
            else
            {
                master.AdditionalCost = 0;
            }
            master.TotalAmount = master.ReceiveDetails.Sum(a => a.Amount);
            master.GrandTotal = master.ReceiveDetails.Sum(a=>a.Amount) + master.AdditionalCost - master.BillDiscount;
            master.IsActive = true;
            master.SupplierID = supplierId;
            master.Notes = descriptions;
            master.MarketType = "Not Local";
            master.TransportType = "Truck";
            master.TransportNo = "1";
            master.CreatedBy = CurrentSession.GetCurrentSession().UserName;
            master.CreatedDate = DateTime.Now;
            var result = service.Save(master,additionalCosts, WarehouseId,1);
            return Json(new { result = true, Error = "Saved", ID = ID }, JsonRequestBehavior.AllowGet);
        }

        // GET: /Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiveMaster category = service.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<ReceiveMaster, ReceiveMasterResponse>(category);

            return View(category);
        }

        // GET: /Category/Create
        public ActionResult Create()
        {
            return View();
        }


        //public ActionResult GetAllPaddyReceives()
        //{
        //    List<ReceiveMaster> receive = service.GetAllPaddyRecieveForReport();
        //    if (receive == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var result = AutoMapper.Mapper.Map<List<ReceiveMaster>, List<ReceiveMasterResponse>>(receive);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetAllPaddyReceivesDetails(string voucherNo)
        {
            if (voucherNo.Contains("GR") || voucherNo.Contains("gr"))
            {

                List<ReceiveDetail> receive = service.GetAllPaddyRecieveForReport(voucherNo);
                if (receive == null)
                {
                    return HttpNotFound();
                }

                var result = Mapper.Map<List<ReceiveDetail>, List<ReceiveDetailResponse>>(receive);
                return Json(result, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var result = Mapper.Map<List<LedgerPostingResponse>>(ledgerService.GetByVoucherNo(voucherNo));
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }


        //public ActionResult GetAllPaddyReceivesFilteredBySupplier(int supplierId)
        //{
        //    List<ReceiveMaster> receive = service.GetAllPaddyRecieveFilteredBySupplierForReport(supplierId);
        //    if (receive == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var result = AutoMapper.Mapper.Map<List<ReceiveMaster>, List<ReceiveMasterResponse>>(receive);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult GetAllPaddyReceivesFilteredByDate(DateTime fromDate, DateTime toDate)
        //{
        //    List<ReceiveMaster> receive = service.GetAllPaddyRecieveFilteredByDateForReport(fromDate, toDate);
        //    if (receive == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var result = AutoMapper.Mapper.Map<List<ReceiveMaster>, List<ReceiveMasterResponse>>(receive);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetAllBySupplierAndDate(DateTime fromDate, DateTime toDate, int supplierId)
        {
            List<ReceiveMaster> receive =
                service.GetAllPaddyRecieveFilteredByDateAndSupplierForReport(fromDate, toDate, supplierId);
            if (receive == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<ReceiveMaster>, List<ReceiveMasterResponse>>(receive);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiveMaster sales = service.GetById(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            var result = service.Delete(sales);
            return View("PaddyReceiveReport");

        }

        public ActionResult ReceiveReport()
        {
            return View();
        }
    }
}