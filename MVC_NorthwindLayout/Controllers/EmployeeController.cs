using MVC_NorthwindLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_NorthwindLayout.Controllers
{
    public class EmployeeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {

            ViewBag.DogumGunu = GetBirthdate();
            return View(db.Employees.ToList());
        }

        public List<Employee> GetBirthdate()
        {
            return db.Employees.Where(x => x.BirthDate.Value.Month == DateTime.Now.Month && x.BirthDate.Value.Day == DateTime.Now.Day).ToList();
        }
    }
}