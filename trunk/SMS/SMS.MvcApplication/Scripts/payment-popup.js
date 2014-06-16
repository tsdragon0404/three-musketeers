function PaymentPopup(id, height, getDataUrl, getDataForPostCallback) {
    var root = this;
    this.id = id;
    this.height = height;
    this.getDataUrl = getDataUrl;
    this.getDataForPostCallback = getDataForPostCallback;

    $('#' + root.id).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: "100%",
        height: root.height,
        modal: true
    });

    this.OpenPopup = function () {
        renderData();
        var popupId = '#' + root.id;
        $(popupId).dialog("open");

        var parentHeight = $(popupId).height();
        $(popupId + ' .popup-content').height(parentHeight);
    };
    
    function renderData() {
        var postData = getDataForPostCallback();
        $.ajax({
            type: 'POST',
            url: root.getDataUrl,
            data: postData
        }).done(function (result) {
            if (!result.Success)
                return;
            //if (root.formatDataForPrintInvoicePreview)
            //    root.formatDataForPrintInvoicePreview(result.Data);

            //$('#printPreviewPopup .print-content').html(root.template.tmpl(result.Data));
            //$('#printPreviewPopup').dialog("open");
            //SetHeightPopupContent('#printPreviewPopup');
        });
    }
}