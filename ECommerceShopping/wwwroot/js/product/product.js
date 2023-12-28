﻿$(document).ready(function () {
    debugger;
    $('#chooseImg').change(function (e) {
        var url = $('#chooseImg').val();
        var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
        if (e.target.files && e.target.files[0] && (ext == 'gif' || ext == 'jpg' || ext == 'jfif' || ext == 'png' || ext == 'bmp')) {
            var reader = new FileReader();
            reader.onload = function () {
                var output = document.getElementById('imgPreview');
                output.src = reader.result;
            };
            reader.readAsDataURL(e.target.files[0]);
        }
    });
});
