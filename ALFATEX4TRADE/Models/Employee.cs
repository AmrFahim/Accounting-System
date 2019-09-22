
namespace ALFATEX4TRADE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public  class Employee
    {



      [Display(Name = "ﬂÊœ «·„ÊŸ› ")]
      [Key]

        public string EmpID { get; set; }

            [Display(Name = "≈”„ «·„ÊŸ› ")]

        public string EmpName { get; set; }

         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]

         [Display(Name = " «—ÌŒ «·„Ì·«œ  ")]

        public DateTime? Brithday { get; set; }

      [Display(Name = "«· √„Ì‰")]

        public bool insurance { get; set; }
          
        [Display(Name = "«·ﬁ”„ ")]
        public string Department { get; set; }

              [Display(Name = "«·’«·… ")]

        public string Section { get; set; }

              [Display(Name = "√”«”Ì «·„— »")]

        public double Base { get; set; }

              [Display(Name = "Õ«·… «·⁄„· ")]

        public string Status { get; set; }

              [Display(Name = " «·€Ì«» ")]
        
        public Nullable< int > AbsenceDays { get; set; }

              [Display(Name = " ”«⁄«  «·≈÷«›Ì ")]

              public Nullable<double> OverTime { get; set; }

                      [Display(Name = " ”«⁄«  «· √ŒÌ— ")]

              public Nullable<double> Late { get; set; }

        
                      [Display(Name = "”«⁄«  «·√–Ê‰")]

              public Nullable<double> PermissionTime { get; set; }

                     [Display(Name = "ﬁÌ„… «·√–Ê‰")]

                     public Nullable<double> PermissiomTimeValue { get; set; }

                     [Display(Name = "«·”·›")]
                     public Nullable<double> Loan { get; set; }

                      [Display(Name = "ﬁÌ„… «·„‘ —Ì« ")]

                     public Nullable<double> BuyValue { get; set; }
                      [Display(Name = "»œ· «·„Ê«’·« ")]

             public Nullable<double> Transportation { get; set; }
            [Display(Name = "„Õ· «·«ﬁ«„Â")]
          public string Address { get; set; }
                      [Display(Name = "«·Ã“«¡« ")]
            public Nullable<double> penalty { get; set; }



                     [Display(Name = "ﬁÌ„… «·≈÷«›Ì ")]

                      public Nullable<double> OvertimeValue { get; set; }



                      [Display(Name = "’«›Ì «·„— »")]

             public double PureSalary { get; set; }

            [Display(Name = "«· √„‹Ì‰")]

            public string DisInsurance { get; set; }
            public Nullable<double> InsuranceValue { get; set; }

            public Nullable<double> LateValue { get; set; }

            public Nullable<double> Cuthafiz { get; set; }

            public Nullable<double> Totcut { get; set; }

            public Nullable<double> TotAdd { get; set; }

            public Nullable<double> AbsenceValue { get; set; }
    }
}
