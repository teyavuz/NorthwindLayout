using MVC_NorthwindLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_NorthwindLayout.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            db.Products.Add(product);
            //db.SaveChanges();
            if (db.SaveChanges() > 0)
            {
                TempData["Info"] = "Kaydetme Başarılı";
            }
            else
            {
                TempData["Info"] = "Kaydetme Başarısız";
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateProduct(int id)
        {
            if (id == null)
            {
                ViewBag.Error = "Id boş gönderilemez!";
            }
            Product product = db.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                TempData["Info"] = "Kaydetme Başarılı";
            }
            else
            {
                TempData["Info"] = "Kaydetme Başarısız";
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            if (id == null)
            {
                ViewBag.Error = "Id boş gönderilemez!";
            }
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            if (db.SaveChanges() > 0)
            {
                TempData["Info"] = "Silme Başarılı";
            }
            else
            {
                TempData["Info"] = "Silme Başarısız";
            }
            return RedirectToAction("Index");
        }
    }
}