function DestinationTablePopup(id, orderTableId, listArea, getDataUrl, selectCallback) {
    var root = this;
    this.id = id;
    this.orderTableId = orderTableId;
    this.listArea = listArea;
    this.getDataUrl = getDataUrl;
    this.selectCallback = selectCallback;

    $('#' + root.id).dialog({
        dialogClass: "no-close",
        autoOpen: false,
        closeOnEscape: true,
        width: 600,
        height: 500,
        modal: true
    });
    
    $('#' + root.id + ' button[id^="select-"]').unbind('click');
    $('#' + root.id + ' .popup-table-header').table();
    $('#' + root.id).sortingTable([0,1,2]);

    this.OpenPopup = function () {
        $('#select-area-' + root.id).html($('#lis-area-tmpl').tmpl(root.listArea));
        $.ajax({
            type: 'POST',
            url: root.getDataUrl,
            data: { areaID: 0 }
        }).done(function (result) {
            if (!result.Success)
                return;

            for (var i = result.Data.length - 1; i >= 0; i--) {
                if (result.Data[i].ID > 0) {
                    result.Data.splice(i, 1);
                }
            }

            $('#' + root.id + ' #destination-table').html($('#destination-table-tmpl').tmpl(result));
            
            $('button[id^="select-"]').button({
                icons: {
                    primary: "ui-icon-circle-check"
                }
            }).click(function (e) {
                root.select(e);
                return false;
            });
            
            $('#' + root.id + ' .popupClose').button({
                icons: {
                    primary: "ui-icon-close"
                }
            }).click(function () {
                $('#' + root.id).dialog('close');
                return false;
            });

            $('button[id^="select-"]').keypress(function (e) {
                if (e.which == 13) {
                    $(e.target).trigger('click');
                }
            });

            $('#' + root.id + ' #destination-table tr').dblclick(function (e) {
                $(e.currentTarget).find('button[id^="select-"]').trigger('click');
            });
            
            $('#' + root.id).dialog("open");
            SetHeightPopupContent('#' + root.id);
        });
    };
    
    this.select = function (e) {
        $('#' + root.id).dialog('close');
        var tableId = e.currentTarget.id.split('-')[1];

        if (root.selectCallback)
            root.selectCallback(root.orderTableId, tableId);
    };
}