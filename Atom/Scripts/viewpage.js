$(document).ready(function () {
    $(".carousel img ").on('click', function () {
        $('#modal img').attr('src', $(this).attr('src'));
        $('#modal').modal('show');
        //$("body").append("<div id='image-fullscreen'><img src='" + dataArray[(+$(this).attr('id').replace("fullpict", "") - +$('input[name = "picture_name"]').val()) - 1].value + "' class='img-responsive center-block' </div>");
    });
    $(".carousel-fullscreen").on('click', function (e) {
        e.preventDefault();
        $('#modal img').attr('src', $(this).prev().attr('src'));
        $('#modal').modal('show');
        //$("body").append("<div id='image-fullscreen'><img src='" + dataArray[(+$(this).attr('id').replace("fullpict", "") - +$('input[name = "picture_name"]').val()) - 1].value + "' class='img-responsive center-block' </div>");
    });
});