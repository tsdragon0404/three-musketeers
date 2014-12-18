function DestinationTablePopup(id, orderTableId, listArea, getDataUrl, selectCallback) {
    var root = this;
    this.id = id;
    this.popupId = '#' + id;
    this.orderTableId = orderTableId;
    this.listArea = listArea;
    this.getDataUrl = getDataUrl;
    this.selectCallback = selectCallback;
    var $dialogContainer;
    var $detachedChildren;
    
    var table;

    $(root.popupId).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: 700,
        height: 500,
        modal: true,
        resizable: false,
        open: function () {
            $detachedChildren.appendTo($dialogContainer);
        }
    });

    this.OpenPopup = function () {
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
            
            if ($.fn.DataTable.isDataTable(root.popupId + ' #chooseTable')) {
                $(root.popupId + ' .datatable_filter').remove();
                table = $(root.popupId + ' #chooseTable').DataTable();
                table.destroy();
            }

            $(root.popupId + ' #destination-table').html($('#destination-table-tmpl').tmpl(result));
            
            $(root.popupId + ' .popupClose').button({
                icons: {
                    primary: "ui-icon-close"
                }
            }).click(function () {
                $(root.popupId).dialog('close');
                return false;
            });
            
            $(root.popupId + ' span[id^="table-"]').unbind('click');
            $(root.popupId + ' span[id^="table-"]').click(function (e) {
                root.select(e);
                return false;
            });

            $(root.popupId + ' #destination-table tr').dblclick(function (e) {
                $(e.currentTarget).find('span[id^="table-"]').trigger('click');
            });

            table = $(root.popupId + ' #chooseTable').DataTable({
                scrollY: "200px",
                searching: true,
                "dom": '<"H"lr>t<"F"ip>',
                ordering: true,
                "info": true,
                "lengthChange": false,
                "jQueryUI": true,
                paging: true,
                columns: [
                    null,
                    null
                ],
                language: {
                    "emptyTable": CONST_DATATABLE_NODATA,
                    "info": CONST_DATATABLE_SHOWINGRECORDS,
                    "infoEmpty": CONST_DATATABLE_NOENTRIES,
                    "infoFiltered": CONST_DATATABLE_FILTER,
                    "lengthMenu": CONST_DATATABLE_SHOWENTRIES,
                    "search": CONST_DATATABLE_SEARCH,
                    "zeroRecords": CONST_DATATABLE_NOMATCHINGDATA,
                    "paginate": {
                        "first": CONST_DATATABLE_FIRST,
                        "last": CONST_DATATABLE_LAST,
                        "next": CONST_DATATABLE_NEXT,
                        "previous": CONST_DATATABLE_PREVIOUS
                    }
                }
            });

            applyColumnFilterForDataTable(root.popupId, table, [0, 1]);

            $dialogContainer = $(root.popupId);
            $detachedChildren = $dialogContainer.children().detach();

            $(root.popupId).dialog("open");
            fixTableHeader(root.popupId, '#chooseTable');
            setHeightPopupContent(root.popupId);
            setHeightTableContent(root.popupId, '#chooseTable');
        });
    };
    
    this.select = function (e) {
        $(root.popupId).dialog('close');
        var tableId = e.currentTarget.id.split('-')[1];

        if (root.selectCallback)
            root.selectCallback(root.orderTableId, tableId);
    };
}