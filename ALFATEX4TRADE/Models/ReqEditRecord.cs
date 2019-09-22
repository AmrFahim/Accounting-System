using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALFATEX4TRADE.Models
{
    public class ReqEditRecord
    {
        public string ClientID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CleintName { get; set; }
        public double Outgoing { get; set; }
    }
}