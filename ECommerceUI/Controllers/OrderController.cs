using E_Commerence.DataAccessLayer.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceUI.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult OrderInfo(int id)
        {
            using (var unitOfWork=new UnitOfWork())
            {
              var model =  unitOfWork.Orders.Find(x => x.OrdderId == id);
                var cartProducts = unitOfWork.CartProducts.List(x => x.Cart.CartId == model.Cart.CartId).ToList();
                ViewBag.DetailItems= cartProducts;
                return View(model);
            }

            
            
        }


        public ActionResult Pay()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                int userId = int.Parse(Request.Cookies["userInfo"].Value);


                var user = unitOfWork.Users.Find(x => x.UserId == userId);
                var currentBasket = unitOfWork.Carts.Find(x => x.user.UserId == user.UserId && !x.IsPaid && !x.IsDeleted);
                var basketItems = unitOfWork.CartProducts.List(x => x.Cart.CartId == currentBasket.CartId && !x.IsDeleted);
                double totalPrice = 0;
                foreach (var item in basketItems)
                {
                    totalPrice += item.Product.ProductPrice * item.Quantity;

                }
         int orderid=       unitOfWork.Orders.Insert(new Orders()
                {
                    OrdderAmount = totalPrice,
                    UserName = user.UserName,
                    User = user,
                    UserTel = "05074115069",
                    OrderAdress = user.UserAdress,
                    Cart = currentBasket,
                    OrderMail = user.UserEmail,
                    CreationDate = DateTime.Now,

                    }).OrdderId;
                    currentBasket.IsPaid = true;
                    foreach (var item in basketItems)
                    {
                        var products = unitOfWork.Producsts.Find(x => x.ProductId == item.Product.ProductId).ProductStock -= item.Quantity;
                    }
                    unitOfWork.Producsts.Save();
                    return RedirectToAction("OrderInfo",new { id=orderid});
                
            }
        }
    }
}