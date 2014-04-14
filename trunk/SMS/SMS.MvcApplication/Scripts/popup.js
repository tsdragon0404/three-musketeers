function Popup(id, url, numDisplayEntries, numEdgeEntries, pageSize, customCallback) {
    var root = this;
    this.id = id;
    this.url = url;
    this.numDisplayEntries = numDisplayEntries;
    this.numEdgeEntries = numEdgeEntries;
    this.pageSize = pageSize;
    this.customCallback = customCallback;
    this.ajaxRequest = null;
    this.checkeds = [];

    $('#' + id).dialog({
        autoOpen: false,
        closeOnEscape: false,
        width: 600,
        //open: function (event, ui) { $(".ui-widget-header").hide(); },
        modal: true
    });

    //unbind click event for buttons
    $('#' + id + ' .button').unbind('click');

    $('#' + id + ' .popupSearch').click(function () {
        root.search();
    });

    $('#' + id + ' .popupSelect').click(function () {
        root.select();
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
            if (data.SortingPagingInfo.Tic > 0) {
                $('#' + id + ' .totalRecords').css('display', 'block');
                if (data.SortingPagingInfo.Tic == 1) {
                    $('#' + id + ' .totalRecords > span').html(totalLabel + ' ' + data.SortingPagingInfo.Tic + ' ' + recordLabel);
                }
                else {
                    $('#' + id + ' .totalRecords > span').html(totalLabel + ' ' + data.SortingPagingInfo.Tic + ' ' + recordsLabel);
                }
                $('#' + id + ' .listLookupEmpty').css('display', 'none');
                $('#' + id + ' .tableContent').css('display', 'block');
            } else {
                $('#' + id + ' .totalRecords').css('display', 'none');
                $('#' + id + ' .totalRecords > span').html(data.SortingPagingInfo.Tic);
                $('#' + id + ' .listLookupEmpty').css('display', 'block');
                $('#' + id + ' .tableContent').css('display', 'none');
            }

            //$.each(data.ListLookup, function (index, obj) {
            //    var arr = $.grep(root.checkeds, function (elem) {
            //        return (elem.id == obj.Value);
            //    });
            //    if (arr.length > 0) {
            //        data.ListLookup[index].Selected = "checked";
            //    }
            //});

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
        if ($('#' + id + ' .lastTextSearch').val() != $('#' + id + ' .textSearch').val()) {
            $('#' + id + ' .currentPage').val(1);
        }
        var data = { CurrentPage: $('#' + id + ' .currentPage').val(), TextSearch: $('#' + id + ' .textSearch').val() };
        root.callServer('POST', data);
    };

    this.select = function () {
        var temp = "",
            ids = "",
            valueReturn;
        
        valueReturn = $('input[type=radio]:checked', '#' + id);
        $.each(valueReturn, function (index, value) {
            temp += $(value).val() + ",";
            ids += $(value).attr('id') + ",";
        });
        
        if (temp != "") {
            temp = temp.slice(0, -1);
        }
        if (ids != "") {
            ids = ids.slice(0, -1);
        }

        $('#' + id).dialog('close');

        var returnId = valueReturn.attr('id');

        if (customCallback) {
            customCallback(returnId);
        }
    };

    this.populatePagination = function (page) {
        var optInit = {
            callback: root.pageSelectedCallback,
            callCallbackWhenInit: false,
            items_per_page: page.Ps,
            numDisplayEntries: numDisplayEntries,
            numEdgeEntries: numEdgeEntries,
            current_page: (page.Cp - 1),
        };
        $('#' + id + ' .currentPage').val(page.Cp);
        $('#' + id + ' .pagination').pagination(page.Tic, optInit);
    };

    this.pageSelectedCallback = function (pageIndex) {
        $('#' + id + ' .currentPage').val(pageIndex + 1);
        root.search();
        return false;
    };
}
