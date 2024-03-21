using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class AppController : Controller
    {
        CustomerDAL obj = new CustomerDAL();
        public ActionResult Index()
        {
            return View(obj.GetCustomers());
        }
        [HttpGet]
        public ViewResult NewCustomer()
        {
            return View("NewCustomer");
        }
        [HttpPost]
        public ActionResult NewCustomer(Customer customer,string userid)
        {
            obj.AddCustomer(customer,userid);
            return RedirectToAction("Index");
        }
        public ActionResult CustomerDetails(int id)
        {
            Customer customer = obj.Getcustomer(id);
            return View(customer);
        }
    }
}