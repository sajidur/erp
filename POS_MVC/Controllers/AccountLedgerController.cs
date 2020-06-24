using AutoMapper;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class AccountLedgerController : Controller
    {
        AccountLedgerService service = new AccountLedgerService();
        AccountGroupService groupService = new AccountGroupService();
        LedgerPostingService postingService = new LedgerPostingService();
        // GET: AccountLedger
        public ActionResult Index()
        {
            ViewBag.Title = "Account Ledger";
            return View();
        }
        public ActionResult GetAllLedger()
        {
            List<AccountLedger> category = service.GetAll();
            if (category == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<AccountLedger>, List<AccountLedgerResponse>>(category);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLedgerNature(int groupId)
        {
            var group = groupService.GetById(groupId);
            var nature = service.CheckDrOrCr(group.Nature);
            return Json(nature, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetAllLedger(int groupId)
        {
            var ledgers = service.GetAll(groupId);
            var group = groupService.GetById(groupId);
            foreach (var item in group.AccountLedgers)
            {
                ledgers.Add(item);
            }
            var result = AutoMapper.Mapper.Map<List<AccountLedger>, List<AccountLedgerResponse>>(ledgers);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetExpenseLedger()
        {
            List<AccountLedger> group = this.service.GetAllExpense();
            var expenses = Mapper.Map<List<AccountLedger>, List<AccountLedgerResponse>>(group).OrderByDescending(a=>a.OrderNo);
            return Json(expenses, 0);
        }
        [HttpGet]
        public ActionResult GetIncomeLedger()
        {
            List<AccountLedger> group = this.service.GetAllIncome();
            var expenses = Mapper.Map<List<AccountLedger>, List<AccountLedgerResponse>>(group).OrderByDescending(a => a.OrderNo);
            return Json(expenses, 0);
        }

        [HttpGet]
        public ActionResult GetById(int Id)
        {
            AccountLedger group = this.service.GetById(Id);
            var expenses = Mapper.Map<AccountLedger, AccountLedgerResponse>(group);
            return Json(expenses, 0);
        }
        [HttpPost]
        public ActionResult GetBankCashLedgerList(int groupId)
        {
            var ledgers = service.GetAll(groupId);
            var group = groupService.GetById(groupId);
            foreach (var item in group.AccountLedgers)
            {
                ledgers.Add(item);
            }
            var result = AutoMapper.Mapper.Map<List<AccountLedger>, List<AccountLedgerResponse>>(ledgers);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DrCrLedgerList(string DrCr)
        {
            var group = service.GetAll(DrCr);
            var result = AutoMapper.Mapper.Map<List<AccountLedger>, List<AccountLedgerResponse>>(group);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(AccountLedger category)
        {
            var result = category;
            if (ModelState.IsValid)
            {
                category.IsDefault = false;
                result = service.Save(category);
                if (result!=null && result.Id>0)
                {
                    LedgerPosting post = new LedgerPosting();
                    post.InvoiceNo = "OP_"+result.Id;
                    post.LedgerId = result.Id;
                    post.PostingDate = DateTime.Now;
                    if (category.CrOrDr=="Cr")
                    {
                        post.Credit = category.OpeningBalance;
                    }
                    if (category.CrOrDr=="Dr")
                    {
                        post.Debit = category.OpeningBalance;
                    }
                    post.VoucherTypeId = 1;
                    post.VoucherNo = category.Id.ToString();
                    post.InvoiceNo = category.Id.ToString();
                    
                   var postingResult= postingService.Save(post);

                }
            }
            return Json("Sucess", JsonRequestBehavior.AllowGet);
        }
    }
}