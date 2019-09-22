
namespace ALFATEX4TRADE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public  class Cleint
    {

                [Key]
        [Display(Name = " Code ")]
        public string AccountID { get; set; }

        [Display(Name = "Account")]
        public string AccountName { get; set; }
    }
}
