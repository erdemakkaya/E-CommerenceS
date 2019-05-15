/// <reference path="jquery-2.1.3.min.js" />

function AddCart(productid, type) {
    counter = 1;
    if (type == 0) {

        counter = $("#counter").val();
    }
    else
    {
        counter = 1;
    }
    $.ajax({
  
        url: '/ProductDetail/AddCart',
        type: "POST",
        data: { productid: productid, counter: counter },
        dataType: 'json',
        success: function (response) {
          
            if (response.status == 1) {
                
                AppendliTopCart(response.product);
                

            }
            else if (response.status == 0) {
                alert("Stok yok!!");

            }


        }

    })
}
function DeleteFromCart(cartproductid) {
    $.ajax({
        url: '/ProductDetail/DeleteCartProduct',
        type: "POST",
        data: { cartproductid: cartproductid },
        dataType: 'json',
        success: function (response) {
            if (response.status == 1) {
                generateCartDetail(response.product);
                AppendliTopCart(response.product);


            }
            else {
                alert("Bir Hata ile karşılaşıldı işleminizi tekrar deneyiniz");
            }
        }
    })

}
function AppendliTopCart(product) {
    var str = "";
    var toplam = 0;
    for (var i = 0; i < product.length; i++) {

        toplam += product[i].quantity * product[i].price;
        str += "<li>" +
                                           "<a href='/ProductDetail/Product/?id='" + product[i].prodid + "' class='product-image'><img class='replace-2x' src='" + product[i].image + "' width='70' height='70' alt=''></a>" +
                                           
                                           "<h4 class='product-name'><a href='" + "" + "'" + " title=''>" + product[i].title + "</a></h4>" +
                                           "<div class='product-price'>" + product[i].quantity + "x <span class='price'>" + product[i].price + " ₺</span>" +

                                            "<a href='javascript:DeleteFromCart(" + product[i].cartid + ");' class='btn btn-danger btn-xs'><i class='glyphicon glyphicon-remove'></i> </a> </div> " +
                                           
                                           "<div class='clearfix'></div></li>";
    }
    $('#basketcount').html(product.length);

    $('#cartTotal').html(toplam + " ₺");





    $('#basketdropdown ul').html(str);
}
function DeleteFromCartDetail(cartproductid) {
    $.ajax({
        url: '/ProductDetail/DeleteCartProduct',
        type: "POST",
        data: { cartproductid: cartproductid },
        dataType: 'json',
        success: function (response) {
            if (response.status == 1) {
                generateCartDetail(response.product);
                AppendliTopCart(response.product);

            }
            else {
                alert("Bir Hata ile karşılaşıldı işleminizi tekrar deneyiniz");
            }
        }
    })
}
function generateCartDetail(product) {
 
    var str = "";
    var toplam = 0;

    for (var i = 0; i < product.length; i++) {
        

        toplam += product[i].quantity * product[i].price;
        str += "<tr>" +
            "<td class='td-images'>" +
          "<a href='/ProductDetail/Product/?id='" + product[i].prodid + "' class='product-image'><img class='replace-2x' src='" + product[i].image + "' width='70' height='70' alt=''></a> </td>" +
            "<td class='td-name'>" +
            " <h2 class='product-name'>" +
           "<a href='/ProductDetail/Product/?id='" + product[i].prodid + ">" + product[i].title + "</a> </h2> </td>" +
        "<td class='td-price'>" +
        " <div class='price'>" + product[i].price + " ₺</div> </td>" +
    " <td class='td-qty'>" +
    " <input  class='form-control' onchange='jsUpdateCart(" + product[i].cartid + ",this.value)' type='text'  value=" + product[i].quantity + "></input> </td>" +
        "<td class='td-total'>" +
         "  <div class='price'>" + product[i].price + " * " + product[i].quantity + " ₺</div> </td>" +
         " <td class='td-remove'>" +
         "<a href='javascript:DeleteFromCartDetail(" + product[i].cartid + ")' class='product-remove'>" +
         " <i class='fa fa-remove'></i> </a> </td> </tr> ";
        }
    $('#subTotal').html(toplam + " ₺");
    $('#grandTotal').html(toplam + " ₺");
    $('#shopping-cart-table tbody').html(str);


}
function createAllElement(tag,classname,text){
    var element = document.createElement(tag);
    element.setAttribute("class", classname);
    var node = document.createTextNode(text);
    element.appendChild(node);
 

}
