using E_Commerence.DataAccessLayer.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceUI.Controllers
{
    public class ProductListController : MyController
    {
        // GET: ProductList
        public ActionResult Index(int id,int page=1)
        {
            getCarts();
            using (var unitOfWork = new UnitOfWork())
            {
                var model = unitOfWork.Producsts.List(x => x.ProductCategory.CategoryId == id).OrderBy(x=>x.CreationDate).ToPagedList(page,15);
                return View(model);

            }
      
        }
    }
}