function PrintPreviewPopup() {
    var root = this;

    $('#invoicePreview').dialog({
        autoOpen: false,
        closeOnEscape: true,
        resizable: false,
        width: 500,
        modal: true
    });

    this.OpenPopup = function () {
        $('#invoicePreview').dialog("open");
    };
}