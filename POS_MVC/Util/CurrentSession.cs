﻿using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Web;

namespace RexERP_MVC.Util
{
    public class CurrentSession
    {
        public static AppSession GetCurrentSession()
        {
            AppSession vmSession;
            if (HttpContext.Current.Session["Session"] != null)
            {
                vmSession = HttpContext.Current.Session["Session"] as AppSession;
            }
            else
            {
                vmSession = new AppSession();                                                 
            }
            return vmSession;

        }
        public static List<FinancialYear> FinancialYears()
        {
            List<FinancialYear> financialYear;
            if (HttpContext.Current.Session["FinancialYear"] != null)
            {
                financialYear = HttpContext.Current.Session["FinancialYear"] as List<FinancialYear>;
            }
            else
            {
                financialYear = null;
            }
            return financialYear;

        }
    }
}