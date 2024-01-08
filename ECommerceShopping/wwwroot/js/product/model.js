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