// Edit Modal Pop-Up

$("#editFormAction").click(function () {
    $("#editModal").modal('show');
})
//Delete Model pop-Up

$("#deleteFormAction").click(function () {
    $("#deleteModal").modal('show');
})
//Details Model Pop-Up

function showDetails(categoryId) {
    $.ajax({
        url: '/CategoryController/Details/' + categoryId,
        type: 'GET',
        dataType: 'html', // Specify that you expect HTML in response
        success: function (data) {
            $('#detailsModal .modal-body').html(data);
            $('#detailsModal').modal('show');
        },
        error: function () {
            console.error('Error fetching category details.');
        }
    });
}

$("#detailFormAction").click(function () {
    var categoryId = $(this).data('category-id');
    showDetails(categoryId);
    $("#detailsModal").modal('show');
});


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
