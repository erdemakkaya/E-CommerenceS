using E_Commerence.DataAccessLayer.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerenceAdmin.CustomFilter
{
    public class ActFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            using (var unitOfWork=new UnitOfWork())
            {

                unitOfWork.Logs.Insert(new Logs()
                {

                    LogUserName = (filterContext.HttpContext.Session["login"] as AdminInfo).AdminName,
                    ActionName = filterContext.ActionDescriptor.ActionName,
                    ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    LogCreationDate = filterContext.HttpContext.Timestamp,
                    LogInfo = "OnActionExecuted",
                    IpAddress = filterContext.HttpContext.Request.UserHostAddress,
                    Type = 1
                     


                });
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (var unitOfWork = new UnitOfWork())
            {

                unitOfWork.Logs.Insert(new Logs()
                {

                    LogUserName = (filterContext.HttpContext.Session["login"] as AdminInfo).AdminName,
                    ActionName = filterContext.ActionDescriptor.ActionName,
                    ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    LogCreationDate = filterContext.HttpContext.Timestamp,
                    LogInfo = "OnActionExecuting",
                    IpAddress = filterContext.HttpContext.Request.UserHostAddress,
                    Type = 1



                });
            }
        }
    }
}