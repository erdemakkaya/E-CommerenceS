﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerenceAdmin.CustomFilter
{
    public class LoginFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
           if(filterContext.HttpContext.Session["login"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/SignIn");
            }
        }
    }
}