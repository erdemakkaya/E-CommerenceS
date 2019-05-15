using E_Commerence.DataAccessLayer.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerenceAdmin.CustomFilter
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                string userName = "misafir";
                if (filterContext.HttpContext.Session["login"] != null)
                {
                    userName = (filterContext.HttpContext.Session["login"] as AdminInfo).AdminName;
                }
             

                unitOfWork.Logs.Insert(new Logs()
                {
                    
                    LogUserName = userName,
                    ActionName = filterContext.RouteData.Values["action"].ToString(),
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                    LogCreationDate = filterContext.HttpContext.Timestamp,
                    LogInfo = filterContext.Exception.Message,
                    IpAddress = filterContext.HttpContext.Request.UserHostAddress,
                    Type = 2



                });
          
            }
        }
    }
}