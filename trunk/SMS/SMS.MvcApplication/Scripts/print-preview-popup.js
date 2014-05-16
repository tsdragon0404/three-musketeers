function PrintPreviewPopup(width) {
    var root = this;
    this.width = width;

    $('#printPreviewPopup').dialog({
        autoOpen: false,
        closeOnEscape: true,
        resizable: false,
        width: root.width,
        modal: true
    });

    this.OpenPopup = function () {
        $('#printPreviewPopup').dialog("open");
    };
}