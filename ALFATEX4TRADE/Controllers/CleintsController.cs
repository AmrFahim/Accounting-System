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
    public class CleintsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cleints
                [Authorize]

        public ActionResult Index()
        {
            return View(db.Cleint.ToList());
        }


        [HttpPost]
        public ActionResult Index(Cleint cl)
        {
            if (ModelState.IsValid)
            {
                
                return View(db.Cleint.Where(x => x.AccountID == cl.AccountID).ToList());
            }
            return RedirectToAction("Index");

        }


        




        // GET: Cleints/Create
        [Authorize]

          public ActionResult Create()
        {
            return View();
        }

        // POST: Cleints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountID,AccountName")] Cleint cleint)
        {
            bool IsIdExist = db.Cleint.Any(x => x.AccountID == cleint.AccountID);
            if (IsIdExist == true)
            {
                ModelState.AddModelError("AccountID", "ID already exists");
            }

            if (ModelState.IsValid)
            {
                db.Cleint.Add(cleint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cleint);
        }



       [Authorize]

        // GET: Cleints/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cleint cleint = db.Cleint.Find(id);
            if (cleint == null)
            {
                return HttpNotFound();
            }
            return View(cleint);
        }

        // POST: Cleints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cleint cleint = db.Cleint.Find(id);
            db.Cleint.Remove(cleint);
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
    }
}
