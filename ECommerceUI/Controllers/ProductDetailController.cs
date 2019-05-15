using E_Commerence.DataAccessLayer.EntityFramwork;
using E_Commerence.DataAccessLayer.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using ECommerceUI.Class;

namespace ECommerceUI.Controllers
{
    public class ProductDetailController : MyController
    {
        struct result
        {
            public int prodid { get; set; }
            public int cartid { get; set; }
            public string image { get; set; }
            public string title { get; set; }
            public int quantity { get; set; }
            public double price { get; set; }

        }
        // GET: ProductDetail
        public ActionResult Product(int id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                getCarts();
                var model = unitOfWork.Producsts.Find(x => x.ProductId==id);

                return View(model);
            }
          
        }

        [LoginFilter]

        [HttpPost]
        public JsonResult AddCart(int productid,int counter)

        {
            getCarts();
            ReturnJson rt = new ReturnJson();
               
            using (var unitOfWork = new UnitOfWork())
            {

                HttpCookie cookie = HttpContext.Request.Cookies["userInfo"];
                int id = Convert.ToInt32(cookie.Value);
                var user = unitOfWork.Users.Find(x => x.UserId == id);
                var product = unitOfWork.Producsts.Find(x=>x.ProductId==productid);
                
                
                if (unitOfWork.Carts.Any(x=>x.user.UserId==id && !x.IsPaid )) // ödenmemiş sepet varsa  içeri gir
                {
                    var cart = unitOfWork.Carts.Find(x => x.user.UserId == user.UserId && !x.IsPaid);


                    if (unitOfWork.CartProducts.Any(x=>x.Cart.CartId==cart.CartId && x.Product.ProductId==product.ProductId))
                    {
                        var cartprod = unitOfWork.CartProducts.Find(x => x.Product.ProductId==product.ProductId &&x.Cart.CartId==cart.CartId);
                        if(product.ProductStock>=(counter+cartprod.Quantity))
                        {
                            cartprod.Quantity += counter;
                            unitOfWork.CartProducts.Update(cartprod);
                            
                            var basket = unitOfWork.CartProducts.Include(x => x.Product).Include(x => x.Cart).Include(x=>x.Cart).Where(x => x.Cart.CartId == cart.CartId).ToList();
                            List<result> res = new List<result>();
                            foreach (var item in basket)
                            {
                                res.Add(new result()
                                {
                                    cartid = item.CartProductsId,
                                    image = item.Product.ProductImage,
                                    price = item.Product.ProductPrice,
                                    prodid = item.Product.ProductId,
                                    quantity = item.Quantity,
                                    title = item.Product.ProductName
                                });

                            }


                            return Json(new {
                                status=1,
                                product=res,
                                //qty=counter+cartprod.Quantity
                            }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new {
                                status = 0,
                                product = "",
                                qty = 0
                            }, JsonRequestBehavior.AllowGet);

                            //stok yok
                        }

                    }
                    else
                    {
                        if(product.ProductStock>=counter)
                        {
                            unitOfWork.CartProducts.Insert(new CartsProducts()
                            {
                                Cart=cart,
                                IsActive=true,
                                IsDeleted=false,
                                Product=product,
                                Quantity=counter,
                                CreationDate=DateTime.Now

                            });
                            var basket = unitOfWork.CartProducts.Include(x => x.Product).Include(x => x.Cart).Where(x => x.Cart.CartId == cart.CartId).ToList();
                            List<result> res = new List<result>();
                            foreach (var item in basket)
                            {
                                res.Add(new result()
                                {
                                    cartid = item.CartProductsId,
                                    image = item.Product.ProductImage,
                                    price = item.Product.ProductPrice,
                                    prodid = item.Product.ProductId,
                                    quantity = item.Quantity,
                                    title = item.Product.ProductName
                                });

                            }
                            return Json(new {
                                status = 1,
                                product = res,
                                
                            }, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            return Json(new {

                                status = 0,
                                product = "",
                                qty = 0
                            }, JsonRequestBehavior.AllowGet);

                            //istenen miktarda yok
                        }
                    }


                }
                else
                {
                    if(product.ProductStock>=counter)
                    {
                        var crt = unitOfWork.Carts.Insert(new Carts()
                        {
                            CartsProduct=null,

                            CreationDate=DateTime.Now,
                            IsActive=true,
                            IsDeleted=false,
                            IsPaid=false,
                            user=user,
                            
                        });

                        var basket = unitOfWork.CartProducts.Include(x => x.Product).Include(x => x.Cart).Where(x => x.Cart.CartId == crt.CartId).ToList();
                        List<result> res = new List<result>();
                        foreach (var item in basket)
                        {
                            res.Add(new result()
                            {
                                cartid = item.CartProductsId,
                                image = item.Product.ProductImage,
                                price = item.Product.ProductPrice,
                                prodid = item.Product.ProductId,
                                quantity = item.Quantity,
                                title = item.Product.ProductName
                            });

                        }
                        unitOfWork.CartProducts.Insert(new CartsProducts()
                        {
                            Cart=crt,
                            CreationDate=DateTime.Now,
                            IsActive=true,
                            IsDeleted=false,
                            Product=product,
                            Quantity=counter
                            

                        });
                        return Json(new {

                            status = 1,
                            product=res
                           
                            

                        }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        return Json(new
                        {
                            status = 0,
                            product = "",
                            qty = 0
                        }, JsonRequestBehavior.AllowGet);

                        //stok yok
                    }
                }




                
                    

                
            }
        }


        [LoginFilter]
        public ActionResult CartDetail()
        {
            using (var unitOfWork = new UnitOfWork())
            {

                    getCarts();
                    int id = int.Parse(Request.Cookies["userInfo"].Value);
                    var carts = unitOfWork.Carts.Find(x => x.user.UserId == id && !x.IsPaid);
                if (carts == null)
                {
                    List<CartsProducts> model = new List<CartsProducts>();
                    ViewBag.CartTotal = 0;

                    return View(model);


                }
                else
                {
                    List<CartsProducts> model = carts.CartsProduct.ToList();
                    double total = 0;
                    foreach (var item in model)
                    {
                        total += (item.Product.ProductPrice * item.Quantity);

                    }
                    ViewBag.CartTotal = total;

                    return View(model);
                }
                }



        }


        [LoginFilter]

        public JsonResult UpdateCart(int cartproductid, int quantity)
        {
            if (quantity<1)
            {
                quantity = 1;
            }
            getCarts();

            using (var unitOfWork = new UnitOfWork())
            {
                

                var chozen = unitOfWork.CartProducts.Find(x => x.CartProductsId == cartproductid);
                if (chozen.Product.ProductStock < quantity)
                {
                    quantity = chozen.Product.ProductStock;
                   
                }
               
                

                    chozen.Quantity = quantity;
                    unitOfWork.CartProducts.Save();
                    return Json("1", JsonRequestBehavior.AllowGet);


            }








        }

        [HttpPost]
        public  JsonResult DeleteCartProduct (int cartproductid)
        {
            getCarts();
            using (var unitOfWork = new UnitOfWork())
            {


                var chozen = unitOfWork.CartProducts.Find(x => x.CartProductsId == cartproductid);

                unitOfWork.CartProducts.Delete(chozen);


              
                unitOfWork.CartProducts.Save();
                HttpCookie cookie = HttpContext.Request.Cookies["userInfo"];
                int id = Convert.ToInt32(cookie.Value);
                var user = unitOfWork.Users.Find(x => x.UserId == id);
                var cart = unitOfWork.Carts.Find(x => x.user.UserId == user.UserId && !x.IsPaid);
                var basket = unitOfWork.CartProducts.Include(x => x.Product).Include(x => x.Cart).Where(x => x.Cart.CartId == cart.CartId).ToList();
                List<result> res = new List<result>();
                foreach (var item in basket)
                {
                    res.Add(new result()
                    {
                        cartid = item.CartProductsId,
                        image = item.Product.ProductImage,
                        price = item.Product.ProductPrice,
                        prodid = item.Product.ProductId,
                        quantity = item.Quantity,
                        title = item.Product.ProductName
                    });

                }
                return Json(new
                {

                    status = 1,
                    product = res



                }, JsonRequestBehavior.AllowGet);

            }



        }

        }
        



    }
    
