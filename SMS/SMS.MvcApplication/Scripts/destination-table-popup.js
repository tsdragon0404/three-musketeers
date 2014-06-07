function DestinationTablePopup(id, orderTableId, listArea, getDataUrl, selectCallback) {
    var root = this;
    this.id = id;
    this.orderTableId = orderTableId;
    this.listArea = listArea;
    this.getDataUrl = getDataUrl;
    this.selectCallback = selectCallback;

    $('#' + id).dialog({
        dialogClass: "no-close",
        autoOpen: false,
        closeOnEscape: true,
        width: 600,
        height: 400,
        modal: true
    });
    
    $('#' + id + ' button[id^="select-"]').unbind('click');

    this.OpenPopup = function () {
        $('#select-area-' + id).html($('#lis-area-tmpl').tmpl(this.listArea));

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

            $('#' + id + ' #destination-table').html($('#destination-table-tmpl').tmpl(result));
            $('#' + id).dialog("open");
            
            $('table[id^="table-header"]').table();
            $('button[id^="select-"]').button({
                icons: {
                    primary: "ui-icon-circle-check"
                }
            });
            
            $('#' + id + ' .popupSelect').button({
                icons: {
                    primary: "ui-icon-circle-check"
                }
            }).click(function (e) {
                var pdtid = e.currentTarget.id.split('-')[1];
                if ($('#popup-qty-' + pdtid).valid())
                    root.select(e);
                return false;
            });

            $('#' + id + ' .popupSelect').keypress(function (e) {
                if (e.which == 13) {
                    $(e.target).trigger('click');
                }
            });

            $('#' + id + ' .tbContentLookup tr').dblclick(function (e) {
                $(e.currentTarget).find('button.popupSelect').trigger('click');
            });

            // stop Propagation on spinner element (double click on spinner will not trigger row double click)
            $('.tbContentLookup .ui-spinner').dblclick(function (e) {
                e.stopPropagation();
            });
        });
    };
}