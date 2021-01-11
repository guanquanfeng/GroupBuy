using GroupBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GroupBuy.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var orders = db.Orders.Where(o => o.UserId == User.Identity.Name).Where(o=>o.Current==true).ToList();
            int c = orders.Count;
            ViewBag.number = c;
            var products = db.Products.Where(p=>p.Star == true).Include(p => p.Categories);
            return View(products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Add(int id)
        {
            var order = new Order();
            order.UserId = User.Identity.Name;
            order.Current = true;
            order.Amount = 1;
            order.ProductId = id;

            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}