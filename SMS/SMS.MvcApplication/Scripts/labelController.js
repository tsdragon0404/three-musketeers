function LabelController(labelDictionary, multiEditId, popupId) {
    var root = this;
    this.labelDictionary = labelDictionary;
    this.multiEditId = multiEditId;
    this.popupId = popupId;
    this.inputTemplate = '<input type="text" id="edit-{0}" class="editlabel hide" value="{1}" />';

    this.ScanElements = function () {
        if (root.labelDictionary == null)
            return;
        try {
            $(".ajax-loader-mask").show();
            $('[data-labelID]').each(function (idx, element) {
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
            
            $(root.multiEditId).click(function () {
                $.ajax({
                    type: 'POST',
                    url: location.pathname + '/GetAllPageLabel',
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
                        if (!exists)
                            result.Data[result.Data.length] = { LabelID: id, VNText: '', ENText: '' };
                    });
                    $('#label-dictionary').html($('#multi-edit-label-item-tmpl').tmpl(result));
                    $('#label-dictionary').parent('table').table();

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
                    url: location.pathname + '/MultiEditPageLabel',
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
                $(this).find('[data-labelID]').each(function(idx, element) {
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
        var id = $(element).attr('data-labelid');
        if (root.labelDictionary[id] != undefined && root.labelDictionary[id].trim() != '') {
            if (element.nodeName == 'INPUT')
                $(element).val(root.labelDictionary[id]);
            else
                $(element).text(root.labelDictionary[id]);
        }
    }
}