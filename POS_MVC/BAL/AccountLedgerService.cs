using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class AccountLedgerService
    {
        DBService<AccountLedger> service = new DBService<AccountLedger>();
        PartyBalanceService partyBalance = new PartyBalanceService();
        AccountGroupService groupService = new AccountGroupService();
        List<AccountLedger> ledgerList = new List<AccountLedger>();
        public List<AccountLedger> GetAll()
        {
            return service.GetAll().ToList();
        }
        public List<AccountLedger> GetAllExpense()
        {
            //  List<AccountLedger> list = this.service.GetAll((AccountLedger a) => a.AccountGroupId == (int?)15 || a.AccountGroupId == (int?)13 || a.AccountGroupId == (int?)11).ToList<AccountLedger>();
            List<AccountLedger> list = this.service.GetAll(a => a.CrOrDr == "Dr").ToList();
            return list;
        }
        public List<AccountLedger> GetAllIncome()
        {
            //  List<AccountLedger> list = this.service.GetAll((AccountLedger a) => a.AccountGroupId == (int?)10 || a.AccountGroupId == (int?)12 || a.AccountGroupId == (int?)14).ToList<AccountLedger>();
            List<AccountLedger> list = this.service.GetAll(a=>a.CrOrDr== "Cr").ToList();
            return list;
        }
        public List<AccountLedger> GetAll(int groupId)
        {
            var group = groupService.GetAll(groupId);
            foreach (var item in group)
            {
                foreach (var l in item.AccountLedgers)
                {
                    ledgerList.Add(l);
                }
                GetAll(item.Id);
            }
            return ledgerList;
        }

        public List<ChartOfAccount> ChartOfAccounts()
        {
            List<ChartOfAccount> ress = new List<ChartOfAccount>();
            var accountGroupss = groupService.GetAll().ToList();
            var primaryAccounts = accountGroupss.Where(a => a.GroupUnder == 0);
            var si = 1;
            int level = 0;
            foreach (AccountGroup item in primaryAccounts)
            {
                var charOfAccount = new ChartOfAccount();
                charOfAccount.level = level;
                charOfAccount.parent = 0;
                charOfAccount.expanded = true;
                charOfAccount.isLeaf = false;
                charOfAccount.SI = si;
                charOfAccount.Particular = item.AccountGroupName;
                charOfAccount.Id = item.Id;
                charOfAccount.DrOrCr = item.Nature;
                ress.Add(charOfAccount);
                ChartOfAccountsTreee(accountGroupss, item, level, si, ress);
                si++;
            }
            return ress;
        }
        public List<ChartOfAccount> ChartOfAccountsTreee(List<AccountGroup> groups,AccountGroup group,int level,int si,List<ChartOfAccount> ress)
        {
            var subHead = groups.Where(a => a.GroupUnder == group.Id).ToList();
            if (subHead.Any())
            {
                foreach (AccountGroup item in subHead)
                {
                    var charOfAccount = new ChartOfAccount();
                    charOfAccount.level = level+1;
                    charOfAccount.parent = item.Id;
                    charOfAccount.expanded = true;
                    charOfAccount.isLeaf = false;
                    charOfAccount.SI = si;
                    charOfAccount.Particular = item.AccountGroupName;
                    charOfAccount.ParentName = item.AccountGroupName;
                    charOfAccount.Id = item.Id;
                    charOfAccount.DrOrCr = item.Nature;
                    ress.Add(charOfAccount);
                    chartOfAccounts(item, ress, si, level+1);
                    ChartOfAccountsTreee(groups, item,level+1,si,ress);
                    si++;
                }
            }
            else
            {
                chartOfAccounts(group, ress, si, level+1);
            }
            return ress;
        }
        public List<ChartOfAccount> chartOfAccounts(AccountGroup group,List<ChartOfAccount> ress,int si,int level)
        {
            foreach (var ledger in group.AccountLedgers)
            {
                var ledgerHead = new ChartOfAccount();
                ledgerHead.level = level;
                ledgerHead.parent = group.Id;
                ledgerHead.ParentName = group.AccountGroupName;
                ledgerHead.expanded = false;
                ledgerHead.isLeaf = true;
                ledgerHead.SI = si++;
                ledgerHead.Particular = ledger.LedgerName;
                ledgerHead.Id = ledger.Id;
                ledgerHead.DrOrCr = ledger.CrOrDr;
                ress.Add(ledgerHead);
            }
            return ress;
        }
        public List<AccountLedger> GetAll(string CrDr) {
            if (CrDr == "Dr")
            {
                return service.GetAll(a => a.CrOrDr == "Dr").ToList();
            }
            else {
                return service.GetAll(a => a.CrOrDr == "Cr").ToList();
            }
           
        }
        public AccountLedger GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public AccountLedger Save(AccountLedger cus)
        {
            var isExists = service.GetAll().Where(a => a.AccountGroupId == cus.AccountGroupId && a.LedgerName == cus.LedgerName).FirstOrDefault();
            var max = service.LastRow().OrderByDescending(a=>a.Id).FirstOrDefault().Id;
            cus.Id = max + 1;
            cus.OrderNo = cus.Id + 1;
            if (isExists != null)
            {
                return isExists;
            }
            service.Save(cus);
            return cus;

        }
        public AccountLedger Update(AccountLedger t, int id)
        {
            return service.Update(t, id);
        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }

        public string CheckDrOrCr(string nature)
        {
            if (nature == "Assets" || nature == "Expenses")
            {
                return "Dr";
            }
            else if (nature == "Liabilities" || nature == "Income")
            {
                return "Cr";
            }
            else
                return "";
        }

        public string CheckDrOrCr(int accountGroup)
        {
            var group = groupService.GetById(accountGroup);
            if (group.Nature == "Assets" || group.Nature == "Expenses")
            {
                return "Dr";
            }
            else if (group.Nature == "Liabilities" || group.Nature == "Income")
            {
                return "Cr";
            }
            else
                return "";
        }
    }
}