function LabelController(labelDictionary, multiEditId, popupId, getAllPageLabelUrl, multiEditPageLabelUrl) {
    var root = this;
    this.labelDictionary = labelDictionary;
    this.multiEditId = multiEditId;
    this.popupId = popupId;
    this.getAllPageLabelUrl = getAllPageLabelUrl;
    this.multiEditPageLabelUrl = multiEditPageLabelUrl;

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
            
            $(root.popupId + ' .popup-table-header').table();

            $(root.multiEditId).click(function () {
                $.ajax({
                    type: 'POST',
                    url: root.getAllPageLabelUrl,
                    data: { pageID: pageID }
                }).done(function (result) {
                    if (!result.Success)
                        return;

                    $('[data-labelID]').each(function (i, element) {
                        var id = $(element).attr('data-labelID');
                        var exists = false;
                        $(result.Data).each(function (j, label) {
                            if(label.LabelID == id) {
                                exists = true;
                                return;
                            }
                        });
                        if (!exists){
                            var value;
                            if (element.nodeName == 'INPUT')
                                value = $(element).val();
                            else
                                value = $(element).text();
                            result.Data[result.Data.length] = { LabelID: id, VNText: value, ENText: value };
                        }
                    });
                    $('#label-dictionary').html($('#multi-edit-label-item-tmpl').tmpl(result));

                    root.OpenPopup();
                });
                return false;
            });

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

                    data[data.length] = { LabelID: lblId, VNText: vnText, ENText: enText };
                });
                
                $.ajax({
                    type: 'POST',
                    url: root.multiEditPageLabelUrl,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ pageID: pageID, listLabels: data })
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
        width: 800,
        height: 500,
        modal: true
    });

    //unbind click event for buttons
    $(root.popupId + ' .popup-buttons button').unbind('click');

    this.OpenPopup = function () {
        $(root.popupId).dialog("open");
        SetHeightPopupContent(root.popupId);
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