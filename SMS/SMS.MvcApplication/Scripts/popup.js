function Popup(id, url, resultDisplayControlId, resultHiddenControlId, resultValueControlId, numDisplayEntries, numEdgeEntries,
    searchLabel, selectLabel, closeLabel, totalLabel, recordsLabel, recordLabel, type, pageSize, customCallback) {
    var root = this;
    this.id = id;
    this.url = url;
    this.totalLabel = totalLabel;
    this.recordsLabel = recordsLabel;
    this.recordLabel = recordLabel;
    this.searchLabel = searchLabel;
    this.selectLabel = selectLabel;
    this.closeLabel = closeLabel;
    this.resultDisplayControlId = resultDisplayControlId;
    this.resultHiddenControlId = resultHiddenControlId;
    this.resultValueControlId = resultValueControlId;
    this.numDisplayEntries = numDisplayEntries;
    this.numEdgeEntries = numEdgeEntries;
    this.type = type;
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

    $('#' + id + ' .popupLookupSearch').click(function () {
        root.search();
    });

    $('#' + id + ' .popupLookupSelect').click(function () {
        root.select(root.type);
    });

    $('#' + id + ' .popupLookupClose').click(function () {
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

            $.each(data.ListLookup, function (index, obj) {
                var arr = $.grep(root.checkeds, function (elem) {
                    return (elem.id == obj.Value);
                });
                if (arr.length > 0) {
                    data.ListLookup[index].Selected = "checked";
                }
            });

            $('#popup-content-' + id).tmpl(data).appendTo('#' + id + ' .tbContentLookup');
            $('#' + id + ' .lastTextSearch').val(data.TextSearch);
            $('#' + id + ' .textSearch').val(data.TextSearch);
            root.populatePagination(data.SortingPagingInfo);
            root.ajaxRequest = null;
        }).error(function (data) {
            //messageManager.error(data.statusText);
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

    this.select = function (inputType) {
        var temp = "",
            ids = "",
            valueReturn;
        if (inputType == null) {
            valueReturn = $('input[type=radio]:checked', '#' + id);
            $.each(valueReturn, function (index, value) {
                temp += $(value).val() + ",";
                ids += $(value).attr('id') + ",";
            });
        } else {
            valueReturn = $('input[type=checkbox]:checked', '#' + id);
            if (valueReturn.length == 0) {
                valueReturn = $('input[type=checkbox]', '#' + id);
                if (root.checkeds.length > 0) {
                    $.each(valueReturn, function (index, obj) {
                        root.checkeds = $.grep(root.checkeds, function (elem) {
                            return elem.id != $(obj).attr("id");
                        });
                    });
                }
                $.each(root.checkeds, function (index, item) {
                    temp += item.name + ",";
                    ids += item.id + ",";
                });
            } else if (valueReturn == root.pageSize) {
                if (root.checkeds.length > 0) {
                    $.each(valueReturn, function (index, obj) {
                        var arr = $.grep(root.checkeds, function (elem) {
                            return (elem.id == $(obj).attr("id"));
                        });
                        if (arr.length == 0) {
                            root.checkeds.push({ id: $(obj).attr("id"), name: $(obj).val() });
                        }
                    });
                } else {
                    $.each(valueReturn, function (index, obj) {
                        if ($(obj).is(':checked')) {
                            root.checkeds.push({ id: $(obj).attr("id"), name: $(obj).val() });
                        }
                    });
                }
                $.each(root.checkeds, function (index, item) {
                    temp += item.name + ",";
                    ids += item.id + ",";
                });
            } else {
                valueReturn = $('input[type=checkbox]', '#' + id);
                if (root.checkeds.length > 0) {
                    $.each(valueReturn, function (index, obj) {
                        if (!$(obj).is(':checked')) {
                            root.checkeds = $.grep(root.checkeds, function (elem) {
                                return elem.id != $(obj).attr("id");
                            });
                        } else {
                            var arr = $.grep(root.checkeds, function (elem) {
                                return (elem.id == $(obj).attr("id"));
                            });
                            if (arr.length == 0) {
                                root.checkeds.push({ id: $(obj).attr("id"), name: $(obj).val() });
                            }
                        }
                    });
                } else {
                    $.each(valueReturn, function (index, obj) {
                        if ($(obj).is(':checked')) {
                            var arr = $.grep(root.checkeds, function (elem) {
                                return (elem.id == $(obj).attr("id"));
                            });
                            if (arr.length == 0) {
                                root.checkeds.push({ id: $(obj).attr("id"), name: $(obj).val() });
                            }
                        }
                    });
                }
                $.each(root.checkeds, function (index, item) {
                    temp += item.name + ",";
                    ids += item.id + ",";
                });
            }
        }
        if (temp != "") {
            temp = temp.slice(0, -1);
        }
        if (ids != "") {
            ids = ids.slice(0, -1);
        }

        var attValidate = $('#' + resultDisplayControlId).attr("data-val");
        if (attValidate != undefined) {
            $('#' + resultDisplayControlId).val(temp).valid();
        } else {
            $('#' + resultDisplayControlId).val(temp);
        }

        // $('#' + resultDisplayControlId).val(temp).valid();
        $('#' + resultHiddenControlId).val(temp);
        $('#' + resultValueControlId).val(ids);
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
        if (root.type) {
            var inputs = $('#' + id + " input[type='checkbox']:checked");
            $.each(inputs, function (idx, ele) {
                var arr = $.grep(root.checkeds, function (elem) {
                    return (elem.id == $(ele).val());
                });
                if (arr.length == 0) {
                    root.checkeds.push({ id: $(ele).attr("id"), name: $(ele).val() });
                }
            });
        }
        root.search();
        return false;
    };
}
