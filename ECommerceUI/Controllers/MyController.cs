using E_Commerence.DataAccessLayer.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceUI.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public void  getCarts()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                double toplam = 0;
         






                if (Request.Cookies["userInfo"] == null)
                {
                    ViewBag.Cart = new List<CartsProducts>() { };
                    ViewBag.Total = 0;
                    ViewBag.Count = 0;
                }
                else
                {
                    int id = int.Parse(Request.Cookies["userInfo"].Value);
                    var model = unitOfWork.Carts.Find(x => x.user.UserId == id && !x.IsPaid);
                    if (model == null||model.IsPaid)
                    {
                        ViewBag.Cart = new List<CartsProducts>() { };
                        ViewBag.Total = 0;
                        ViewBag.Count = 0;
                    }
                    else
                    {
                        var cartproducts = unitOfWork.CartProducts.List(x => x.Cart.CartId == model.CartId).ToList();
                        foreach (var item in cartproducts)
                        {
                            toplam += item.Product.ProductPrice * item.Quantity;
                        }
                        var toplam1 = cartproducts.Sum(x => x.Product.ProductPrice * x.Quantity);

                        ViewBag.Cart = cartproducts;
                        ViewBag.Total = toplam;
                        ViewBag.Count = cartproducts.Count();
                    }
                }
            }
        }
    }
}