using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALFATEX4TRADE.Models
{
    public class ChartOfAccounts
    {

          [Display(Name = " Code")]

        public string AccountID { get; set; }

                        [Display(Name = "Account")]

        public string AccountName { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Opening Date")]

        public DateTime? OpeningDate { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Ending Date")]

        public DateTime? EndingDate { get; set; }

                [Display(Name = "Opening Balance")]


        public double OpeningBalace { get; set; }

                [Display(Name = "Ending Balance")]

        public double EndingBalace { get; set; }

                [Display(Name = "Total DR")]

        public double TotDR { get; set; }

                [Display(Name = "Total CR")]

        public double TotCR { get; set; }
    }
}