using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALFATEX4TRADE.Models
{
    public class DailyTradeForm
    {

                [Display(Name = "Code")]

        public string[] AccountID { get; set; }

                [Display(Name = "Account")]

        public string[] AccountName { get; set; }
        public int[] DR { get; set; }
        public int[] CR { get; set; }

        public string[] Description { get; set; }

    }
}