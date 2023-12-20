// Edit Modal Pop-Up

//Delete Model pop-Up

$("#deleteFormAction").click(function () {
    $("#deleteModal").modal('show');
})
//Details Model Pop-Up

$(function () {
    var PlaceHoldeElement = $('#PlaceHolderHere');
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
function AddProduct() {
    var addData = {
        Title: $("#title").val(),
        Description: $("#description").val(),
        ImageFile: $("#chooseImg")[0].files[0],
        CategoryId: $("#categoryId").val(),
        BrandId: $("#brandId").val(),
        ColorId: $("#colorId").val(),
        Price: $("#price").val(),
        InStock: $("#inStock").val(),
        IsActive: $("#isActive").prop("checked")
    };

    var formData = new FormData();
    formData.append("Title", addData.Title);
    formData.append("Description", addData.Description);
    formData.append("ImageFile", addData.ImageFile);
    formData.append("CategoryId", addData.CategoryId);
    formData.append("BrandId", addData.BrandId);
    formData.append("ColorId", addData.ColorId);
    formData.append("Price", addData.Price);
    formData.append("InStock", addData.InStock);
    formData.append("IsActive", addData.IsActive);

    $.ajax({
        url: '/ProductController/Create',
        type: 'POST',
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {
            console.log('Category added successfully:', result);
        },
        error: function (error) {
            console.error('Error adding category:', error);
        }
    });
}

$("#btnCreateProductModal").click(function () {
    $("#createProductModal").modal('show');
});

$(document).ready(function () {
    $('#chooseImg').change(function (e) {
        var fileInput = e.target;
        var url = URL.createObjectURL(fileInput.files[0]);

        var output = document.getElementById('imgPreview');
        output.src = url;
    });
});
