using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupBuy.Models;

namespace GroupBuy.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Menu
        public ActionResult Index(int? id)
        {
            var orders = db.Orders.Where(o => o.UserId == User.Identity.Name).Where(o => o.Current == true).ToList();
            int c = orders.Count;
            ViewBag.number = c;
            
            if (id != null)
            {
                var products = db.Products.Where(p => p.CateId == id).Include(p => p.Categories);
                return View(products.ToList());
            }
            else
            {
                var products = db.Products.Include(p => p.Categories);
                return View(products.ToList());
            }
            
            
        }

        

        public ActionResult Add(int id)
        {
            var tmp = db.Orders.Where(o => o.ProductId == id).Where(o => o.UserId == User.Identity.Name).SingleOrDefault(o => o.Current == true);
            if (tmp != null)
            {
                tmp.Amount += 1;
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            
            var order = new Order();
            order.UserId = User.Identity.Name;
            order.Current = true;
            order.Amount = 1;
            order.ProductId = id;

            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Menu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName");
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,Totle,Remaining,InStock,UserName,ImageUrl,CateId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", product.CateId);
            return View(product);
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", product.CateId);
            return View(product);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Totle,Remaining,InStock,UserName,ImageUrl,CateId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", product.CateId);
            return View(product);
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
