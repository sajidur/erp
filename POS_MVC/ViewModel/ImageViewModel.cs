﻿using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class ImageViewModel
    {
        public int EmpId {get;set;}
        public int ImageId { get; set; }

        public string ImageTitle { get; set; }
        
        public byte[] ImageByte { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileWrapper ImageFile { get; set; }

        public static byte[] bufferByte { get; set; }
    }
}