function AdminFunction(getSchemaForAddUrl, getDataForEditUrl, saveDataUrl, getDataForSaveCallback, deleteDataUrl, deleteWarningTitle, deleteWarningMessage) {
    var root = this;
    
    this.getSchemaForAddUrl = getSchemaForAddUrl;
    this.getDataForEditUrl = getDataForEditUrl;
    this.saveDataUrl = saveDataUrl;
    this.getDataForSaveCallback = getDataForSaveCallback;
    this.deleteDataUrl = deleteDataUrl;
    this.deleteWarningTitle = deleteWarningTitle;
    this.deleteWarningMessage = deleteWarningMessage;

    this.activeRowCss = 'ui-state-active';
    this.detailRowCss = 'ui-widget-content';

    this.bind = function () {
        $('#record-table').table();

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

                place.addClass(root.activeRowCss);

                $('#record-tmpl').tmpl(result.Data).insertAfter(place);
                place.next().addClass(root.detailRowCss);

                $('#save-' + result.Data.ID).button().click(function () {
                    saveRecord(result.Data.ID);
                    return false;
                });
                $('#cancel-' + result.Data.ID).button().click(function () {
                    cancelRecord();
                    return false;
                });
                $('.admin-record-detail .detail').slideToggle(500);
            });

            return false;
        });

        $('#record-table a#addRecord').click(function () {
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

                var place = $('#record-table a#addRecord').parent().parent();
                place.addClass(root.activeRowCss);

                $('#record-tmpl').tmpl(result.Data).insertAfter(place);
                place.next().addClass(root.detailRowCss);

                $("#save-0").button().click(function () {
                    saveRecord(0);
                    return false;
                });
                $('#cancel-0').button().click(function () {
                    cancelRecord();
                    return false;
                });
                $('.admin-record-detail .detail').slideToggle(500);
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
        $('.admin-record-detail .detail').slideToggle(500, function () {
            $(this).parent().parent().prev().removeClass(root.activeRowCss);
            $(this).parent().parent().remove();
        });
    }
}
