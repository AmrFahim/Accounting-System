using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALFATEX4TRADE.Models;


namespace ALFATEX4TRADE.Controllers
{
    public class ChartOfAccuntsController : Controller

    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationDbContext db2 = new ApplicationDbContext();
       public  List<ChartOfAccounts> MyList = new List<ChartOfAccounts>();


        // GET: ChartOfAccunts
         [Authorize]

        public ActionResult Index()
        {
            ChartOfAccounts t = new ChartOfAccounts();
            t.OpeningDate = Convert.ToDateTime(DateTime.MinValue);
            t.EndingDate = Convert.ToDateTime(DateTime.MaxValue);
            clc(t);
            return View(MyList);
        }

        [HttpPost]
        public ActionResult Index(ChartOfAccounts ch)
        {

            if (ModelState.IsValid)
            {

                if (ch.OpeningDate == null)
                {
                    ch.OpeningDate = DateTime.MinValue;
                }
                if (ch.EndingDate == null)
                {
                    ch.EndingDate = DateTime.MaxValue;
                }
                clc(ch); 
                return View(MyList);
            }
            return View(MyList);
        }



        public void clc(ChartOfAccounts ch )
        {


            foreach (var i in db.Cleint)
            {
                ChartOfAccounts account = new ChartOfAccounts();
                account.AccountID = i.AccountID;
                account.AccountName = i.AccountName;
                account.OpeningDate = ch.OpeningDate;
                account.EndingDate = ch.EndingDate;
                foreach (var j in db2.Data)
                {
                    if (i.AccountID == j.AccountID)
                    {
                        if (j.Date <= account.OpeningDate)
                        {
                            account.TotDR -= Convert.ToDouble(j.DR);
                            account.TotCR -= Convert.ToDouble(j.CR);
                            account.OpeningBalace += Convert.ToDouble(j.DR);
                            account.OpeningBalace -= Convert.ToDouble(j.CR);
                        }
                        if (j.Date <= account.EndingDate)
                        {
                            account.TotDR += Convert.ToDouble(j.DR);
                            account.TotCR += Convert.ToDouble(j.CR);
                            account.EndingBalace += Convert.ToDouble(j.DR);
                            account.EndingBalace -= Convert.ToDouble(j.CR);
                        }

                    }
                }
                MyList.Add(account);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}