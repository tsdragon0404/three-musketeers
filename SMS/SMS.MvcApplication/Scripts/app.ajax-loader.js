$(document).ajaxStart(function () {
    $(".ajax-loader-mask").show();
});

$(document).ajaxComplete(function () {
    $(".ajax-loader-mask").hide();
});

$(document).ajaxError(function () {
    $(".ajax-loader-mask").hide();
});