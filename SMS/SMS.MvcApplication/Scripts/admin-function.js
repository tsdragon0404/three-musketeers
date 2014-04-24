function AdminFunction(getSchemaForAddUrl, getDataForEditUrl) {
    var root = this;
    
    this.getSchemaForAddUrl = getSchemaForAddUrl;
    this.getDataForEditUrl = getDataForEditUrl;

    this.bind = function() {
        $('.admin-list-record a[id^="edit"]').click(function () {
            var record = $(this).parent().parent();
            if (record.length == 0 || record.next().hasClass('admin-record-detail')) {
                record.next().find('div.detail').slideToggle(500, function () {
                    record.next().remove();
                });
                return false;
            }

            var id = $(this).siblings('input[name^="id"]').val();
            $.ajax({
                type: 'POST',
                url: root.getDataForEditUrl,
                data: { recordID: id }
            }).done(function (data) {
                $('.admin-record-detail .detail').slideToggle(500, function () {
                    $(this).parent().parent().remove();
                });

                var clientId = $('.admin-list-record input[name^="id-' + data.ID + '"]');
                if (clientId.length == 0 || clientId.val() != data.ID)
                    return;

                var record = clientId.parent().parent();

                $('#record-tmpl').tmpl(data).insertAfter(record);
                $("#save").click(function () {
                    saveRecord();
                    return false;
                });
                $('#cancel').click(function () {
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
                record.next().find('div.detail').slideToggle(500, function () {
                    record.next().remove();
                });
                return false;
            }

            $.ajax({
                type: 'POST',
                url: root.getSchemaForAddUrl,
            }).done(function (data) {
                $('.admin-record-detail .detail').slideToggle(500, function () {
                    $(this).parent().parent().remove();
                });

                var place = $('.admin-table-record a#addRecord').parent().parent();

                $('#record-tmpl').tmpl(data).insertAfter(place);
                $("#save").click(function () {
                    saveRecord();
                    return false;
                });
                $('#cancel').click(function () {
                    cancelRecord();
                    return false;
                });
                $('.admin-record-detail .detail').slideToggle(500);
            });

            return false;
        });
    };

    function saveRecord() {

    }

    function cancelRecord() {
        $('.admin-record-detail .detail').slideToggle(500, function () {
            $(this).parent().parent().remove();
        });
    }
}
