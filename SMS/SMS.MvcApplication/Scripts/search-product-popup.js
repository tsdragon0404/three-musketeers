function SearchProductPopup(id, productData, refreshCallback, selectCallback) {
    var root = this;
    this.id = id;
    this.productData = productData;
    this.refreshCallback = refreshCallback;
    this.selectCallback = selectCallback;

    $('#' + root.id).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: 800,
        modal: true
    });

    $('#' + root.id + ' .popup-table-header').table();
    
    $('#' + root.id).sortingTable();
    
    //unbind click event for buttons
    $('#' + root.id + ' button[id^="select-"]').unbind('click');

    $('#' + root.id + ' .popupSearch').button({
        icons: {
            primary: "ui-icon-search"
        }
    }).click(function() {
        root.search();
        return false;
    });

    $('#' + root.id + ' .popupClose').button({
        icons: {
            primary: "ui-icon-close"
        }
    }).click(function() {
        $('#' + root.id).dialog('close');
        return false;
    });

    $('#' + root.id + ' .popupRefresh').button({
        icons: {
            primary: "ui-icon-refresh"
        }
    }).click(function() {
        if (root.refreshCallback)
            root.refreshCallback(reloadProduct);
        return false;
    });

    this.OpenPopup = function () {
        root.renderProducts(root.productData);
        $('#' + root.id).dialog("open");
        SetHeightPopupContent('#' + root.id);
    };

    function reloadProduct(newProductData) {
        root.productData = newProductData;
        root.renderProducts(newProductData);
    }

    this.renderProducts = function (data) {
        $('#total').html(data.length);
        if (data.length > 0) {
            $('#' + root.id + ' .totalRecords').removeClass('hide');
            $('#' + root.id + ' .listLookupEmpty').addClass('hide');
            $('#' + root.id + ' #searchProduct').removeClass('hide');
        } else {
            $('#' + root.id + ' .totalRecords').addClass('hide');
            $('#' + root.id + ' .listLookupEmpty').removeClass('hide');
            $('#' + root.id + ' #searchProduct').addClass('hide');
        }

        $.each(data, function (idx) {
            data[idx].tabIdx = idx * 2 + 2;
        });
        
        $('#' + root.id + ' .tbContentLookup').html($('#popup-content-' + root.id).tmpl({ ListProduct: data }));
        
        $('input[id^="popup-qty"]').spinner({
            step: 0.5,
            numberFormat: "n",
            min: 0.5
        });

        $('#' + root.id + ' .popupSelect').button({
            icons: {
                primary: "ui-icon-circle-check"
            }
        }).click(function(e) {
            var pdtid = e.currentTarget.id.split('-')[1];
            if ($('#popup-qty-' + pdtid).valid())
                root.select(e);
            return false;
        });
            
        $('#' + root.id + ' .popupSelect').keypress(function (e) {
            if (e.which == 13) {
                $(e.target).trigger('click');
            }
        });
            
        $('#' + root.id + ' .tbContentLookup tr').dblclick(function (e) {
            $(e.currentTarget).find('button.popupSelect').trigger('click');
        });
        
        // stop Propagation on spinner element (double click on spinner will not trigger row double click)
        $('.tbContentLookup .ui-spinner').dblclick(function (e) {
            e.stopPropagation();
        });
        
        $('#' + root.id + ' .inputQty').keypress(function (e) {
            if (e.which == 13) {
                var pdtid = e.target.id.split('-')[1];
                $('#select-' + pdtid).focus();
                return;
            }
        });
    };

    this.search = function () {
        var text = $('#' + root.id + ' .textSearch').val().toLowerCase();
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
        $('#' + root.id).dialog('close');
        var pdtId = e.currentTarget.id.split('-')[1];
        var qty = $(e.currentTarget).parent().prev().find('input[id^="popup-qty"]').val();

        if (root.selectCallback)
            root.selectCallback(pdtId, qty);
    };
}