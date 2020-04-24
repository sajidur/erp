using RexERP_MVC.Models;
using RexERP_MVC.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class GoodsReceiveService
    {
        DBService<ReceiveMaster> service = new DBService<ReceiveMaster>();
        DBService<ReceiveDetail> serviceDetails = new DBService<ReceiveDetail>();
        DBService<InventoryTransaction> _invTransactionService = new DBService<InventoryTransaction>();

        DBService<Inventory> _inventoryService = new DBService<Inventory>();
        LedgerPostingService ledgerService = new LedgerPostingService();
        SupplierService supplierService = new SupplierService();
        FinancialYearService year = new FinancialYearService();
        PartyBalanceService partyBalanceService = new PartyBalanceService();
        int financialYearId = CurrentSession.GetCurrentSession().FinancialYear;
        public List<ReceiveMaster> GetAll()
        {
            return service.GetAll();
        }
        public ReceiveMaster GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public ReceiveMaster Save(ReceiveMaster cus,int wareHouseId, int goodsType)
        {
            var supplier = supplierService.GetById(cus.SupplierID);
            cus.YearId = financialYearId;
            var result= service.Save(cus);
            if (result != null || result.Id > 0)
            {
                foreach (var item in cus.ReceiveDetails)
                {
                    var balance = 0.0m;
                    var existingItem = _inventoryService.GetAll(a=>a.ProductId==item.ProductId && a.IsActive==true && a.WarehouseId==wareHouseId && a.SizeId==item.SizeId&&a.BrandId==item.BrandId && a.APIId==item.APIId).ToList();
                    if (existingItem.Count>0)
                    {
                        foreach (var inv in existingItem)
                        {
                            inv.UpdatedDate = DateTime.Now;
                            inv.UpdatedBy = "";
                            inv.BalanceQty = inv.BalanceQty + item.Qty;
                            inv.ReceiveQty = inv.ReceiveQty??0 + item.Qty;
                            _inventoryService.Update(inv, inv.Id);
                            balance = inv.BalanceQty;
                        }

                    }
                    else
                    {
                        Inventory inv = new Inventory();
                        inv.IsActive = true;
                        inv.CreatedDate = DateTime.Now;
                        inv.CreatedBy = "";
                        inv.ProductId = item.ProductId;
                        inv.ReceiveQty = item.Qty;
                        inv.SupplierId = cus.SupplierID;
                        inv.WarehouseId = wareHouseId;
                        inv.BrandId = item.BrandId;
                        inv.SizeId = item.SizeId;
                        inv.APIId = item.APIId;
                        inv.Faulty = 0;
                        inv.OpeningQty = 0;
                        inv.BalanceQty = item.Qty;
                        inv.PurchasePrice = item.Rate;
                        inv.GoodsType = goodsType.ToString();
                        _inventoryService.Save(inv);
                        balance = item.Qty;
                    }

                    var invTransaction = new InventoryTransaction()
                    {
                        APIId = item.APIId,
                        BalanceQty = balance,
                        BrandId = item.BrandId,
                        CreatedBy = CurrentSession.GetCurrentSession().UserName,
                        CreatedDate = DateTime.Now,
                        GoodsType = goodsType.ToString(),
                        InventoryGuid = Guid.NewGuid().ToString(),
                        InvoiceNo = cus.InvoiceNo,
                        IsActive = true,
                        ProductId = item.ProductId,
                        PurchasePrice = item.Rate,
                        Qty = item.Qty,
                        SalesPrice = 0,
                        SizeId = item.SizeId,
                        SupplierId = cus.SupplierID,
                        TransactionType = (int)Util.TransactionType.ReceiveQty,
                        WarehouseId = item.WarehouseId??0
                    };
                    _invTransactionService.Save(invTransaction);

                }
                // Ledger posting debit to purchase account

                var ledgerObj = new LedgerPosting();
                ledgerObj.VoucherTypeId = (int)VoucherType.PurchaseInvoice;
                ledgerObj.VoucherNo = result.InvoiceNoPaper;
                ledgerObj.PostingDate = cus.InvoiceDate;
                ledgerObj.LedgerId =(int)DefaultLedger.PurchaseAccount;
                ledgerObj.InvoiceNo = cus.InvoiceNo;
                ledgerObj.Credit = 0;
                ledgerObj.Debit = cus.GrandTotal;
                ledgerObj.MasterId = result.Id;
                var save = ledgerService.Save(ledgerObj);

                //Ledger posting to customer ledger credit
                var detailsLedger = new LedgerPosting();
                detailsLedger.VoucherTypeId = (int)VoucherType.PurchaseInvoice;
                detailsLedger.VoucherNo = result.InvoiceNoPaper;
                detailsLedger.PostingDate = cus.InvoiceDate;
                detailsLedger.LedgerId =supplier.LedgerId;
                detailsLedger.InvoiceNo = cus.InvoiceNo;
                detailsLedger.Credit = cus.GrandTotal;
                detailsLedger.Debit = 0;
                detailsLedger.MasterId = result.Id;
                var detailsLedgerResult = ledgerService.Save(detailsLedger);

                var party = new PartyBalance();
                party.InvoiceNo = result.InvoiceNo;
                party.LedgerId = supplier.LedgerId??0;
                party.Credit = cus.GrandTotal;
                party.CreditPeriod = 60;
                party.Debit = 0;
                party.MasterId = result.Id;
                party.FinancialYearId = CurrentSession.GetCurrentSession().FinancialYear;
                party.PostingDate = cus.InvoiceDate;
                party.VoucherTypeId = (int)VoucherType.PurchaseInvoice;
                party.VoucherNo = result.InvoiceNo;
                party.extra1 = "Purchase Invoice: "+cus.InvoiceNo+" Coutha:"+cus.InvoiceNoPaper;
                party.extra2 = result.Id.ToString();
                partyBalanceService.Save(party);
            }
            return cus;

        }
        public ReceiveMaster Update(ReceiveMaster t, int id)
        {
            service.Update(t, id);
            return t;

        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }

        public int Delete(ReceiveMaster master)
        {
            try
            {
                var salesdetails = serviceDetails.GetAll(a => a.ReceiveMasterId == master.Id).ToList();
                foreach (var item in salesdetails)
                {
                    try
                    {
                        var isdetails = new DBService<ReceiveDetail>().Delete(item.Id);

                    }
                    catch (Exception ex)
                    {

                    }
                }

                var isDeleted = service.Delete(master.Id);
                foreach (var item in master.ReceiveDetails)
                {
                    var existingItem = _inventoryService.GetAll(a => a.ProductId == item.ProductId && a.IsActive == true && a.WarehouseId == item.WarehouseId).ToList();
                    if (existingItem.Count > 0)
                    {
                        foreach (var inv in existingItem)
                        {
                            inv.UpdatedDate = DateTime.Now;
                            inv.UpdatedBy = "";
                            inv.BalanceQty = inv.BalanceQty - item.Qty;
                            inv.ReceiveQty = inv.ReceiveQty ?? 0 - item.Qty;
                            _inventoryService.Update(inv, inv.Id);
                        }

                    }
                }
               var supplier = supplierService.GetById(master.SupplierID);

                foreach (LedgerPosting item in this.ledgerService.GetAllByInvoice(master.InvoiceNo, true))
                {
                    item.IsActive = false;
                    this.ledgerService.Update(item, item.Id);
                }
                PartyBalanceService partyBalanceService = this.partyBalanceService;
                int? ledgerId = supplier.LedgerId;
                PartyBalance paymentObj = partyBalanceService.GetByInvoiceNo(supplier.LedgerId ?? 0, master.InvoiceNo);
                this.partyBalanceService.Delete(paymentObj.PartyBalanceId);

                // Ledger Saves credit
                //var ledgerObj = new LedgerPosting();
                //ledgerObj.VoucherTypeId = (int)VoucherType.PurchaseInvoice;
                //ledgerObj.VoucherNo = master.InvoiceNoPaper;
                //ledgerObj.PostingDate = master.InvoiceDate;
                //ledgerObj.LedgerId = (int)DefaultLedger.PurchaseAccount;
                //ledgerObj.InvoiceNo = master.InvoiceNo;
                //ledgerObj.Debit = 0;
                //ledgerObj.Credit = master.GrandTotal;
                //ledgerObj.Extra1 = "Purchase Invoice Deleted: " + master.InvoiceNo;

                //var save = ledgerService.Save(ledgerObj);

                //Ledger posting to customer ledger credit
                //var detailsLedger = new LedgerPosting();
                //detailsLedger.VoucherTypeId = (int)VoucherType.PurchaseInvoice;
                //detailsLedger.VoucherNo = master.InvoiceNoPaper;
                //detailsLedger.PostingDate = master.InvoiceDate;
                //detailsLedger.LedgerId = supplier.LedgerId;
                //detailsLedger.InvoiceNo = master.InvoiceNo;
                //detailsLedger.Debit = master.GrandTotal;
                //detailsLedger.Credit = 0;
                //detailsLedger.Extra1 = "Purchase Invoice Deleted: " + master.InvoiceNo;
                //var detailsLedgerResult = ledgerService.Save(detailsLedger);

                //var party = new PartyBalance();
                //party.InvoiceNo = master.InvoiceNo;
                //party.LedgerId = supplier.LedgerId ?? 0;
                //party.Debit = master.GrandTotal;
                //party.CreditPeriod = 60;
                //party.Credit = 0;
                //party.FinancialYearId =CurrentSession.GetCurrentSession().FinancialYear;
                //party.PostingDate = master.InvoiceDate;
                //party.VoucherTypeId = (int)VoucherType.PurchaseInvoice;
                //party.extra1 = "Purchase Invoice Deleted: " + master.InvoiceNo;
                //partyBalanceService.Save(party);

                return 1;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public List<ReceiveMaster> GetAllPaddyRecieveForReport()
        {
            return service.GetAll(a => a.IsActive == true && a.MarketType == "Not Local" && a.YearId== financialYearId).ToList();
        }
        public List<ReceiveDetail> GetAllPaddyRecieveForReport(string voucher)
        {
            var details=  service.GetAll(a => a.IsActive == true &&a.InvoiceNo==voucher).FirstOrDefault();
            if (details!=null && details.ReceiveDetails!=null)
            {
                return details.ReceiveDetails.ToList();
            }
            else
            {
                return new List<ReceiveDetail>();
            }
        }

        public List<ReceiveMaster> GetAllPaddyRecieveFilteredBySupplierForReport(int supplierId)
        {
            return service.GetAll(a => a.IsActive == true && a.MarketType == "Not Local" && a.SupplierID == supplierId && a.YearId == financialYearId).ToList();
        }

        public List<ReceiveMaster> GetAllPaddyRecieveFilteredByDateForReport(DateTime startDate, DateTime endDate)
        {
            return service.GetAll(a => a.IsActive == true && a.MarketType == "Not Local" && (a.CreatedDate >= startDate && a.CreatedDate < endDate) && a.YearId == financialYearId)
                .ToList();
        }

        public List<ReceiveMaster> GetAllPaddyRecieveFilteredByDateAndSupplierForReport(DateTime startDate, DateTime endDate, int supplierId)
        {
            if (supplierId==0)
            {
                return service.GetAll(a => a.IsActive == true && a.MarketType == "Not Local" && (a.InvoiceDate >= DbFunctions.TruncateTime(startDate).Value && a.InvoiceDate <= DbFunctions.TruncateTime(endDate).Value) && a.YearId == financialYearId).ToList();
            }
            return service.GetAll(a => a.IsActive == true && a.MarketType == "Not Local" && (a.InvoiceDate >= DbFunctions.TruncateTime(startDate).Value && a.InvoiceDate <= DbFunctions.TruncateTime(endDate).Value) && a.SupplierID==supplierId && a.YearId == financialYearId)
                .ToList();
        }


        public List<ReceiveMaster> GetAllRiceRecieveForReport()
        {
            return service.GetAll(a => a.IsActive == true && a.MarketType == "Local" && a.YearId == financialYearId).ToList();
        }

        public List<ReceiveMaster> GetAllRiceRecieveFilteredBySupplierForReport(int supplierId)
        {
            return service.GetAll(a => a.IsActive == true && a.MarketType == "Local" && a.SupplierID == supplierId && a.YearId == financialYearId).ToList();
        }

        public List<ReceiveMaster> GetAllRiceRecieveFilteredByDateForReport(DateTime startDate, DateTime endDate)
        {
            return service.GetAll(a => a.IsActive == true && a.MarketType == "Local" && (a.CreatedDate >= startDate && a.CreatedDate < endDate) && a.YearId == financialYearId)
                .ToList();
        }

        public List<ReceiveMaster> GetAllRiceRecieveFilteredByDateAndSupplierForReport(DateTime startDate, DateTime endDate, int supplierId)
        {
            return service.GetAll(a => a.IsActive == true && a.MarketType == "Local" && (a.CreatedDate >= startDate && a.CreatedDate < endDate) && a.SupplierID == supplierId && a.YearId == financialYearId)
                .ToList();
        }
    }
}