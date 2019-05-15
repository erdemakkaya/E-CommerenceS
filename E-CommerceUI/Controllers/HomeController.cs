using E_Commerence.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerceUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                
                var model = unitOfWork.Producsts.List(x => !x.IsDeleted).ToList();

                return View(model);
            }

           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}