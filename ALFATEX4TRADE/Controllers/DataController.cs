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
    public class DataController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Data
         [Authorize]

        public ActionResult Index()
        {
            int n = 0 ;
            foreach (var i in db.Data)
            {
                if (i.DailyNum > n && i.Date ==  DateTime.Today ) n = i.DailyNum;
            }
            return View(db.Data.Where(x => x.DailyNum == n && x.Date == DateTime.Today).ToList());
        }


        [HttpPost]

        public ActionResult Index(Data data )
        {
            if (ModelState.IsValid)
            {
                return View(db.Data.Where(x => x.DailyNum == data.DailyNum && x.Date == data.Date).ToList());
            }

            return RedirectToAction("Index");
        }


          [Authorize]
        public ActionResult AccountData()
        {
            return View(db.Data.Where(x => x.AccountID == "").ToList());
        }

        [HttpPost]
          public ActionResult AccountData(ChartOfAccounts c) 
          {
              if (ModelState.IsValid)
              {
                  if (c.OpeningDate == null)
                  {
                      c.OpeningDate = DateTime.MinValue;
                  }
                  if (c.EndingDate == null)
                  {
                      c.EndingDate = DateTime.MaxValue;
                  }


                  OpeningAndEnding op = new OpeningAndEnding();

                  foreach (var i in db.Balance)
                  {
                          db.Balance.Remove(i);
                      
                  }

                  foreach (var j in db.Data)
                  {
                      if (c.AccountID == j.AccountID)
                      {
                          if (j.Date <= c.OpeningDate)
                          {

                              op.OpeningBalace += Convert.ToDouble(j.DR);
                              op.OpeningBalace -= Convert.ToDouble(j.CR);
                          }
                          if (j.Date <= c.EndingDate)
                          {
                   
                              op.EndingBalace += Convert.ToDouble(j.DR);
                              op.EndingBalace -= Convert.ToDouble(j.CR);
                          }

                      }
                  }

                  db.Balance.Add(op);
                  db.SaveChanges();


                  return View(db.Data.Where(x => x.AccountID == c.AccountID && x.Date > c.OpeningDate &&
                      x.Date <= c.EndingDate).ToList());
              }
              return RedirectToAction("AccountData");
          }


         [Authorize]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (DailyTradeForm DF)
        {
            double dr = 0, cr = 0;
            for (int i = 0; i < DF.AccountID.Count(); i++)
            {
                if (DF.AccountID[i].Length == 0) continue;
                dr += DF.DR[i];
                cr += DF.CR[i];
            }

            if (dr != cr)
            {
               
                return View();

            }

            int dailyNum = 0;
            DateTime date = DateTime.Today;
            foreach (var i in db.Data)
            {
                if (i.Date == date && i.DailyNum >dailyNum )
                {
                    dailyNum = i.DailyNum ;
                }
            }

            dailyNum++;
            for (int i = 0; i < DF.AccountID.Count(); i++)
            {
                if (DF.AccountID[i].Length == 0 ) continue;
                Data data = new Data();
                data.DailyNum = dailyNum;
                data.Date = DateTime.Today;
                data.AccountID = DF.AccountID[i];
                data.CR = DF.CR[i] ;
                if (data.CR == 0) data.CR = null;
                data.DR = DF.DR[i];
                if (data.DR == 0) data.DR = null;
                data.AccountName = DF.AccountName[i] ;
              data.Description = DF.Description[i] ;
                db.Data.Add(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetName()
        {
            List<DailyTradeRecord> IdName = new List<DailyTradeRecord>();
            foreach (var i in db.Cleint)
            {
                IdName.Add(new DailyTradeRecord
                {
                    AccountID= (i.AccountID).ToString(),
                    AccountName = (i.AccountName).ToString()

                });
            }
            return Json(IdName, JsonRequestBehavior.AllowGet);
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
