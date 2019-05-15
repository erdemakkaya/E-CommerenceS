using E_Commerence.DataAccessLayer.Repositories;
using ECommerceUI.Class;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceUI.Controllers
{
    public class LoginController : MyController
    {
        // GET: Login
       public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            var user = new UnitOfWork();
            var state = user.Users.Find(x => x.UserEmail == email && x.UserPassword == password);
            if (state != null)
            {


                HttpCookie userCookie = new HttpCookie("userInfo");

                userCookie.Value = state.UserId.ToString();
                userCookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(userCookie);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users customer)
         {

            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Users.Insert(customer);
                
                return RedirectToAction("SignIn","Login");
            }
        }

        public ActionResult LogOut()
        {
            HttpCookie userCookie = new HttpCookie("userInfo");
            userCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(userCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}