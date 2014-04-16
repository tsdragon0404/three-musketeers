function Popup(id, url, customCallback) {
    var root = this;
    this.id = id;
    this.url = url;
    this.customCallback = customCallback;
    this.ajaxRequest = null;

    $('#' + id).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: 600,
        //open: function (event, ui) { $(".ui-widget-header").hide(); },
        modal: true
    });

    //unbind click event for buttons
    $('#' + id + ' .button').unbind('click');

    $('#' + id + ' .popupSearch').click(function () {
        root.search();
    });

    $('#' + id + ' .popupSelect').click(function (e) {
        root.select(e);
    });

    $('#' + id + ' .popupClose').click(function () {
        $('#' + id).dialog('close');
    });

    this.OpenPopup = function () {
        root.callServer('GET', null);
        $('#' + id).dialog("open");
    };

    this.callServer = function (method, dataSubmitted) {
        var currentDateTime = new Date();
        var currentTime = currentDateTime.getTime();
        if (root.ajaxRequest != null) { //this may not neccessary when we used ajax loader 
            console.log("ajaxRequest aborted!");
            root.ajaxRequest.abort();
        }
        root.ajaxRequest = $.ajax({
            type: method,
            url: root.url + "?nocache=" + currentTime,
            data: dataSubmitted
        }).done(function (data) {
            $('#' + id + ' .tbContentLookup').html('');
            if (data.ListResult.length > 0) {
                $('#' + id + ' .totalRecords').css('display', 'block');
                //if (data.SortingPagingInfo.Tic == 1) {
                //    $('#' + id + ' .totalRecords > span').html(totalLabel + ' ' + data.SortingPagingInfo.Tic + ' ' + recordLabel);
                //}
                //else {
                //    $('#' + id + ' .totalRecords > span').html(totalLabel + ' ' + data.SortingPagingInfo.Tic + ' ' + recordsLabel);
                //}
                $('#' + id + ' .listLookupEmpty').css('display', 'none');
                $('#' + id + ' .tableContent').css('display', 'block');
            } else {
                $('#' + id + ' .totalRecords').css('display', 'none');
                $('#' + id + ' .totalRecords > span').html(data.SortingPagingInfo.Tic);
                $('#' + id + ' .listLookupEmpty').css('display', 'block');
                $('#' + id + ' .tableContent').css('display', 'none');
            }

            $('#popup-content-' + id).tmpl(data).appendTo('#' + id + ' .tbContentLookup');
            $('#' + id + ' .lastTextSearch').val(data.TextSearch);
            $('#' + id + ' .textSearch').val(data.TextSearch);
            root.populatePagination(data.SortingPagingInfo);
            root.ajaxRequest = null;
        }).error(function (data) {
            console.log(data);
            root.ajaxRequest = null;
        });
    };

    this.search = function () {
        var data = { TextSearch: $('#' + id + ' .textSearch').val() };
        root.callServer('POST', data);
    };

    this.select = function (e) {
        $('#' + id).dialog('close');

        if (customCallback) {
            customCallback(e);
        }
    };
}
