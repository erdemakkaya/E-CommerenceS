using E_Commerence.DataAccessLayer.EntityFramwork;
using E_Commerence.DataAccessLayer.Repositories;
using E_CommerenceAdmin.CustomFilter;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerenceAdmin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
          
            return View(new AdminInfo());
        }

        [HttpPost,ExceptionFilter]
        public ActionResult SignIn(string name, string password)
        {
            var user = new UnitOfWork();
            var state = user.Admins.Find(x=>x.UserName==name&&x.AdminPw==password);
            if (state != null) {

                Session["login"] = state;
                
                return RedirectToAction("Index", "Home");
}
          
            return View();
        }
    }
}