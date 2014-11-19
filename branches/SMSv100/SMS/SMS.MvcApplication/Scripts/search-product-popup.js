﻿function SearchProductPopup(id, productData, refreshCallback, selectCallback) {
    var root = this;
    this.id = id;
    this.productData = productData;
    this.refreshCallback = refreshCallback;
    this.selectCallback = selectCallback;

    var table;

    $('#' + root.id).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: 870,
        height: 500,
        modal: true,
        resizable: false
    });

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
        $('#' + root.id).dialog("open");
        SetHeightPopupContent('#' + root.id);
        SetHeightTableContent();
        fixTableHeader();
    };

    function SetHeightTableContent() {
        var contentHeight = $('#' + root.id + ' .popup-content').height();
        var height1 = $('#searchProduct_wrapper > .ui-widget-header').outerHeight();
        var height2 = $('#searchProduct_wrapper > .dataTables_scroll > .dataTables_scrollHead').outerHeight();

        var targetHeight = contentHeight - height1*2 - height2 - 7; // subtract 2 more px due to the border and padding bottom
        $('#searchProduct_wrapper > .dataTables_scroll > .dataTables_scrollBody').css('height', targetHeight + 'px');
    }
    
    function reloadProduct(newProductData) {
        root.productData = newProductData;
        root.renderProducts(newProductData);
        SetHeightTableContent();
    }

    this.renderProducts = function (data) {

        $.each(data, function (idx) {
            data[idx].tabIdx = idx * 2 + 2;
        });
        
        if ($.fn.DataTable.isDataTable('#' + root.id + ' #searchProduct')) {
            table.destroy();
        }
        
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
        }).click(function (e) {
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
        
        $('#' + root.id + ' #searchProduct').off('draw.dt');
        $('#' + root.id + ' #searchProduct').on('draw.dt', function () {
            fixTableHeader();
        });
        
        table = $('#' + root.id + ' #searchProduct').DataTable({
            scrollY: "200px",
            renderer: "bootstrap",
            columns: [
                null,
                null,
                null,
                null,
                null,
                { "orderable": false },
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
    };

    function fixTableHeader() {
        $('#' + root.id + ' .dataTables_scrollHeadInner, #' + root.id + ' .dataTables_scrollHeadInner > table').css('width', '').css('padding-left', '');

        var headerColumns = $('#' + root.id + ' .dataTables_scrollHead table > thead > tr:first-child th');
        var columns = $('#' + root.id + ' #searchProduct > tbody > tr:first-child td');

        for (var i = 0; i < columns.length; i++) {
            $(headerColumns[i]).css('width', $(columns[i]).width());
        }
    }
    
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
    
    root.renderProducts(root.productData);
}