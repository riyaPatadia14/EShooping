//Details, Edit and Delete Model Pop-Up
$(function () {
    var PlaceHoldeElement = $('#ProductPlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            PlaceHoldeElement.html(data);
            PlaceHoldeElement.find('.modal').modal('show');
        })
    })
    PlaceHoldeElement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var url = "/ProductController/" + actionUrl;
        var sendData = form.serialize();
        $.post(url, sendData).done(function (data) {
            PlaceHoldeElement.find('.modal').modal('hide');
        })
    })
})

// Create Model Pop-Up
//function AddCategory() {
//    var addData = {
//        Title: $("#title").val(),
//        ImagePath: $("#chooseImg")[0].files[0],
//        Active: $("#isActive").prop("checked"),
//        Price: $("#price").val(),
//        Description: $("#description").val(),
//        CategoryId: $("#categoriesId").val(),
//        BrandsId: $("brandsId").val(),
//        ColorId: $("#colorId").val(),
//        InStock: $("#inStock").val()
//    };

//    var formData = new FormData();
//    formData.append("Title", addData.Title);
//    formData.append("ImagePath", addData.ImagePath);
//    formData.append("Active", addData.Active);
//    formData.append("Price", addData.Price);
//    formData.append("Description", addData.Description);
//    formData.append("CategoriesId", addData.CategoriesId);
//    formData.append("BrandsId", addData.BrandsId);
//    formData.append("ColorId", addData.ColorId);
//    formData.append("InStock", addData.InStock);

//    $.ajax({
//        url: '/ProductController/Create',
//        type: 'POST',
//        data: formData,
//        contentType: false,
//        processData: false,
//        success: function (result) {
//            console.log('Product added successfully:', result);
//        },
//        error: function (error) {
//            console.error('Error in adding product:', error);
//        }
//    });
//}

//$("#btnCreateProductModal").click(function () {
//    $("#createProductModal").modal('show');
//});

//$(document).ready(function () {
//    $('#chooseImg').change(function (e) {
//        var fileInput = e.target;
//        var url = URL.createObjectURL(fileInput.files[0]);

//        var output = document.getElementById('imgPreview');
//        output.src = url;
//    });
//});
