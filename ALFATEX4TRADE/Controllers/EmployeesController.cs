using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ALFATEX4TRADE.Models;

namespace ALFATEX4TRADE.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Employees
        [Authorize]

        public ActionResult Index()
        {
            Calculate();

            return View(db.Employee.ToList());
        }

        [HttpPost]
        public ActionResult Index(Employee em)
        {
            if (ModelState.IsValid)
            {
                Calculate();
                return View(db.Employee.Where(x => x.EmpID == em.EmpID).ToList());
            }
            return RedirectToAction("Index");

        }



        [Authorize]

        public ActionResult print()
        {

            Calculate();
            return View(db.Employee.ToList());
        }


        // GET: Employees/Details/5

        // GET: Employees/Create
      [Authorize]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


      // [Bind(Include = "EmpID,EmpName,Brithday,insurance,Department,Section,Base,Status,AbsenceDays,Loan,PermissionTime,PermissiomTimeValue,BuyValue,penalty,PureSalary")] 
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }


          [Authorize]

        // GET: Employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [Authorize]

        // GET: Employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Calculate()
        {
           foreach (var i in db.Employee)
            {
                Convert.ToDouble(i.AbsenceDays);
                Convert.ToDouble(i.AbsenceValue);
                Convert.ToDouble(i.Base);
                Convert.ToDouble(i.BuyValue);
                Convert.ToDouble(i.Cuthafiz);
                Convert.ToDouble(i.InsuranceValue);
                Convert.ToDouble(i.LateValue);
                Convert.ToDouble(i.Loan);
                Convert.ToDouble(i.OvertimeValue);
                Convert.ToDouble(i.penalty);
                Convert.ToDouble(i.PermissiomTimeValue);
                Convert.ToDouble(i.PureSalary);
                Convert.ToDouble(i.TotAdd);
                Convert.ToDouble(i.Totcut);
                Convert.ToDouble(i.Transportation);
                Convert.ToDouble(i.Late);



                if (i.insurance == true)
                {
                    i.DisInsurance = "مؤمن عليه ";
                    DateTime brith = Convert.ToDateTime(i.Brithday);
                    int age = DateTime.Today.Year - brith.Year;
                    if (age < 18) i.InsuranceValue = 25;
                    else i.InsuranceValue = 85 ; 
                }
                else
                {
                    i.DisInsurance = "غير مؤمن عليه ";
                }
                if (Convert.ToDouble(i.AbsenceDays) < 2) {
                i.Cuthafiz = 0;
                
                }
                else if (Convert.ToDouble(i.AbsenceDays) == 2) { 
               
                i.Cuthafiz = 50 ;
                }
                else i.Cuthafiz = 100 ;
                if (i.AbsenceDays > 0 )
                i.AbsenceValue = Convert.ToDouble(i.Base) / Convert.ToDouble(i.AbsenceDays);
                if (i.Late > 0)
                    i.LateValue =( i.Base / (30 * 80) ) * i.Late ;

                if (i.PermissionTime > 0)
                    i.PermissiomTimeValue = (i.Base / (30 * 80)) * i.PermissionTime;

                i.Totcut =Convert.ToDouble( i.Cuthafiz) + Convert.ToDouble(i.InsuranceValue) + 
                    Convert.ToDouble(i.penalty) + Convert.ToDouble(i.Loan) + Convert.ToDouble(i.BuyValue)
                    + Convert.ToDouble(i.LateValue) + Convert.ToDouble(i.PermissiomTimeValue) + i.AbsenceValue ;
                i.TotAdd = Convert.ToDouble(i.Base) + Convert.ToDouble(i.Transportation) +
                    Convert.ToDouble(i.OvertimeValue) + 100 ;
                i.PureSalary = Convert.ToDouble( i.TotAdd )  - Convert.ToDouble( i.Totcut) ;
            }
        }
    }
}
