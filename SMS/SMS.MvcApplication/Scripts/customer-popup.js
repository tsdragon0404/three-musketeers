function CustomerPopup(id, orderId, getDataUrl, functionCallback) {
    var root = this;
    this.id = id;
    this.orderId = orderId;
    this.getDataUrl = getDataUrl;
    this.functionCallback = functionCallback;
    this.popupId = '#' + id;
    var $dialogContainer;
    var $detachedChildren;
    
    var table;

    $('#' + root.id).dialog({
        dialogClass: "no-close",
        autoOpen: false,
        closeOnEscape: true,
        width: 950,
        height: 600,
        modal: true,
        resizable: false,
        open: function () {
            $detachedChildren.appendTo($dialogContainer);
        }
    });
    
    $(root.popupId + ' .popupClose').unbind('click');
    $(root.popupId + ' .popupClose').button({
        icons: {
            primary: "ui-icon-close"
        }
    }).click(function () {
        $(root.popupId).dialog('close');
        return false;
    });
    
    $(root.popupId + ' #useInputCustomer').unbind('change');
    $(root.popupId + ' #useInputCustomer').change(function () {
        bindEvent();
    });
    
    $(root.popupId + ' #btnOK').unbind('click');
    $(root.popupId + ' #btnOK').button({
        icons: {
            primary: "ui-icon-check"
        }
    }).click(function () {
        var customerName = $(root.popupId + ' #customerName').val();
        var address = $(root.popupId + ' #address').val();
        var cellPhone = $(root.popupId + ' #cellPhone').val();
        var dob = $(root.popupId + ' #DOB').val();
        root.functionCallback(root.orderId, 0, customerName, address, cellPhone, dob);
        $(root.popupId).dialog('close');
    });

    this.OpenPopup = function () {
        $("#DOB").datepicker();

        $.ajax({
            type: 'POST',
            url: root.getDataUrl + "/GetOrderBasic",
            data: { orderID: root.orderId }
        }).done(function (result) {
            if(result.Success) {
                if(result.Data.Customer == null) {
                    $(root.popupId + ' #useInputCustomer').prop('checked', true);
                    $(root.popupId + ' #customerName').val(result.Data.CustomerName);
                    $(root.popupId + ' #address').val(result.Data.Address);
                    $(root.popupId + ' #cellPhone').val(result.Data.CellPhone);
                    $(root.popupId + ' #DOB').val(result.Data.DOB==null ? '' : result.Data.DOB.formatAsDate());
                } else {
                    $(root.popupId + ' #useInputCustomer').prop('checked', false);
                }
                
                $.ajax({
                    type: 'POST',
                    url: root.getDataUrl + "/GetCustomer"
                }).done(function (data) {
                    if (data.Success) {
                        
                        if ($.fn.DataTable.isDataTable(root.popupId + ' #chooseCustomer')) {
                            $(root.popupId + ' .datatable_filter').remove();
                            table = $(root.popupId + ' #chooseCustomer').DataTable();
                            table.destroy();
                        }
                        
                        $(root.popupId + ' #customer-table').html($('#customer-tmpl').tmpl(data));

                        bindEvent();
                        
                        table = $(root.popupId + ' #chooseCustomer').DataTable({
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
                                null
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

                        applyColumnFilterForDataTable(root.popupId, table, [0, 1, 2, 3, 4]);

                        $dialogContainer = $(root.popupId);
                        $detachedChildren = $dialogContainer.children().detach();
                        
                        $(root.popupId).dialog("open");
                        fixTableHeader(root.popupId, '#chooseCustomer');
                        setHeightPopupContent(root.popupId);
                        setHeightTableContent(root.popupId, '#chooseCustomer');
                    } else {
                        $(root.popupId).dialog('close');
                    }
                });
            } else {
                $(root.popupId).dialog('close');
            }
        });
    };

    function bindEvent() {
        if ($(root.popupId + ' #useInputCustomer').is(':checked')) {
            $(root.popupId + ' #customerInfo table *').prop("disabled", false);
            $(root.popupId + ' #customerInfo table').removeClass('icon-disable');

            $(root.popupId + ' .popup-content *').prop("disabled", true);
            $(root.popupId + ' .popup-content').addClass('icon-disable');

            $(root.popupId + ' span[id^="customer-"]').unbind('click');
            $(root.popupId + ' #customer-table tr').unbind('dblclick');
        } else {
            $(root.popupId + ' #customerInfo table *').prop("disabled", true);
            $(root.popupId + ' #customerInfo table').addClass('icon-disable');

            $(root.popupId + ' .popup-content *').prop("disabled", false);
            $(root.popupId + ' .popup-content').removeClass('icon-disable');
            
            $(root.popupId + ' span[id^="customer-"]').unbind('click');
            $(root.popupId + ' span[id^="customer-"]').click(function (e) {
                root.select(e);
                return false;
            });

            $(root.popupId + ' #customer-table tr').unbind('dblclick');
            $(root.popupId + ' #customer-table tr').dblclick(function (e) {
                $(e.currentTarget).find('span[id^="customer-"]').trigger('click');
            });
        }
    }
    
    this.select = function (e) {
        $(root.popupId).dialog('close');
        var customerId = e.currentTarget.id.split('-')[1];

        if (root.functionCallback)
            root.functionCallback(root.orderId, customerId, '', '', '', '');
    };
}