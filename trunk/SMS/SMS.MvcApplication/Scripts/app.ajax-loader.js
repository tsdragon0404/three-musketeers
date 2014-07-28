$(document).ajaxStart(function () {
    $(".ajax-loader-mask").show();
});

$(document).ajaxComplete(function () {
    $(".ajax-loader-mask").hide();
});

$(document).ajaxError(function (event, jqXHR, ajaxSettings, thrownError) {
    $(".ajax-loader-mask").hide();

    var message = 'Unknown request';
    
    if (jqXHR.status == 404) {
        
    }
    if (jqXHR.status == 401 || jqXHR.status == 999) {
        message = thrownError;
    }
    
    var popup = new MessagePopup('Error', message, 4);
    popup.OpenPopup();
    return;
});