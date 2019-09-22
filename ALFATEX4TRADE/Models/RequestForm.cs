using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALFATEX4TRADE.Models
{
    public class RequestForm
    {
                      [Display(Name = "Account Code")]
        public string ClientID { get; set; }

                      [Display(Name = "Account Name")]
        public string CleintName { get; set; }

                      [Display(Name = "Product Code")]
        public string[] ProductID { get; set; }

                      [Display(Name = "Product Description")]
        public string[] ProductName { get; set; }
        public int[] Outgoing { get; set; }




    }
}