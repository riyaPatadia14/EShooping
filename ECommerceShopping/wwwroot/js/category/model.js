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
        var url = "/CategoryController/Details/" + actionUrl;
        var sendData = form.serialize();
        $.post(url, sendData).done(function (data) {
            PlaceHoldeElement.find('.modal').modal('hide');
        })
    })
})

// Create Model Pop-Up
function AddCategory() {
    var addData = {
        CategoryName: $("#categoryName").val(),
        ImagePath: $("#chooseImg")[0].files[0],
        Active: $("#active").prop("checked")
    };

    var formData = new FormData();
    formData.append("CategoryName", addData.CategoryName);
    formData.append("ImagePath", addData.ImagePath);
    formData.append("Active", addData.Active);

    $.ajax({
        url: '/CategoryController/Create',
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

$("#btnCreateModal").click(function () {
    $("#createModal").modal('show');
});

$(document).ready(function () {
    $('#chooseImg').change(function (e) {
        var fileInput = e.target;
        var url = URL.createObjectURL(fileInput.files[0]);

        var output = document.getElementById('imgPreview');
        output.src = url;
    });
});
