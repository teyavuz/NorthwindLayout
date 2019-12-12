using MVC_NorthwindLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_NorthwindLayout.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Detail(int id)//5
        {
            var products = db.Products.Where(x => x.CategoryID == id).ToList();
            return View(products);
        }
    }
}