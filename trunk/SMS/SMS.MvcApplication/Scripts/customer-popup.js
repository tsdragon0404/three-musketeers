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
        width: 950,
        height: 600,
        modal: true,
        resizable: false
    });

    $(root.popupId + ' .popup-table-header').table();
    $(root.popupId).sortingTable([1, 2, 3, 4, 5]);
    $(root.popupId).searchTable([1, 2, 3, 4, 5]);
    
    $(root.popupId + ' .popupClose').unbind('click');
    $(root.popupId + ' .popupClose').button({
        icons: {
            primary: "ui-icon-close"
        }
    }).click(function () {
        $(root.popupId).dialog('close');
        return false;
    });
    
    $(root.popupId + ' #useInputCustomer').unbind('change');
    $(root.popupId + ' #useInputCustomer').change(function () {
        bindEvent();
    });
    
    $(root.popupId + ' #btnOK').unbind('click');
    $(root.popupId + ' #btnOK').button({
        icons: {
            primary: "ui-icon-check"
        }
    }).click(function () {
        var customerName = $(root.popupId + ' #customerName').val();
        var address = $(root.popupId + ' #address').val();
        var cellPhone = $(root.popupId + ' #cellPhone').val();
        var dob = $(root.popupId + ' #DOB').val();
        root.functionCallback(root.orderId, 0, customerName, address, cellPhone, dob);
        $(root.popupId).dialog('close');
    });

    this.OpenPopup = function () {
        $.ajax({
            type: 'POST',
            url: root.getDataUrl + "/GetOrderBasic",
            data: { orderID: root.orderId }
        }).done(function (result) {
            if(result.Success) {
                if(result.Data.Customer == null) {
                    $(root.popupId + ' #useInputCustomer').prop('checked', true);
                    $(root.popupId + ' #customerName').val(result.Data.CustomerName);
                    $(root.popupId + ' #address').val(result.Data.Address);
                    $(root.popupId + ' #cellPhone').val(result.Data.CellPhone);
                    $(root.popupId + ' #DOB').val(result.Data.DOB==null ? '' : result.Data.DOB.formatAsDate());
                } else {
                    $(root.popupId + ' #useInputCustomer').prop('checked', false);
                }
                
                $.ajax({
                    type: 'POST',
                    url: root.getDataUrl + "/GetCustomer"
                }).done(function (data) {
                    if (data.Success) {
                        $(root.popupId + ' #customer-table').html('');
                        $(root.popupId + ' #customer-table').html($('#customer-tmpl').tmpl(data));

                        $("#DOB").datepicker();
                        
                        $(root.popupId + ' button[id^="select-"]').unbind('click');
                        $(root.popupId + ' button[id^="select-"]').button({
                            icons: {
                                primary: "ui-icon-circle-check"
                            }
                        }).click(function(e) {
                            root.select(e);
                            return false;
                        });

                        $(root.popupId + ' button[id^="select-"]').unbind('keypress');
                        $(root.popupId + ' button[id^="select-"]').keypress(function(e) {
                            if (e.which == 13) {
                                $(e.target).trigger('click');
                            }
                        });

                        $(root.popupId + ' #customer-table tr').unbind('dblclick');
                        $(root.popupId + ' #customer-table tr').dblclick(function(e) {
                            $(e.currentTarget).find('button[id^="select-"]').trigger('click');
                        });
                        
                        bindEvent();

                        $(root.popupId).dialog("open");
                        SetHeightPopupContent(root.popupId);
                    } else {
                        $(root.popupId).dialog('close');
                    }
                });
            } else {
                $(root.popupId).dialog('close');
            }
        });
    };

    function bindEvent() {
        if ($(root.popupId + ' #useInputCustomer').is(':checked')) {
            $(root.popupId + ' #customerInfo table *').prop("disabled", false);
            $(root.popupId + ' #customerInfo table').removeClass('icon-disable');

            $(root.popupId + ' .popup-table-header *').prop("disabled", true);
            $(root.popupId + ' .popup-table-header').addClass('icon-disable');
            $(root.popupId + ' .popup-content *').prop("disabled", true);
            $(root.popupId + ' .popup-content').addClass('icon-disable');

            $(root.popupId + ' button[id^="select-"]').unbind('click');
            $(root.popupId + ' button[id^="select-"]').unbind('keypress');
            $(root.popupId + ' #customer-table tr').unbind('dblclick');
        } else {
            $(root.popupId + ' #customerInfo table *').prop("disabled", true);
            $(root.popupId + ' #customerInfo table').addClass('icon-disable');

            $(root.popupId + ' .popup-table-header *').prop("disabled", false);
            $(root.popupId + ' .popup-table-header').removeClass('icon-disable');
            $(root.popupId + ' .popup-conten *').prop("disabled", false);
            $(root.popupId + ' .popup-content').removeClass('icon-disable');
            
            $(root.popupId + ' button[id^="select-"]').unbind('click');
            $(root.popupId + ' button[id^="select-"]').button({
                icons: {
                    primary: "ui-icon-circle-check"
                }
            }).click(function (e) {
                root.select(e);
                return false;
            });

            $(root.popupId + ' button[id^="select-"]').unbind('keypress');
            $(root.popupId + ' button[id^="select-"]').keypress(function (e) {
                if (e.which == 13) {
                    $(e.target).trigger('click');
                }
            });

            $(root.popupId + ' #customer-table tr').unbind('dblclick');
            $(root.popupId + ' #customer-table tr').dblclick(function (e) {
                $(e.currentTarget).find('button[id^="select-"]').trigger('click');
            });
        }
    }
    
    this.select = function (e) {
        $(root.popupId).dialog('close');
        var customerId = e.currentTarget.id.split('-')[1];

        if (root.functionCallback)
            root.functionCallback(root.orderId, customerId, '', '', '', '');
    };
}