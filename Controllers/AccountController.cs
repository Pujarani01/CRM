using CRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class AccountController : Controller
    {
        UserDAL obj = new UserDAL();
        [HttpGet]
        public ActionResult Signin()
        {
            return View();
            
        }
        [HttpPost]
        public ActionResult Signin(user1 user)
        {
            user1 User = obj.AddUser(user);
            string id = User.Id.ToString();
            string name = User.Name;
            string email = User.Email;
            Session["Id"] = id;
            Session["Name"] = name;
            Session["Email"] = email;
            return RedirectToAction("Index", "App");

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtEmail)
        {
            user1 User = obj.GetUser(txtEmail);
            string id = User.Id.ToString();
            string name = User.Name;
            Session["Id"] = id;
            Session["Name"] = name;
            return RedirectToAction("Index","App");
        }
        public ActionResult Settings()
        {
            return View();
        }
    }
}