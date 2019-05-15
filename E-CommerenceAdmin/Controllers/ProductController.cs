
using E_Commerence.DataAccessLayer.Repositories;
using E_CommerenceAdmin.Class;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using E_CommerenceAdmin.CustomFilter;

namespace E_CommerenceAdmin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [ExceptionFilter]
        public ActionResult Index(int page = 1)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                setCategorieList();
                var model = unitOfWork.Producsts.List(x => !x.IsDeleted).OrderByDescending(x => x.ProductId).ToPagedList(page, 10);

                return View(model);
            }

        }
        [HttpPost,ExceptionFilter]
        public ActionResult Index(string search,int page = 1)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                setCategorieList();
                var filtermodel = unitOfWork.Producsts.List(x => x.ProductName.ToLower().Contains(search) ||
                x.ProductDesc.ToLower().Contains(search) || x.ProductCategory.CategoryName.ToLower().Contains(search) ||
                x.ProductPrice.ToString().ToLower().Contains(search)
).OrderByDescending(x => x.ProductId).ToPagedList(page, 10);

                return View("Index",filtermodel);
            }

        }


        [ActFilter, ExceptionFilter, ValidateInput(false)]
   public ActionResult Add()
        {
            setCategorieList();
            return View();
        }
        [HttpPost, ExceptionFilter, ValidateInput(false)]
        public ActionResult Add(Products pro, HttpPostedFileBase file)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                if (file != null)
                {

                    FileHelper filehelper = new FileHelper();
                    var mpath = Server.MapPath("~/Images/Product");

                    pro.ProductImage = filehelper.SaveImage(file, mpath, "/Images/Product");
                    pro.CreationDate = DateTime.Now;
                    pro.ProductCategory = unitOfWork.Categories.Find(x => x.CategoryId == pro.ProductCategory.CategoryId);
                    unitOfWork.Producsts.Insert(pro);

                }
                return RedirectToAction("Index", "Product");
            }

        }


        [ActFilter, ExceptionFilter]


        public JsonResult DeleteProduct(int id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Products pro = unitOfWork.Producsts.Find(x => x.ProductId == id);
                if (pro == null)
                {
                    return Json(new ResultJson { Success = false, Message = "Kategori Bulunamadı." });
                }
                pro.IsDeleted = true;




                unitOfWork.Producsts.Save();



                return Json(new ResultJson { Success = true, Message = "Kategori Silinmiştir." });
            }


        }

        [ActFilter, ExceptionFilter]

        public ActionResult Update(int id)
        {
            using (var unitOfWork = new UnitOfWork())
            {

                setCategorieList();
                var itemProduct = unitOfWork.Producsts.Find(x => x.ProductId == id);


                return View(itemProduct);

            }

        }
        [HttpPost, ExceptionFilter]
        public ActionResult Update(Products pro, HttpPostedFileBase file)
        {
            using (var unitOfWork = new UnitOfWork())
            {

                var temp = unitOfWork.Producsts.Find(x => x.ProductId == pro.ProductId);
                if (file != null)
                {

                    FileHelper filehelper = new FileHelper();
                    var mpath = Server.MapPath("~/Images/Product");

                    pro.ProductImage = filehelper.SaveImage(file, mpath, "/Images/Product");
                    pro.CreationDate = DateTime.Now;
                    temp.ProductName = pro.ProductName;
                    temp.ProductStock = pro.ProductStock;
                    temp.ProductPrice = pro.ProductPrice;
                    temp.ProductDesc = pro.ProductDesc;
                    temp.ProductImage = pro.ProductImage;
                    temp.Discount = pro.Discount;
                    temp.ProductCategory = pro.ProductCategory;
                    temp.IsActive = pro.IsActive;
                    temp.CreationDate = pro.CreationDate;



                }




                unitOfWork.Producsts.Save();



                return RedirectToAction("Index", "Product");

            }

        }
        [ExceptionFilter]
        public void setCategorieList()
        {

            using (var unitOfWork = new UnitOfWork())
            {

                var CategoryList = unitOfWork.Categories.List().Where(x => x.IsDeleted == false);
                ViewBag.Category = CategoryList;
             

            }


        }
    }
}