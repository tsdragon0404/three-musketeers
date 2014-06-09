jQuery.validator.setDefaults({
    errorPlacement: function(error, element) {
        $(element).attr('data-error-msg', error.html());
        if ($(element).parent().hasClass('ui-spinner'))
            $(element).parent().addClass('ui-state-error');
        if($(element).prop('tagName') == 'INPUT')
            $(element).addClass('ui-state-error');
    },
    success: function(label, element) {
        if ($(element).parent().hasClass('ui-spinner'))
            $(element).parent().removeClass('ui-state-error');
        if ($(element).prop('tagName') == 'INPUT')
            $(element).removeClass('ui-state-error');
    }
});
jQuery.validator.addMethod("greaterThanZero", function (value) {
    return (parseFloat(value) > 0);
}, "* Amount must be greater than zero");
jQuery.validator.addMethod("greaterOrEqualZero", function (value) {
    return (parseFloat(value) >= 0);
}, "* Amount must be greater or equal zero");