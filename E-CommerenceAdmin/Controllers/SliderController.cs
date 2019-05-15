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
    public class SliderController : Controller
    {
        // GET: Slider
        [ActFilter,ExceptionFilter]

        public ActionResult Index(int page=1)
        {
            using (var unitOfWork = new UnitOfWork())
            {

                var model = unitOfWork.Sliders.List(x => !x.IsDeleted).OrderByDescending(x => x.SliderId).ToPagedList(page, 10);

                return View(model);
            }

        }
        [ActFilter,ExceptionFilter]

        public ActionResult Add()
        {

            return View();
        }
        [HttpPost,ExceptionFilter]
        public ActionResult Add(Sliders sld, HttpPostedFileBase file)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                if (file != null)
                {

                    FileHelper filehelper = new FileHelper();
                    var mpath = Server.MapPath("~/Images/Slider");

                    sld.SliderImageUrl = filehelper.SaveImage(file, mpath, "/Images/Slider");
                    sld.CreationDate = DateTime.Now;

                    unitOfWork.Sliders.Insert(sld);

                }
                return RedirectToAction("Index", "Slider");
            }

        }



        [ActFilter,ExceptionFilter]

        public JsonResult Delete(int id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Sliders slider = unitOfWork.Sliders.Find(x => x.SliderId == id);
                if (slider == null)
                {
                    return Json(new ResultJson { Success = false, Message = "Kategori Bulunamadı." });

                }
                slider.IsDeleted = true;




                unitOfWork.Sliders.Save();



                return Json(new ResultJson { Success = true, Message = "Kategori Silinmiştir." });
            }


        }


        public ActionResult Update(int id)
        {
            using (var unitOfWork = new UnitOfWork())
            {


                var slider = unitOfWork.Sliders.Find(x => x.SliderId == id);


                return View(slider);

            }

        }
        [HttpPost,ActFilter,ExceptionFilter]
        public ActionResult Update(Sliders slider, HttpPostedFileBase file)
        {
            using (var unitOfWork = new UnitOfWork())
            {

                var temp = unitOfWork.Sliders.Find(x => x.SliderId == slider.SliderId);
                if (file != null)
                {

                    FileHelper filehelper = new FileHelper();
                    var mpath = Server.MapPath("~/Images/Product");

                   slider.SliderImageUrl = filehelper.SaveImage(file, mpath, "/Images/Slider");
                    slider.CreationDate = DateTime.Now;
                    temp.SliderTitle = slider.SliderTitle;
                   
                    temp.SliderImageUrl = slider.SliderImageUrl;
                   
                    temp.IsActive = slider.IsActive;
                    temp.CreationDate = slider.CreationDate;



                }




                unitOfWork.Sliders.Save();



                return RedirectToAction("Index", "Slider");

            }

        }

    }
}