using GroupBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroupBuy.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        

        public void GetProduct(int id)
        {
            var tmp = db.Orders.Where(o => o.ProductId == id).Where(o => o.UserId == User.Identity.Name).SingleOrDefault(o => o.Current == true);
            if (tmp != null)
            {
                tmp.Amount += 1;
                db.SaveChanges();
                return;

                
            }

            var order = new Order();
            order.UserId = User.Identity.Name;
            order.Current = true;
            order.Amount = 1;
            order.ProductId = id;

            db.Orders.Add(order);
            db.SaveChanges();
            
        }
    }
}
