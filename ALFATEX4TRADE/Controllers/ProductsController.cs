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
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Product.ToList());
        }

        [HttpPost]
        public ActionResult Index(Product pr)
        {
            pr.Size = "1";
            pr.Description = "f";
            pr.ValueToID = "q";
            if (ModelState.IsValid)
            {
             
                return View(db.Product.Where(x => x.ProductID == pr.ProductID).ToList());
            }
            return RedirectToAction("Index");

        }


 

        // GET: Products/Create
         [Authorize]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Description,Size,Session,ValueToID,Incoming,Price")] Product product)
        {
            bool IsIdExist = db.Product.Any(x => x.ProductID == product.ProductID);
            if (IsIdExist == true)
            {
                ModelState.AddModelError("ProductID", "ID already exists");
            }


            if (ModelState.IsValid)
            {
                Cleint c = new Cleint();
                c.AccountName = product.Size + product.Description;
                c.AccountID = product.ValueToID + product.ProductID;
                db.Cleint.Add(c);
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }


        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

         [Authorize]
        // GET: Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
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
