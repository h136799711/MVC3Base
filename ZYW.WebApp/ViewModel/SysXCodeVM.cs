using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZYW.Model;

namespace ZYW.WebApp.ViewModel
{
    public class SysXCodeVM
    {
         public string XName {get;set;}
        public string XSource{get;set;}
        public long XID {get;set;}
        public ICollection<SysXCode> SubCode { get; set; }
    }
}