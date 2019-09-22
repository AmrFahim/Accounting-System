
namespace ALFATEX4TRADE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public  class Employee
    {



      [Display(Name = "��� ������ ")]
      [Key]

        public string EmpID { get; set; }

            [Display(Name = "��� ������ ")]

        public string EmpName { get; set; }

         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]

         [Display(Name = "����� �������  ")]

        public DateTime? Brithday { get; set; }

      [Display(Name = "�������")]

        public bool insurance { get; set; }
          
        [Display(Name = "����� ")]
        public string Department { get; set; }

              [Display(Name = "������ ")]

        public string Section { get; set; }

              [Display(Name = "����� ������")]

        public double Base { get; set; }

              [Display(Name = "���� ����� ")]

        public string Status { get; set; }

              [Display(Name = " ������ ")]
        
        public Nullable< int > AbsenceDays { get; set; }

              [Display(Name = " ����� ������� ")]

              public Nullable<double> OverTime { get; set; }

                      [Display(Name = " ����� ������� ")]

              public Nullable<double> Late { get; set; }

        
                      [Display(Name = "����� ������")]

              public Nullable<double> PermissionTime { get; set; }

                     [Display(Name = "���� ������")]

                     public Nullable<double> PermissiomTimeValue { get; set; }

                     [Display(Name = "�����")]
                     public Nullable<double> Loan { get; set; }

                      [Display(Name = "���� ���������")]

                     public Nullable<double> BuyValue { get; set; }
                      [Display(Name = "��� ���������")]

             public Nullable<double> Transportation { get; set; }
            [Display(Name = "��� �������")]
          public string Address { get; set; }
                      [Display(Name = "��������")]
            public Nullable<double> penalty { get; set; }



                     [Display(Name = "���� ������� ")]

                      public Nullable<double> OvertimeValue { get; set; }



                      [Display(Name = "���� ������")]

             public double PureSalary { get; set; }

            [Display(Name = "��������")]

            public string DisInsurance { get; set; }
            public Nullable<double> InsuranceValue { get; set; }

            public Nullable<double> LateValue { get; set; }

            public Nullable<double> Cuthafiz { get; set; }

            public Nullable<double> Totcut { get; set; }

            public Nullable<double> TotAdd { get; set; }

            public Nullable<double> AbsenceValue { get; set; }
    }
}
