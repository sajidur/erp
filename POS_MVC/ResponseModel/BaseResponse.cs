using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ResponseModel
{
    public class BaseResponse
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }

    }
}