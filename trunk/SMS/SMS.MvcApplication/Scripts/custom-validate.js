jQuery.validator.addMethod("greaterThanZero", function (value, element) {
    return (parseFloat(value) > 0);
}, "* Amount must be greater than zero");