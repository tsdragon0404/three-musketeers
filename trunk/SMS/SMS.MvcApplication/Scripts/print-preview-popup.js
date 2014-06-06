function PrintPreviewPopup(width, getDataForPreviewUrl, getDataForPostCallback, formatDataForPrintInvoicePreview, template) {
    var root = this;
    this.width = width;
    this.getDataForPreviewUrl = getDataForPreviewUrl;
    this.getDataForPostCallback = getDataForPostCallback;
    this.formatDataForPrintInvoicePreview = formatDataForPrintInvoicePreview;
    this.template = template;
    
    $('#printPreviewPopup').dialog({
        autoOpen: false,
        closeOnEscape: true,
        resizable: false,
        width: root.width,
        modal: true
    });

    $('#printPreviewPopup #print-button').click(function() {
        window.print();
        return false;
    });

    this.OpenPopup = function () {
        var postData = root.getDataForPostCallback();
        $.ajax({
            type: 'POST',
            url: root.getDataForPreviewUrl,
            data: postData
        }).done(function (result) {
            if (!result.Success)
                return;
            if(root.formatDataForPrintInvoicePreview)
                root.formatDataForPrintInvoicePreview(result.Data);
            
            $('#printPreviewPopup .print-content').html(root.template.tmpl(result.Data));
            $('#printPreviewPopup').dialog("open");
            SetHeightPopupContent('#printPreviewPopup');
        });
    };
}