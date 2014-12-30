function AdminFunction(getSchemaForAddUrl, getDataForEditUrl, saveDataUrl, getDataForSaveCallback, deleteDataUrl, deleteWarningTitle, deleteWarningMessage, pageSize) {
    var root = this;
    
    this.getSchemaForAddUrl = getSchemaForAddUrl;
    this.getDataForEditUrl = getDataForEditUrl;
    this.saveDataUrl = saveDataUrl;
    this.getDataForSaveCallback = getDataForSaveCallback;
    this.deleteDataUrl = deleteDataUrl;
    this.deleteWarningTitle = deleteWarningTitle;
    this.deleteWarningMessage = deleteWarningMessage;
    this.pageSize = pageSize;
    
    $('#record-table').DataTable({
        "pageLength": root.pageSize,
        scrollY: "200px",
        searching: true,
        "dom": '<"H"Tf>t<"F"ip>',
        "tableTools": {
            "sSwfPath": "../Scripts/datatables/TableTools/swf/copy_csv_xls_pdf.swf"
        },
        ordering: true,
        "info": true,
        "lengthChange": false,
        "jQueryUI": true,
        paging: true,
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

    this.bind = function () {

        // set height content datatable
        var contentHeight = $('#content').height() - $('#content .admin-page-title').height();
        var height1 = 0;
        $('#record-table_wrapper > .ui-widget-header').each(function (idx, element) {
            height1 += $(element).outerHeight();
        });
        var height2 = $('#record-table_wrapper > .dataTables_scroll > .dataTables_scrollHead').outerHeight();
        var height3 = $('#record-table_wrapper > .dataTables_scroll > .dataTables_scrollFoot').outerHeight();
        var targetHeight = contentHeight - height1 - height2 - height3 - 10; // subtract 2 more px due to the border and padding bottom
        $('#record-table_wrapper > .dataTables_scroll > .dataTables_scrollBody').css('height', targetHeight + 'px');

        // fix column header datatable
        $(' .dataTables_scrollHeadInner, .dataTables_scrollHeadInner > table').css('width', '').css('padding-left', '');
        var headerColumns = $(' .dataTables_scrollHead table > thead > tr:first-child th');
        var columns = $('#record-table > tbody > tr:first-child td');
        for (var i = 0; i < columns.length; i++) {
            $(headerColumns[i]).css('width', $(columns[i]).width());
        }
        var widthHeader = $('.dataTables_scrollHead').outerWidth();
        var widthContent = $('#record-table').outerWidth();
        $(' .dataTables_scrollHeadInner').css('padding-right', (widthHeader - widthContent) + 'px');

        // set action event
        $('#record-table a.edit-record').click(function () {
            var record = $(this).parent().parent();
            if (record.length == 0 || record.next().hasClass('admin-record-detail')) {
                cancelRecord();
                return false;
            }

            var id = $(this).attr('data-id');
            $.ajax({
                type: 'POST',
                url: root.getDataForEditUrl,
                data: { recordID: id }
            }).done(function (result) {
                if(!result.Success) {
                    return;
                }
                cancelRecord();

                var place = $('tr[data-id="' + result.Data.ID + '"]');
                if (place.length == 0)
                    return;

                $('#record-tmpl').tmpl(result.Data).scanLabel().insertAfter(place);

                $('#save-' + result.Data.ID).button({
                    icons: {
                        primary: "ui-icon-disk"
                    }
                }).click(function() {
                    saveRecord(result.Data.ID);
                    return false;
                });
                $('#cancel-' + result.Data.ID).button({
                    icons: {
                        primary: "ui-icon-close"
                    }
                }).click(function () {
                    cancelRecord();
                    return false;
                });
                $('.admin-record-detail').slideToggle(100);
                $('.admin-record-detail input:first-child').focus();
            });

            return false;
        });

        $('a.add-record').click(function () {
            var record = $(this).parent().parent();
            if (record.length == 0 || record.next().hasClass('admin-record-detail')) {
                cancelRecord();
                return false;
            }

            $.ajax({
                type: 'POST',
                url: root.getSchemaForAddUrl,
            }).done(function (result) {
                if (!result.Success) {
                    return;
                }
                cancelRecord();

                var place = $('a.add-record').parent().parent();

                $('#record-tmpl').tmpl(result.Data).insertAfter(place);

                $("#save-0").button({
                    icons: {
                        primary: "ui-icon-disk"
                    }
                }).click(function () {
                    saveRecord(0);
                    return false;
                });
                $('#cancel-0').button({
                    icons: {
                        primary: "ui-icon-close"
                    }
                }).click(function () {
                    cancelRecord();
                    return false;
                });
                $('.admin-record-detail').slideToggle(100);
                $('.admin-record-detail input:first-child').focus();
            });

            return false;
        });

        $('#record-table a.del-record').click(function () {
            var id = $(this).attr('data-id');
            var popup = new MessagePopup(root.deleteWarningTitle,
                root.deleteWarningMessage,
                2,
                function () {
                    deleteRecord(id);
                });
            
            popup.OpenPopup();
            
            return false;
        });
    };

    function deleteRecord(id) {
        $.ajax({
            type: 'POST',
            url: root.deleteDataUrl,
            data: { recordID: id }
        }).done(function (result) {
            if (result.Success)
                location.reload();
        });
    }

    function saveRecord(id) {
        var dataToSave = root.getDataForSaveCallback(id);
        $.ajax({
            type: 'POST',
            url: root.saveDataUrl,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(dataToSave),
        }).done(function (result) {
            if (result.Success)
                location.reload();
        });
    }

    function cancelRecord() {
        $('.admin-record-detail').slideToggle(100, function () {
            $(this).remove();
        });
    }
}
