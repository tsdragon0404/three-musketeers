function AdminFunction(getSchemaForAddUrl, getDataForEditUrl, saveDataUrl, getDataForSaveCallback, deleteDataUrl) {
    var root = this;
    
    this.getSchemaForAddUrl = getSchemaForAddUrl;
    this.getDataForEditUrl = getDataForEditUrl;
    this.saveDataUrl = saveDataUrl;
    this.getDataForSaveCallback = getDataForSaveCallback;
    this.deleteDataUrl = deleteDataUrl;
    
    this.bind = function() {
        $('.admin-list-record a.edit-record').click(function () {
            var record = $(this).parent().parent();
            if (record.length == 0 || record.next().hasClass('admin-record-detail')) {
                record.removeClass('selected');
                record.next().find('div.detail').slideToggle(500, function () {
                    record.next().remove();
                });
                return false;
            }

            var id = $(this).attr('data-id');
            $.ajax({
                type: 'POST',
                url: root.getDataForEditUrl,
                data: { recordID: id }
            }).done(function (data) {
                cancelRecord();

                var place = $('tr[data-id="' + data.ID + '"]');
                if (place.length == 0)
                    return;

                place.addClass('selected');

                $('#record-tmpl').tmpl(data).insertAfter(place);
                $('#save-' + data.ID).click(function () {
                    saveRecord(data.ID);
                    return false;
                });
                $('#cancel-' + data.ID).click(function () {
                    cancelRecord();
                    return false;
                });
                $('.admin-record-detail .detail').slideToggle(500);
            });

            return false;
        });

        $('.admin-table-record a#addRecord').click(function () {
            var record = $(this).parent().parent();
            if (record.length == 0 || record.next().hasClass('admin-record-detail')) {
                record.removeClass('selected');
                record.next().find('div.detail').slideToggle(500, function () {
                    record.next().remove();
                });
                return false;
            }

            $.ajax({
                type: 'POST',
                url: root.getSchemaForAddUrl,
            }).done(function (data) {
                cancelRecord();

                var place = $('.admin-table-record a#addRecord').parent().parent();
                place.addClass('selected');

                $('#record-tmpl').tmpl(data).insertAfter(place);
                $("#save-0").click(function () {
                    saveRecord(0);
                    return false;
                });
                $('#cancel-0').click(function () {
                    cancelRecord();
                    return false;
                });
                $('.admin-record-detail .detail').slideToggle(500);
            });

            return false;
        });

        $('.admin-list-record a.del-record').click(function () {
            var id = $(this).attr('data-id');
            var popup = new MessagePopup('Warning',
                'Delete this record?',
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
        }).done(function (data) {
            if (data == true)
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
        }).done(function (data) {
            if (data == true)
                location.reload();
        });
    }

    function cancelRecord() {
        $('.admin-record-detail .detail').parent().parent().prev().removeClass('selected');
        $('.admin-record-detail .detail').slideToggle(500, function () {
            $(this).parent().parent().remove();
        });
    }
}
