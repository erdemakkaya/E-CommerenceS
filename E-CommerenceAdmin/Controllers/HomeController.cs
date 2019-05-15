using E_Commerence.DataAccessLayer.Repositories;
using E_CommerenceAdmin.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace E_CommerenceAdmin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [LoginFilter]
        public ActionResult Index()
        {

            using (var unitOfWork = new UnitOfWork())
            {

                var model = unitOfWork.Orders.List(x => !x.IsDeleted).ToList();
                var logs = unitOfWork.Logs.List(x=>x.Type==2).OrderBy(x => x.LogCreationDate).ToList();
                var users = unitOfWork.Users.List().Count();
                ViewBag.UserCount = users;
                ViewBag.Total = model.Sum(x => x.OrdderAmount);
                ViewBag.Logs = logs;

                return View(model);
            }
        }
    }
}