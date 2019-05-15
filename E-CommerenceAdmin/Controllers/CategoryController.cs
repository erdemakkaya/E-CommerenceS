using E_Commerence.DataAccessLayer.EntityFramwork;
using E_Commerence.DataAccessLayer.Repositories;
using E_CommerenceAdmin.Class;
using E_CommerenceAdmin.CustomFilter;
using Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerenceAdmin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [ExceptionFilter]
        public ActionResult Index(int page=1)
        {
            using (var unitOfWork = new UnitOfWork())
            {

                return View(unitOfWork.Categories.List().Where(x => x.IsDeleted == false).OrderByDescending(x => x.CategoryId).ToPagedList(page, 10));
            }

        }
        [ActFilter,ExceptionFilter]
        public ActionResult Add()
        {
            setCategorieList();
            return View();
        }
        [HttpPost,ExceptionFilter]
        public ActionResult Add(Categories cat)
        {

            using (var unitOfWork = new UnitOfWork())
            {
                cat.CreationDate = DateTime.Now;
                unitOfWork.Categories.Insert(cat);
                //return View("");
                return RedirectToAction("Index");

            }


        }

        [ExceptionFilter]

        public void setCategorieList()
        {

            using (var unitOfWork = new UnitOfWork())
            {

                var CategoryList = unitOfWork.Categories.List().Where(x => x.ParentId == 0);
                ViewBag.Category = CategoryList;


            }


        }

        [ActFilter,ExceptionFilter]

        public JsonResult DeleteCategory(int id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Categories cat = unitOfWork.Categories.Find(x => x.CategoryId == id);
                if (cat == null)
                {
                    return Json(new ResultJson { Success = false, Message = "Kategori Bulunamadı." });
                    //olay ne :D dur göstereym bi  eyv kankahatayı anladın mı :D yok kanka ne farkettiki anlamadım yine alıyordu id yi
                }
                cat.IsDeleted = true;
                if (cat.ParentId == 0)
                {
                    var subCategory = unitOfWork.Categories.List(x => x.ParentId == cat.CategoryId).ToList();
                    foreach (var item in subCategory)
                    {
                        item.IsDeleted = true;
                    }


                }
                unitOfWork.Categories.Save();




                return Json(new ResultJson { Success = true, Message = "Kategori Silinmiştir." });
            }


        }
        [ActFilter,ExceptionFilter]

        public ActionResult UpdateCategory(int id)
        {
            using (var unitOfWork = new UnitOfWork())
            {

                setCategorieList();
                var itemCategory = unitOfWork.Categories.Find(x => x.CategoryId == id);


                return View(itemCategory);

            }

        }
        [HttpPost,ExceptionFilter]
        public ActionResult UpdateCategory(Categories cat)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                cat.CreationDate = DateTime.Now;
                var temp = unitOfWork.Categories.Find(x => x.CategoryId == cat.CategoryId);
                temp.CategoryName = cat.CategoryName;
                temp.Url = cat.Url;
                temp.ParentId = cat.ParentId;
                temp.IsActive = cat.IsActive;
                temp.CreationDate = cat.CreationDate;


                unitOfWork.Categories.Save();

                return RedirectToAction("Index");


            }

        }


    }

}

