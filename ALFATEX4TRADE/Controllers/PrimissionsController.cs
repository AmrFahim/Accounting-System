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
    public class PrimissionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationDbContext db2 = new ApplicationDbContext() ;
        public int ReqN = new int ();
        public DateTime ReqDate = new DateTime();

        // GET: Primissions
         [Authorize]

        public ActionResult Index()
        {
            int n = 0;
            foreach (var i in db.Primission)
            {
                if (i.PrimNumber > n && i.Date == DateTime.Today) n = i.PrimNumber;
            }
            return View(db.Primission.Where(x => x.PrimNumber == n && x.Date == DateTime.Today).ToList());
        }
        [HttpPost]
        public ActionResult Index(Primission pr ) 
        {
            if (ModelState.IsValid)
            {
                return View(db.Primission.Where(x => x.PrimNumber == pr.PrimNumber && x.Date == pr.Date).ToList());
            }

            return RedirectToAction("Index");
        }

        public JsonResult GetProduct()
        {
            List<ProductRecord> ProductName = new List<ProductRecord>();
            foreach (var i in db.Product)
            {
                ProductName.Add(new ProductRecord
                {
                    ProductID = (i.ProductID).ToString() ,
                    ProductName = (i.Description).ToString()

                });
            }
            return Json(ProductName, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetName()
        {
            List<DailyTradeRecord> IdName = new List<DailyTradeRecord>();
            foreach (var i in db.Cleint)
            {
                IdName.Add(new DailyTradeRecord
                {
                    AccountID = (i.AccountID).ToString() ,
                    AccountName = (i.AccountName).ToString()

                });
            }
            return Json(IdName, JsonRequestBehavior.AllowGet);
        }




         [Authorize]
          public ActionResult Create()
        {
            return View();
        }

          [HttpPost]
          public ActionResult Create (RequestForm rf)
          {
              int ReqNum = 0;
              DateTime date = DateTime.Today;
              foreach (var i in db.Primission)
              {
                  if (i.Date == date && i.PrimNumber > ReqNum)
                  {
                      ReqNum = i.PrimNumber;
                  }
              }

              ReqNum++;
              for (int i = 0; i < rf.ProductID.Count(); i++)
              {
                  if (rf.ProductID[i].Length == 0) continue;
                  Primission pr = new Primission();
                  ReqN = ReqNum;
                  ReqDate = date ;
                  pr.PrimNumber = ReqNum;
                  pr.Date = date;
                  pr.ClientID = rf.ClientID;
                  pr.CleintName = rf.CleintName;
                  pr.ProductID = rf.ProductID[i];
                  pr.ProductName = rf.ProductName[i];
                  pr.Outgoing = rf.Outgoing[i];
                  db.Primission.Add(pr);
                  db.SaveChanges();
              }
               
                return RedirectToAction("NewBill");
          }



           [Authorize]

          public ActionResult NewBill()
          {
              return View();
          }

        [HttpPost]
          public ActionResult NewBill(BillForm bl)
          {

                  int dn = 0;
                  bl.Date = DateTime.Today;
                  foreach (var i in db.Data)
                  {
                      if (i.DailyNum > dn && i.Date == bl.Date) dn = i.DailyNum;
                  }
                  dn++;
                  var rqnum = 0;
                  foreach (var i in db.Primission)
                  {
                      if (i.Date == DateTime.Today && i.PrimNumber > rqnum)
                      {
                          rqnum = i.PrimNumber;
                      }

                  }
                  double Gtotal = 0;
                  for (int i = 0; i < bl.ProductID.Count(); i++)
                  {
                      if (bl.ProductID[i].Length == 0) continue;
                      Bill b = new Bill();
                      b.DailyID = dn;
                      b.BillNumber = rqnum;
                      b.CleintName = bl.CleintName;
                      b.ClientID = bl.ClientID;
                      b.Date = DateTime.Today;
                      b.Outgoing = bl.Outgoing[i];
                      b.Price = bl.Price[i];
                      b.Bag = bl.Bag[i];
                      b.ProductID = bl.ProductID[i];
                      b.ProductName = bl.ProductName[i];
                      b.Size = bl.Size[i];
                      b.Total = bl.Total[i];
                      Gtotal += Convert.ToDouble( b.Total );
                      db.Bill.Add(b);
                      db.SaveChanges();
                  }





                  Data data = new Data();
                  data.AccountID = bl.ClientID;
                  data.AccountName = bl.CleintName;
                  data.DailyNum = dn;
                  data.Date = DateTime.Today;
                  data.DR = Convert.ToDouble(Gtotal);
                  db.Data.Add(data);
                  db.SaveChanges();

                  for (int i = 0; i < bl.ProductID.Count(); i++)
                  {
                      if (bl.ProductID[i].Length == 0) continue;
                      Data d = new Data() ;
                      d.DailyNum = dn;
                      d.Date = DateTime.Today;
                      foreach (var cur in db.Product)
                      {
                          if (cur.ProductID == bl.ProductID[i] )
                          {
                              d.AccountID = cur.ValueToID + cur.ProductID;
                              d.AccountName = cur.Size + cur.Description;
                              break;
                          }
                      }     
                      d.CR =Convert.ToDouble( bl.Total[i]);
                      db.Data.Add(d);
                      db.SaveChanges();
                  }
        
              return RedirectToAction("Index");
          }


         [Authorize]

        public ActionResult DisBill()
        {
            int n = 0;
            foreach (var i in db.Bill)
            {
                if (i.BillNumber > n && i.Date == DateTime.Today) n = Convert.ToInt32( i.BillNumber) ;
            }

            return View(db.Bill.Where(x => x.BillNumber == n && x.Date == DateTime.Today).ToList());
        }


        [HttpPost]
        public ActionResult DisBill( Bill bill)
        {
            if (ModelState.IsValid)
            {

                return View(db.Bill.Where(x => x.BillNumber == bill.BillNumber && x.Date == bill.Date).ToList());
            }
            return RedirectToAction("DisBill");
        }




        public JsonResult Display()
        {
            List<BillRecord> dis = new List<BillRecord>();
            int rn = 0;
            DateTime dt = new DateTime();
            foreach (var i in db.Primission)
            {
                if (i.PrimNumber > rn)
                {
                    rn = i.PrimNumber;
                    dt = Convert.ToDateTime(i.Date);
                }
            }
            foreach (var i in db.Primission)
            {
                if (i.Date == dt && i.PrimNumber == rn)
                {


                    Product pd = new Product();
                   pd = db2.Product.Find(i.ProductID);
                    dis.Add(new BillRecord
                    {
                        ReqNum = i.PrimNumber,
                        ClientID = i.ClientID,
                        CleintName = i.CleintName,
                        Date = i.Date,
                        ProductID = i.ProductID,
                        ProductName = i.ProductName,
                        Outgoing = i.Outgoing,
                        Size = pd.Size,
                        Price = Convert.ToDouble(pd.Price) 


                    });
                }

            }
            return Json(dis, JsonRequestBehavior.AllowGet);
        }





        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Primission pr )
        {
            if (ModelState.IsValid)
            {
                foreach (var i in db.EditReq)
                {
                    db.EditReq.Remove(i);
             //       db.SaveChanges();
                }
                EditRequest e = new EditRequest();
                e.PrimNumber =Convert.ToInt32 (pr.PrimNumber) ;
                e.Date = pr.Date;
                db.EditReq.Add(e);
                db.SaveChanges();
                return RedirectToAction("EditReq");
            }
            return View();
        }
        public ActionResult EditReq()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EditReq(RequestForm rf )
        {
            int ReqNum = 0;
            int JournalNum = 0;
            DateTime date = new DateTime() ;
            foreach (var i in db.EditReq)
            {
                    ReqNum = i.PrimNumber;
                    date = Convert.ToDateTime(i.Date);
                    break;
            }

            foreach (var i in db.Primission)
            {
                if (i.PrimNumber == ReqNum)
                {
                    db.Primission.Remove(i);
       //             db.SaveChanges();
                }
            }

            foreach (var i in db.Bill)
            {
                if (i.BillNumber == ReqNum)
                {
                    JournalNum =Convert.ToInt32(i.DailyID);
                    db.Bill.Remove(i);
         //           db.SaveChanges();
                }
            }

            foreach (var i in db.Data)
            {
                if (i.DailyNum == JournalNum)
                {
                    db.Data.Remove(i);
         //           db.SaveChanges();
                }
            }
            db.SaveChanges();

            for (int i = 0; i < rf.ProductID.Count(); i++)
            {
                if (rf.ProductID[i].Length == 0) continue;
                Primission pr = new Primission();
                ReqN = ReqNum;
                ReqDate = date;
                pr.PrimNumber = ReqNum;
                pr.Date = date;
                pr.ClientID = rf.ClientID;
                pr.CleintName = rf.CleintName;
                pr.ProductID = rf.ProductID[i];
                pr.ProductName = rf.ProductName[i];
                pr.Outgoing = rf.Outgoing[i];
                db.Primission.Add(pr);
                db.SaveChanges();
            }

            return RedirectToAction("NewBill");
        }



        public JsonResult DisplayEdit()
        {
            List<ReqEditRecord> dis = new List<ReqEditRecord>();
            int num = 0;
            DateTime d = new DateTime();
            foreach (var i in db.EditReq)
            {
                num = i.PrimNumber;
                d = Convert.ToDateTime( i.Date) ;
                break;
            }

            foreach (var i in db2.Primission)
            {
                if (i.PrimNumber == num && i.Date == d )
                {
                    dis.Add(new ReqEditRecord
                    {
                        ClientID = i.ClientID,
                        CleintName = i.CleintName,
                        ProductID = i.ProductID,
                        ProductName = i.ProductName,
                        Outgoing = i.Outgoing
                    });
                }
            }
            return Json(dis, JsonRequestBehavior.AllowGet);
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
