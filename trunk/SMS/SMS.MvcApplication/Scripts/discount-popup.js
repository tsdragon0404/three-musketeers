function DiscountPopup(id, orderId, getDataUrl, refreshCallback) {
    var root = this;
    this.id = id;
    this.orderId = orderId;
    this.getDataUrl = getDataUrl;
    this.refreshCallback = refreshCallback;
    this.popupId = '#' + id;

    $('#' + root.id).dialog({
        dialogClass: "no-close",
        autoOpen: false,
        closeOnEscape: true,
        width: 650,
        height: 400,
        modal: true,
        close: refreshCallback
    });

    $(root.popupId + ' .popup-table-header').table();
    
    $(root.popupId + ' .popupClose').unbind('click');
    $(root.popupId + ' .popupClose').button({
        icons: {
            primary: "ui-icon-close"
        }
    }).click(function () {
        $('#' + root.id).dialog('close');
        return false;
    });
    
    $(root.popupId + ' #saveDiscount').unbind('click');
    $(root.popupId + ' #saveDiscount').button({
        icons: {
            primary: "ui-icon-check"
        }
    }).click(function () {
        
        return false;
    });
    
    $(root.popupId + ' #addNew').unbind('click');
    $(root.popupId + ' #addNew').button({
        icons: {
            primary: "ui-icon-plus"
        }
    }).click(function () {
        $(root.popupId + ' #discount-table').append($('#new-discount-tmpl').tmpl());
        bindSequence();
        
        return false;
    });
    
    function bindSequence() {
        $('#discount-table tr[id^="order-discount"]').each(function (index, element) {
            $(element).find('td.sequence').text(index + 1);
        });
        
        $(root.popupId + ' td a #remove').unbind('click');
        $(root.popupId + ' td a #remove').click(function () {
            alert('a');
            $(this).parent('tr');
        });
    }

    this.OpenPopup = function () {
        $.ajax({
            type: 'POST',
            url: root.getDataUrl + "/GetOrderDiscount",
            data: { orderID: root.orderId }
        }).done(function (result) {
            if (result.Success) {
                $(root.popupId + ' #discount-table').html('');
                $(root.popupId + ' #discount-table').html($('#discount-tmpl').tmpl(result));
                $(root.popupId).dialog("open");
                SetHeightPopupContent('#' + root.id);
            }
        });
    };
}