function PaymentPopup(id, height) {
    var root = this;
    this.id = id;
    this.height = height;

    $('#' + root.id).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: "100%",
        height: root.height,
        modal: true
    });

    this.OpenPopup = function () {
        var popupId = '#' + root.id;
        $(popupId).dialog("open");

        var parentHeight = $(popupId).height();
        $(popupId + ' .popup-content').height(parentHeight);
        $(popupId + ' .popup-content').css('margin-bottom', '0');
    };
}