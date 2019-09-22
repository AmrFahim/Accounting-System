using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALFATEX4TRADE.Models;

namespace ALFATEX4TRADE.Controllers
{
    public class StockTakingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationDbContext db2 = new ApplicationDbContext();
         public   List<Stocktaking> list = new List<Stocktaking>();
        // GET: StockTaking
        [Authorize]
        public ActionResult Index()
        {

            Stocktaking s = new Stocktaking();
            s.OpeningDate = DateTime.MinValue;
            s.EndingDate = DateTime.MaxValue;
            clc(s);
            return View(list);
        }
        [HttpPost]
        public ActionResult Index( Stocktaking st )
        {

                foreach (var i in db.Cleint)
                {
                    if (i.AccountID == st.CleintID)
                    {
                        st.CleintName = i.AccountName;
                        break;
                    }
                }
                 
            if (ModelState.IsValid)
            {

                if (st.OpeningDate == null)
                {
                    st.OpeningDate = DateTime.MinValue;
                }
                if (st.EndingDate == null)
                {
                    st.EndingDate = DateTime.MaxValue;
                }
                clc(st);

            }
            return View(list);
        }


        public void clc(Stocktaking st )
        {

            foreach (var i in db.Product)
            {
                Stocktaking cur = new Stocktaking();
                cur.CleintID = st.CleintID;
                cur.CleintName = st.CleintName;
                cur.ProductID = i.ProductID;
                cur.ProductName = i.Description;
                cur.Incoming = Convert.ToDouble(i.Incoming);
                cur.Size = i.Size;
                cur.OpeningDate = st.OpeningDate;
                cur.EndingDate = st.EndingDate;
                foreach (var j in db2.Primission)
                {
                    if (j.ProductID == i.ProductID &&
                        j.Date >= cur.OpeningDate && j.Date <= cur.EndingDate)
                    {
                        cur.Outgoing += j.Outgoing;

                        if (j.ClientID == cur.CleintID)
                        {
                            cur.CleintOutgoing += j.Outgoing;
                        }
                    }
                }
                cur.Balance = cur.Incoming - cur.Outgoing;
                list.Add(cur);
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