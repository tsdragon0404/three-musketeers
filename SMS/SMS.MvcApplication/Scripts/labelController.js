function LabelController(labelDictionary, multiEditId, popupId) {
    var root = this;
    this.labelDictionary = labelDictionary;
    this.multiEditId = multiEditId;
    this.popupId = popupId;
    this.inputTemplate = '<input type="text" id="edit-{0}" class="editlabel hide" value="{1}" />';

    this.ScanElements = function () {
        if (labelDictionary == null)
            return;
        try {
            $(".ajax-loader-mask").show();
            var elements = $('span.label, label.label');
            elements.each(function (idx, element) {
                var id = element.id;
                if (root.labelDictionary[id] != undefined && root.labelDictionary[id].trim() != '') {
                    $(element).text(root.labelDictionary[id]);
                }
            });
        } catch (exception) {
        } finally {
            $(".ajax-loader-mask").hide();
        }
    };
    
    this.BuildEditControl = function (pageID) {
        try {
            $(".ajax-loader-mask").show();
            var elements = $('span.label, label.label');
            elements.each(function (idx, element) {
                var id = element.id;
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
                        }).done(function () {
                            location.reload();
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
                root.OpenPopup();
                return false;
            });

            $(root.multiEditId + '-save').click(function () {
                var data = new Object();
                elements.each(function (idx, element) {
                    var inputElement = $(element).next();
                    if ($(inputElement).length != 0) {
                        data[element.id] = $(inputElement).val();
                    }
                });
                $.ajax({
                    type: 'POST',
                    url: location.pathname + '/MultiEditPageLabel',
                    data: { pageID: pageID, labelDictionary: data }
                }).done(function () {
                    location.reload();
                });
            });

            $(root.multiEditId + '-cancel').click(function() {
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
}