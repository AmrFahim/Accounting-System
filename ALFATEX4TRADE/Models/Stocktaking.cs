using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALFATEX4TRADE.Models
{
    public class Stocktaking
    {
             [Display(Name = "Account Code")]

        public string CleintID { get; set; }

                              [Display(Name = "Account Name")]

        public string CleintName { get; set; }

                              [Display(Name = "Product Code")]

        public string ProductID { get; set; }

                              [Display(Name = "Product Description")]

        public string ProductName { get; set; }

        public string Size { get; set; }

        public double Incoming { get; set; }

        public double Outgoing { get; set; }

        public double Balance { get; set; }

                              [Display(Name = "Cleint Outgoing")]

        public double CleintOutgoing { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Opening Date")]

        public DateTime? OpeningDate { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]

        [Display(Name = "Ending Date")]

        public DateTime? EndingDate { get; set; }


    }
}