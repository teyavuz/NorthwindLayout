using MVC_NorthwindLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_NorthwindLayout.Controllers
{
    public class OrderController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        public PartialViewResult _OrderDetail()
        {
            return PartialView(db.Order_Details.ToList());
        }
    }
}