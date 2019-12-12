using MVC_NorthwindLayout.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_NorthwindLayout.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            /*
             select top 5 c.CompanyName,SUM(od.Quantity*UnitPrice*(1-discount)) from Orders o join [Order Details] od on o.OrderID=od.OrderID join Customers c on o.CustomerID=c.CustomerID group by c.CompanyName order by 2 desc
             */

            var companies = db.Order_Details.Sum(x => (float)x.Quantity * (float)x.UnitPrice * 1 - (x.Discount));
            var totalCompanies = db.Order_Details.GroupBy(x => x.Order.Customer.CompanyName).OrderByDescending(x=>x.Sum(y=> (float)y.Quantity * (float)y.UnitPrice * 1 - (y.Discount))).Take(5).ToList();

            List<string> bestCompanies = new List<string>();
            foreach (var item in totalCompanies)
            {
                bestCompanies.Add(item.Key);
            };


            ViewBag.BestCompanies = bestCompanies;
            ViewBag.CokSatanlar = BestSeller(5);

            return View(db.Products.ToList());
        }

        public PartialViewResult _CategoryPartial()
        {
            return PartialView(db.Categories.ToList());
        }

        //En çok Satışı gerçekleşen ürünlerden n tanesi
        public List<string> BestSeller(int count)
        {
            var products = db.Order_Details.GroupBy(x => x.Product.ProductName).OrderByDescending(x => x.Sum(y => y.Quantity)).Take(count).ToList();

            List<string> urunler = new List<string>();

            foreach (var item in products)
            {
                urunler.Add(item.Key);
            }
            return urunler;
        }
        //en çok satış yapmış olduğumuz (Kar getiren) şirketlerden 5 tanesi 


    }
}