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
        width: 500,
        height: 400,
        modal: true
    });

    this.OpenPopup = function () {
        $('#select-area-' + id).html('');
        $('#lis-area-tmpl').tmpl(this.listArea).appendTo('#select-area-' + id);

        $.ajax({
            type: 'POST',
            url: root.getDataUrl,
            data: { areaID: 0 }
        }).done(function (result) {
            if (!result.Success)
                return;

            for (var i = result.Data.length; i < 0; i--) {
                if (result.Data[i].ID > 0) {
                    result.Data.slice(i, 1);
                }
            }

            $('#' + id + ' #destination-table').html('');
            $('#' + id + ' #destination-table').html($('#destination-table-tmpl').tmpl(result));
            $('#' + id).dialog("open");
            
            $('table[id^="table-header"').table();
            $('input[id^="select-"').button();
        });
    };
}