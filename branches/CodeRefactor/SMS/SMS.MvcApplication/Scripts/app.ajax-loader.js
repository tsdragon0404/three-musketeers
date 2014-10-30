var HTTP_RESPONSE_SEPARATOR = '{{|}}';

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
        var strs = jqXHR.responseText.split(HTTP_RESPONSE_SEPARATOR);
        if (strs.length > 1) {
            title = strs[0];
            message = strs[1];
        }
        else
            message = strs[0];
    }
    
    var popup = new MessagePopup(title, message, 4, function () {
        location.reload();
    });
    popup.OpenPopup();
    return;
});

