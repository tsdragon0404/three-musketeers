$(document).ajaxStart(function () {
    $(".ajax-loader-mask").show();
});

$(document).ajaxComplete(function () {
    $(".ajax-loader-mask").hide();
});

$(document).ajaxError(function (event, jqXHR, ajaxSettings, thrownError) {
    $(".ajax-loader-mask").hide();
    if (jqXHR.status == 404) {
        var popup = new MessagePopup('Error', 'Unknown request', 4);
        popup.OpenPopup();
        return;
    }
    if (jqXHR.status == 401) {
        var popup = new MessagePopup('Error', thrownError, 4);
        popup.OpenPopup();
        return;
    }
});