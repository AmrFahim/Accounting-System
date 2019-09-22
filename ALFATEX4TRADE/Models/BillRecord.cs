using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALFATEX4TRADE.Models
{
    public class BillRecord
    {
        public int ReqNum { get; set; }
        public string ClientID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CleintName { get; set; }
                [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]

        public DateTime? Date { get; set; }

        public double Bag { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public string Size { get; set; }
        public double Outgoing { get; set; }
    }
}