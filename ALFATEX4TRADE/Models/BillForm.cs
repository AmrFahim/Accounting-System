using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALFATEX4TRADE.Models
{
    public class BillForm
    {


        public int DailyID { get; set; }
        public int BillNumber { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]

        public DateTime? Date { get; set; }

                [Display(Name = "Cleint Code")]

        public string ClientID { get; set; }

                [Display(Name = "Product Code")]

        public string[] ProductID { get; set; }

                [Display(Name = "Product Description")]

        public string[] ProductName { get; set; }

                [Display(Name = "Cleint Name")]

        public string CleintName { get; set; }

                [Display(Name = "Quantity (بالكيس)")]

        public double[] Bag { get; set; }
        public double[] Price { get; set; }
        public double[] Total { get; set; }
        public string[] Size { get; set; }

                        [Display(Name = "Quantity (بالدستة)")]

        public double[] Outgoing { get; set; }

        public Double GTotal { get; set; }
    }
}