function PaymentPopup(id, height, getDataUrl, getDataForPostCallback, templateId) {
    var root = this;
    this.id = id;
    this.height = height;
    this.getDataUrl = getDataUrl;
    this.getDataForPostCallback = getDataForPostCallback;
    this.templateId = templateId;

    $('#' + root.id).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: "100%",
        height: root.height,
        modal: true
    });
    
    $('#' + root.id + ' #print').click(function () {
        if (MeadCo.ScriptX.Init()) {
            MeadCo.ScriptX.Printing.header = "";
            MeadCo.ScriptX.Printing.footer = "";
            MeadCo.ScriptX.PreviewPage();
        }
        else {
            window.print();
        }
        
        return false;
    });

    this.OpenPopup = function () {
        renderData();
        var popupId = '#' + root.id;
        $(popupId).dialog("open");
        
        var parentHeight = $(popupId).height();
        $(popupId + ' .payment-content').height(parentHeight);
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
            $('#' + root.id + ' .page').html($('#' + root.templateId).tmpl(result.Data).scanLabel());
        });
    }
}