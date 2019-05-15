using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceUI.Class
{

    public class ReturnJson:Controller
    {
        public JsonResult returnNullCart()
        {
            return Json(new
            {
                status=0 ,
                product="" ,
                qty =0
            }, JsonRequestBehavior.AllowGet);
        }


    }
}