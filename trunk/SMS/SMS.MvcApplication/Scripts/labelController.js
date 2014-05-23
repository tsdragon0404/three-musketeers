function LabelController(labelDictionary) {
    var root = this;
    this.labelDictionary = labelDictionary;
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
                });

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
        } catch (exception) {
        } finally {
            $(".ajax-loader-mask").hide();
        }
    };
}