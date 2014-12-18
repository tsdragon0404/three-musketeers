function SearchProductPopup(id, productData, refreshCallback, selectCallback) {
    var root = this;
    this.id = id;
    this.popupId = '#' + id;
    this.productData = productData;
    this.refreshCallback = refreshCallback;
    this.selectCallback = selectCallback;
    var $dialogContainer;
    var $detachedChildren;

    var table;

    $(root.popupId).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: 870,
        height: 500,
        modal: true,
        resizable: false,
        open: function () {
            $detachedChildren.appendTo($dialogContainer);
        }
    });

    // start main button
    $(root.popupId + ' .popupClose').button({
        icons: {
            primary: "ui-icon-close"
        }
    }).click(function() {
        $(root.popupId).dialog('close');
        return false;
    });

    $(root.popupId + ' .popupRefresh').button({
        icons: {
            primary: "ui-icon-refresh"
        }
    }).click(function() {
        if (root.refreshCallback)
            root.refreshCallback(reloadProduct);
        return false;
    });
    // end main button

    this.OpenPopup = function () {
        $dialogContainer = $(root.popupId);
        $detachedChildren = $dialogContainer.children().detach();

        $(root.popupId).dialog("open");
        fixTableHeader(root.popupId, '#searchProduct');
        setHeightPopupContent(root.popupId);
        setHeightTableContent(root.popupId, '#searchProduct');
    };
    
    function reloadProduct(newProductData) {
        root.productData = newProductData;
        root.renderProducts(newProductData);
        SetHeightTableContent(root.popupId, '#searchProduct');
    }

    this.renderProducts = function (data) {

        $.each(data, function (idx) {
            data[idx].tabIdx = idx * 2 + 2;
        });
        
        if ($.fn.DataTable.isDataTable(root.popupId + ' #searchProduct')) {
            table.destroy();
        }
        
        $(root.popupId + ' .tbContentLookup').html($('#popup-content-' + root.id).tmpl({ ListProduct: data }));

        $('input[id^="popup-qty"]').spinner({
            step: 0.5,
            numberFormat: "n",
            min: 0.5
        });

        $(root.popupId + ' span[id^="productCode-"]').unbind('click');
        $(root.popupId + ' span[id^="productCode-"]').click(function (e) {
            var pdtid = e.currentTarget.id.split('-')[1];
            if ($('#popup-qty-' + pdtid).valid())
                root.select(e);
            return false;
        });
        
        $(root.popupId + ' .tbContentLookup tr').dblclick(function (e) {
            $(e.currentTarget).find('span[id^="productCode-"]').trigger('click');
        });

        // stop Propagation on spinner element (double click on spinner will not trigger row double click)
        $('.tbContentLookup .ui-spinner').dblclick(function (e) {
            e.stopPropagation();
        });
        
        table = $(root.popupId + ' #searchProduct').DataTable({
            scrollY: "200px",
            searching: true,
            "dom": '<"H"lr>t<"F"ip>',
            ordering: true,
            "info": true,
            "lengthChange": false,
            "jQueryUI": true,
            paging: true,
            columns: [
                null,
                null,
                null,
                null,
                { "orderable": false }
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

        applyColumnFilterForDataTable(root.popupId, table, [0, 1, 2, 3]);
    };

    this.select = function (e) {
        $(root.popupId).dialog('close');
        var pdtId = e.currentTarget.id.split('-')[1];
        var qty = $(e.currentTarget).parents('tr').find('input[id^="popup-qty"]').val();

        if (root.selectCallback)
            root.selectCallback(pdtId, qty);
    };
    
    root.renderProducts(root.productData);
}