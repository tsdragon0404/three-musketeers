function CustomerPopup(id, orderId, getDataUrl, functionCallback) {
    var root = this;
    this.id = id;
    this.orderId = orderId;
    this.getDataUrl = getDataUrl;
    this.functionCallback = functionCallback;
    this.popupId = '#' + id;

    $('#' + root.id).dialog({
        dialogClass: "no-close",
        autoOpen: false,
        closeOnEscape: true,
        width: 900,
        height: 500,
        modal: true
    });

    $(root.popupId + ' .popup-table-header').table();
    
    $(root.popupId + ' .popupClose').unbind('click');
    $(root.popupId + ' .popupClose').button({
        icons: {
            primary: "ui-icon-close"
        }
    }).click(function () {
        $(root.popupId).dialog('close');
        return false;
    });
    
    $(root.popupId + ' #useInputCustomer').unbind('click');
    $(root.popupId + ' #useInputCustomer').click(function () {
        if ($(this).is(':checked')) {

        } else {
            
        }
    });
    
    $(root.popupId + ' #btnOK').unbind('click');
    $(root.popupId + ' #btnOK').button({
        icons: {
            primary: "ui-icon-check"
        }
    }).click(function () {
        root.functionCallback(root.orderId, 0, '', '', '', '');
    });

    this.OpenPopup = function () {
        $.ajax({
            type: 'POST',
            url: root.getDataUrl
        }).done(function (result) {
            if (result.Success) {
                $(root.popupId + ' #customer-table').html('');
                $(root.popupId + ' #customer-table').html($('#customer-tmpl').tmpl(result));
                
                $('button[id^="select-"]').button({
                    icons: {
                        primary: "ui-icon-circle-check"
                    }
                }).click(function (e) {
                    root.select(e);
                    return false;
                });

                $(root.popupId + ' button[id^="select-"]').unbind('click');
                $(root.popupId + ' button[id^="select-"]').keypress(function (e) {
                    if (e.which == 13) {
                        $(e.target).trigger('click');
                    }
                });

                $(root.popupId + ' #customer-table tr').dblclick(function (e) {
                    $(e.currentTarget).find('button[id^="select-"]').trigger('click');
                });

                $(root.popupId).dialog("open");
                SetHeightPopupContent(root.popupId);
            }
        });
    };
    
    this.select = function (e) {
        $(root.popupId).dialog('close');
        var customerId = e.currentTarget.id.split('-')[1];

        if (root.functionCallback)
            root.functionCallback(root.orderId, customerId, '', '', '', '');
    };
}