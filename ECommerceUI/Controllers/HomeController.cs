using E_Commerence.DataAccessLayer.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceUI.Controllers
{
    public class HomeController : MyController
    {
        // GET: Home
        public ActionResult Index()
        {
           
            using (var unitOfWork = new UnitOfWork())
            {
                var s = unitOfWork.Producsts.Include(x => x.ProductCategory);
                SpecailList();
                setSliderList();
                getCarts();

                var model = unitOfWork.Producsts.List(x => !x.IsDeleted).ToList();

                return View(model);
            }
            //return View();
        }



        public void setSliderList()
        {

            using (var unitOfWork = new UnitOfWork())
            {

                var SliderList = unitOfWork.Sliders.List().Where(x => x.IsDeleted == false);
                ViewBag.Sliders = SliderList;
                var CategoryList= unitOfWork.Categories.List().Where(x => x.IsDeleted == false);
                ViewBag.Categories = CategoryList;

            }


        }

        public void SpecailList()
        {

            using (var unitOfWork = new UnitOfWork())
            {

                var BestProducts = unitOfWork.Producsts.List().OrderBy(x => x.ProductPrice).Take(5);
                ViewBag.Specials = BestProducts;

            }

        }
    }
}