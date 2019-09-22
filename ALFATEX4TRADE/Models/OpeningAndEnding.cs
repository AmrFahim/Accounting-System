using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALFATEX4TRADE.Models
{
    public class OpeningAndEnding
    {
        [Display(Name = "Opening Balance")]
        [Key]
        public double OpeningBalace { get; set; }

        [Display(Name = "Ending Balance")]

        public double EndingBalace { get; set; }
    }
}