
namespace ALFATEX4TRADE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Data
    {
        public int ID { get; set; }

        [Display(Name = "Journal Entry Number  ")]
        public int DailyNum { get; set; }

        [Display(Name = " Code ")]
        public string AccountID { get; set; }

      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]

        public DateTime? Date { get; set; }
        public Nullable<double> DR { get; set; }
        public Nullable<double> CR { get; set; }

                [Display(Name = "Account")]

        public string AccountName { get; set; }

         public string Description { get; set; }

    }
}
