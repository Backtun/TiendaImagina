// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    $("#botonfli").click(function () {
        $("#imagenes").empty();
        $("<img>").attr("src", "ajax-loader.gif").appendTo("#imagenes");
        var valor = $("#selector").val();
        var url = "https://api.flickr.com/services/feeds/photos_public.gne?tags=";
        url += valor + "&format=json&jsoncallback=?";
        $.getJSON(url, function (data, st, xhr) {
            var arrFotos = data.items;
            if (st = "success") {
                $("#imagenes").empty();
                $.each(arrFotos, function (i, item) {
                    if (i < 10) {
                        var img = "<img src='" + item.media.m + "' width='300' height='200'>";
                        $("#imagenes").append(img);
                    }
                });
            }
        });
    });
});