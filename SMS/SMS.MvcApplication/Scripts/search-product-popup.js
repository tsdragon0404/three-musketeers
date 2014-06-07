function SearchProductPopup(id, productData, refreshCallback, selectCallback) {
    var root = this;
    this.id = id;
    this.productData = productData;
    this.refreshCallback = refreshCallback;
    this.selectCallback = selectCallback;

    $('#' + id).dialog({
        dialogClass: "no-close",
        autoOpen: false,
        closeOnEscape: true,
        width: 800,
        modal: true
    });

    //unbind click event for buttons
    $('#' + id + ' button[id^="select-"]').unbind('click');

    $('#' + id + ' .popupSearch').button({
        icons: {
            primary: "ui-icon-search"
        }
    }).click(function() {
        root.search();
        return false;
    });

    $('#' + id + ' .popupClose').button({
        icons: {
            primary: "ui-icon-close"
        }
    }).click(function() {
        $('#' + id).dialog('close');
        return false;
    });

    $('#' + id + ' .popupRefresh').button({
        icons: {
            primary: "ui-icon-refresh"
        }
    }).click(function() {
        if (refreshCallback)
            refreshCallback(reloadProduct);
        return false;
    });

    this.OpenPopup = function () {
        root.renderProducts(root.productData);
        $('#' + id).dialog("open");
        SetHeightPopupContent('#' + root.id);
    };

    function reloadProduct(newProductData) {
        root.productData = newProductData;
        root.renderProducts(newProductData);
    }

    this.renderProducts = function (data) {
        $('#' + id + ' .tbContentLookup').html('');
        $('#total').html(data.length);
        if (data.length > 0) {
            $('#' + id + ' .totalRecords').removeClass('hide');
            $('#' + id + ' .listLookupEmpty').addClass('hide');
            $('#' + id + ' .tableContent').removeClass('hide');
        } else {
            $('#' + id + ' .totalRecords').addClass('hide');
            $('#' + id + ' .listLookupEmpty').removeClass('hide');
            $('#' + id + ' .tableContent').addClass('hide');
        }

        $.each(data, function (idx) {
            data[idx].tabIdx = idx * 2 + 2;
        });

        $('#popup-content-' + id).tmpl(data).appendTo('#' + id + ' .tbContentLookup');

        $('input[id^="popup-qty"]').spinner({
            step: 0.5,
            numberFormat: "n",
            min: 0.5
        });

        $('#' + id + ' .popupSelect').button({
            icons: {
                primary: "ui-icon-circle-check"
            }
        }).click(function(e) {
            var pdtid = e.currentTarget.id.split('-')[1];
            if ($('#popup-qty-' + pdtid).valid())
                root.select(e);
            return false;
        });
            
        $('#' + id + ' .popupSelect').keypress(function (e) {
            if (e.which == 13) {
                $(e.target).trigger('click');
            }
        });
            
        $('#' + id + ' .tbContentLookup tr').dblclick(function (e) {
            $(e.currentTarget).find('button.popupSelect').trigger('click');
        });
        
        // stop Propagation on spinner element (double click on spinner will not trigger row double click)
        $('.tbContentLookup .ui-spinner').dblclick(function (e) {
            e.stopPropagation();
        });
        
        $('#' + id + ' .inputQty').keypress(function (e) {
            if (e.which == 13) {
                var pdtid = e.target.id.split('-')[1];
                $('#select-' + pdtid).focus();
                return;
            }
        });
    };

    this.search = function () {
        var text = $('#' + id + ' .textSearch').val().toLowerCase();
        var tempData = new Array();
        
        $(root.productData).each(function(idx, element) {
            if (element.ProductCode.toLowerCase().indexOf(text) != -1
                || element.Name.toLowerCase().indexOf(text) != -1) {
                tempData.push(element);
            }
        });

        root.renderProducts(tempData);
    };

    this.select = function (e) {
        $('#' + id).dialog('close');
        var pdtId = e.currentTarget.id.split('-')[1];
        var qty = $(e.currentTarget).parent().prev().find('input[id^="popup-qty"]').val();

        if (selectCallback)
            selectCallback(pdtId, qty);
    };
}