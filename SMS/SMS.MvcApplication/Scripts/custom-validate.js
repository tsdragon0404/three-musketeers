jQuery.validator.setDefaults({
    errorPlacement: function (error, element) {
        element.attr('data-error-msg', error.html());
        if (element.parent().hasClass('ui-spinner'))
            element.parent().addClass('ui-state-error');
    }
});
jQuery.validator.addMethod("greaterThanZero", function (value) {
    return (parseFloat(value) > 0);
}, "* Amount must be greater than zero");