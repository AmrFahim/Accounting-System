
namespace ALFATEX4TRADE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Bill
    {
        public int ID { get; set; }

        [Display(Name = "Bill Number")]
        public Nullable<int> BillNumber { get; set; }

      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]

        public DateTime? Date { get; set; }

      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]

      public DateTime? JournalDate { get; set; }



        [Display(Name = "Cleint Code ")]
        public string ClientID { get; set; }

        [Display(Name = "Product Code ")]
        public string ProductID { get; set; }

        [Display(Name = "Product Description")]
        public string ProductName { get; set; }
        public Nullable<double> Price { get; set; }

        [Display(Name = "Cleint Name ")]
        public string CleintName { get; set; }

        [Display(Name = "Quantity (»«·ﬂÌ”)")]
        public Nullable<double> Bag { get; set; }
        public Nullable<int> DailyID { get; set; }
        public Nullable<double> Total { get; set; }
        public string Size { get; set; }
        [Display(Name = "Quantity (»«·œ” …)")]
        public Nullable<double> Outgoing { get; set; }

        public int counter { get; set; }

        public double  GeneralTotal { get; set; }
        public double GBags { get; set; }

        public double Goutgoing { get; set; }
    }
}
