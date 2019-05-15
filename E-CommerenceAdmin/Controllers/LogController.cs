using E_Commerence.DataAccessLayer.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerenceAdmin.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult Index(int page=1)
        {
            using (var unitOfWork = new UnitOfWork())
            {

                return View(unitOfWork.Logs.List().OrderByDescending(x => x.LogCreationDate).ToPagedList(page, 50));
            }

        }
    }
}