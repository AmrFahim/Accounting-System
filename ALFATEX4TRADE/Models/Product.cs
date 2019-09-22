
namespace ALFATEX4TRADE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public  class Product
    {
        [Required]

        [Display(Name = "Product Code")]

        public string ProductID { get; set; }

                      [Display(Name = "Product Description")]

        public string Description { get; set; }
        public string Size { get; set; }
        public double Incoming { get; set; }
        public double Price { get; set; }

        public string Session { get; set; }

          [Display(Name = "Append to Account")]

        public string ValueToID { get; set; }
    }
}
