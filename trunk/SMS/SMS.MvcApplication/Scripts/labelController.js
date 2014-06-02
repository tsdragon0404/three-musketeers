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
            var elements = $('span[data-labelID], label[data-labelID]');
            elements.each(function (idx, element) {
                var id = $(element).attr('data-labelID');
                $(element).after(root.inputTemplate.replace('{0}', id).replace('{1}', $(element).text()));
                var insertedElement = $(element).next();
                $(insertedElement).attr('style', 'height: ' + element.offsetHeight + 'px; width: ' + element.offsetWidth + 'px;');

                $(element).dblclick(function() {
                    $(element).addClass('hide');
                    $(insertedElement).removeClass('hide');
                    $(insertedElement).focus();
                    
                    $(insertedElement).blur(function () {
                        $.ajax({
                            type: 'POST',
                            url: location.pathname + '/EditPageLabel',
                            data: { text: $(insertedElement).val(), pageID: pageID, labelID: id }
                        }).done(function (result) {
                            if (result.Success)
                                $(element).text($(insertedElement).val());
                            else
                                $(insertedElement).val($(element).text());

                            $(element).removeClass('hide');
                            $(insertedElement).addClass('hide');
                        });
                    });
                    $(insertedElement).keypress(function (e) {
                        if (e.which == 13) {
                            $(e.target).trigger('blur');
                        }
                    });
                });
            });
            
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

                    root.OpenPopup();
                });
                return false;
            });

            $('#multi-edit-label-save').click(function () {
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
            });

            $('#multi-edit-label-cancel').click(function () {
                $(root.popupId).dialog('close');
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
        width: 500,
        height: 500,
        modal: true
    });

    //unbind click event for buttons
    $(root.popupId + ' .button').unbind('click');

    this.OpenPopup = function () {
        $(root.popupId).dialog("open");
    };

    $.fn.scanLabel = function () {
        if (root.labelDictionary == null)
            return;
        try {
            $(".ajax-loader-mask").show();
            $(this).find('[data-labelID]').each(function (idx, element) {
                scanElement(element);
            });
        } catch (exception) {
        } finally {
            $(".ajax-loader-mask").hide();
        }
    };

    function scanElement(element) {
        var id = $(element).attr('data-labelID');
        if (root.labelDictionary[id] != undefined && root.labelDictionary[id].trim() != '') {
            if (element.nodeName == 'INPUT')
                $(element).val(root.labelDictionary[id]);
            else
                $(element).text(root.labelDictionary[id]);
        }
    }
}