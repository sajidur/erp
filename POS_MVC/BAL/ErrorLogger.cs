﻿using System;
using System.IO;

namespace RexERP_MVC.BAL
{
    public static class ErrorLogger
    {
        public static void ErrorWritter(this Exception ex)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Error.txt"); 
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
    }
}