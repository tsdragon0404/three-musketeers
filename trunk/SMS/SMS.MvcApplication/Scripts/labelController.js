function LabelController(labelDictionary, multiEditId, popupId, getAllPageLabelUrl, multiEditPageLabelUrl) {
    var root = this;
    this.labelDictionary = labelDictionary;
    this.multiEditId = multiEditId;
    this.popupId = popupId;
    this.getAllPageLabelUrl = getAllPageLabelUrl;
    this.multiEditPageLabelUrl = multiEditPageLabelUrl;
    var $dialogContainer;
    var $detachedChildren;

    var table;

    this.ScanElements = function () {
        if (root.labelDictionary == null)
            return;
        try {
            $(".ajax-loader-mask").show();
            $('[data-labelID], [data-globalLabelID]').each(function (idx, element) {
                scanElement(element);
            });
        } catch (exception) {
        } finally {
            $(".ajax-loader-mask").hide();
        }
    };
    
    this.BuildEditControl = function (pageID) {
        try {
            $(".ajax-loader-mask").show();
            
            if (root.multiEditId != '') {
                $(root.multiEditId).click(function() {
                    $.ajax({
                        type: 'POST',
                        url: root.getAllPageLabelUrl,
                        data: { pageID: pageID }
                    }).done(function(result) {
                        if (!result.Success)
                            return;

                        $('[data-labelID]').each(function(i, element) {
                            var id = $(element).attr('data-labelID');
                            var exists = false;
                            $(result.Data).each(function(j, label) {
                                if (label.LabelID == id) {
                                    exists = true;
                                    return;
                                }
                            });
                            if (!exists) {
                                var value;
                                if (element.nodeName == 'INPUT')
                                    value = $(element).val();
                                else
                                    value = $(element).text();
                                result.Data[result.Data.length] = { LabelID: id, VNText: value, ENText: value };
                            }
                        });
                        

                        $('#label-dictionary').html($('#multi-edit-label-item-tmpl').tmpl(result));
                        
                        table = $(root.popupId + ' #editLabel').DataTable({
                            scrollY: "200px",
                            searching: true,
                            "dom": '<"H"lr>t<"F"ip>',
                            ordering: true,
                            "info": true,
                            "lengthChange": false,
                            "jQueryUI": true,
                            paging: false,
                            columns: [
                                null,
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

                        applyColumnFilterForDataTable(root.popupId, table, [0, 1, 2]);

                        root.OpenPopup();
                    });
                    return false;
                });
            }
            
            $('#multi-edit-label-save').button({
                icons: {
                    primary: "ui-icon-circle-check"
                }
            }).click(function () {
                var data = [];
                $('#label-dictionary tr').each(function () {
                    var lblId = $(this).find('.page-label-id').text();
                    var vnText = $(this).find('.page-label-vn').val();
                    var enText = $(this).find('.page-label-en').val();

                    data[data.length] = { LabelID: lblId, VNText: vnText, ENText: enText, Page: { ID: pageID } };
                });
                
                $.ajax({
                    type: 'POST',
                    url: root.multiEditPageLabelUrl,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ listLabels: data })
                }).done(function (result) {
                    if(result.Success)
                        location.reload();
                });
                return false;
            });

            $('#multi-edit-label-cancel').button({
                icons: {
                    primary: "ui-icon-circle-close"
                }
            }).click(function () {
                $(root.popupId).dialog('close');
                return false;
            });
            
        } catch (exception) {
        } finally {
            $(".ajax-loader-mask").hide();
        }
    };
    
    $(root.popupId).dialog({
        autoOpen: false,
        closeOnEscape: true,
        resizable: false,
        width: 900,
        height: 600,
        modal: true,
        open: function () {
            $detachedChildren.appendTo($dialogContainer);
        }
    });

    //unbind click event for buttons
    $(root.popupId + ' .popup-buttons button').unbind('click');

    this.OpenPopup = function () {
        $dialogContainer = $(root.popupId);
        $detachedChildren = $dialogContainer.children().detach();

        $(root.popupId).dialog("open");
        fixTableHeader(root.popupId, '#editLabel');
        setHeightPopupContent(root.popupId);
        setHeightTableContent(root.popupId, '#editLabel');
    };

    $.fn.scanLabel = function () {
        if (root.labelDictionary != null) {
            try {
                $(".ajax-loader-mask").show();
                $(this).find('[data-labelID], [data-globalLabelID]').each(function (idx, element) {
                    scanElement(element);
                });
            } catch(exception) {
            } finally {
                $(".ajax-loader-mask").hide();
            }
        }
        return this;
    };

    function scanElement(element) {
        var id = $(element).attr('data-labelID');
        if (id == undefined)
            id = $(element).attr('data-globalLabelID');
        if (root.labelDictionary[id] != undefined && root.labelDictionary[id].trim() != '') {
            if (element.nodeName == 'INPUT')
                $(element).val(root.labelDictionary[id]);
            else
                $(element).text(root.labelDictionary[id]);
        }
    }
}