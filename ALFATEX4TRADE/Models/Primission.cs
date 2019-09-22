
namespace ALFATEX4TRADE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public  class Primission
    {
        public int ID { get; set; }

         [Display(Name = "Stock Request Number")]

        public int PrimNumber { get; set; }

       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]

        public DateTime? Date { get; set; }

                      [Display(Name = "Account Code")]

        public string ClientID { get; set; }

                      [Display(Name = "Product Code")]

        public string ProductID { get; set; }

                      [Display(Name = "Description")]

        public string ProductName { get; set; }


        public double Outgoing { get; set; }

                      [Display(Name = "Account")]

        public string CleintName { get; set; }
    }
}
