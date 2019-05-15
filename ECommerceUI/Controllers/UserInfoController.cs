using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using E_Commerence.DataAccessLayer.Repositories;

namespace ECommerceUI.Controllers
{
    public class UserInfoController : MyController
    {
        // GET: UserInfo
        public ActionResult Profile(int page=1)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                int userId = int.Parse(Request.Cookies["userInfo"].Value);
                var model = unitOfWork.Orders.List(x => x.User.UserId == userId).OrderByDescending(x => x.CreationDate).ToPagedList(page, 15);
                return View(model);

            }
        }
    }
}