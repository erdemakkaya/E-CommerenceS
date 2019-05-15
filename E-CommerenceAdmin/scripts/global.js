function jsDeleteCategory( id) {
    alert(id);
  
     
    $.ajax({
        url: '/Category/DeleteCategory',
        type: "POST",
        data: {id:id},
        dataType: 'json',
        success: function (response) {
            if (response.Success) {
                
                bootbox.alert(response.Message, function () {
                    location.reload();
                }
                );
            }

            else {
                bootbox.alert(response.Message, function () {

                }

            );

            }
        }

    })
}

function jsDeleteProduct(id) {
    alert(id);

  
    $.ajax({
        url: '/Product/DeleteProduct',
        type: "POST",
        data: { id: id },
        dataType: 'json',
        success: function (response) {
            if (response.Success) {

                bootbox.alert(response.Message, function () {
                    location.reload();
                }
                );
            }

            else {
                bootbox.alert(response.Message, function () {

                }

            );

            }
        }

    })
}

function jsDeleteSlider(id) {
    alert(id);


    $.ajax({
        url: '/Slider/Delete',
        type: "POST",
        data: { id: id },
        dataType: 'json',
        success: function (response) {
            if (response.Success) {

                bootbox.alert(response.Message, function () {
                    location.reload();
                }
                );
            }

            else {
                bootbox.alert(response.Message, function () {

                }

            );

            }
        }

    })
}