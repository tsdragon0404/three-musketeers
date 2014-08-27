$(document).ajaxStart(function () {
    $(".ajax-loader-mask").show();
});

$(document).ajaxComplete(function () {
    $(".ajax-loader-mask").hide();
});

$(document).ajaxError(function (event, jqXHR, ajaxSettings, thrownError) {
    $(".ajax-loader-mask").hide();

    var message = 'Unknown request';
    var title = 'Error';
    
    if (jqXHR.status == 404) {
        
    }
    if (jqXHR.status == 401 || jqXHR.status == 999 || jqXHR.status == 500) {
        message = thrownError;
    }
    
    var popup = new MessagePopup(title, message, 4, function () {
        location.reload();
    });
    popup.OpenPopup();
    return;
});