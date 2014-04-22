function SearchProductPopup(id, productData, refreshCallback) {
    var root = this;
    this.id = id;
    this.productData = productData;
    this.refreshCallback = refreshCallback;

    $('#' + id).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: 700,
        modal: true
    });

    //unbind click event for buttons
    $('#' + id + ' .button').unbind('click');

    $('#' + id + ' .popupSearch').click(function () {
        root.search();
    });

    $('#' + id + ' .popupClose').click(function () {
        $('#' + id).dialog('close');
    });

    $('#' + id + ' .popupRefresh').click(function () {
        if (refreshCallback)
            refreshCallback(reloadProduct);
    });

    this.OpenPopup = function () {
        root.loadProduct(null);
        $('#' + id).dialog("open");
    };

    function reloadProduct(newProductData) {
        root.productData = newProductData;
        root.loadProduct(null);
    }

    this.loadProduct = function (criteria) {
        $('#' + id + ' .tbContentLookup').html('');
        $('#total').html(root.productData.length);
        if (root.productData.length > 0) {
            $('#' + id + ' .totalRecords').removeClass('hide');
            $('#' + id + ' .listLookupEmpty').addClass('hide');
            $('#' + id + ' .tableContent').removeClass('hide');
        } else {
            $('#' + id + ' .totalRecords').addClass('hide');
            $('#' + id + ' .listLookupEmpty').removeClass('hide');
            $('#' + id + ' .tableContent').addClass('hide');
        }

        $.each(root.productData, function (idx) {
            root.productData[idx].tabIdx = idx * 2 + 2;
        });

        $('#popup-content-' + id).tmpl(root.productData).appendTo('#' + id + ' .tbContentLookup');

        $('#' + id + ' .popupSelect').click(function (e) {
            var pdtid = e.target.id.split('-')[1];
            if ($('#qty-' + pdtid).valid())
                root.select(e);
        });
            
        $('#' + id + ' .popupSelect').keypress(function (e) {
            if (e.which == 13) {
                $(e.target).trigger('click');
            }
        });
            
        $('#' + id + ' .tbContentLookup tr').dblclick(function (e) {
            $(e.currentTarget).find('input.popupSelect').trigger('click');
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
        var data = { TextSearch: $('#' + id + ' .textSearch').val() };
        root.loadProduct(data);
    };

    this.select = function (e) {
        $('#' + id).dialog('close');

        var targetId = e.target.id;
        var pdtId = targetId.split('-')[1];
        var qty = $(e.target).parent().prev().find('input[id^="qty"]').val();
        $.ajax({
            type: 'POST',
            url: '/Cashier/SelectProduct',
            data: { productId: pdtId, quantity: qty }
        }).done(function (data) {
            var count = $('#order .tbContent tr').length;
            data.idx = count + 1;

            $('#pdt-tmpl').tmpl(data).appendTo('#order .tbContent');
        });
    };
}
