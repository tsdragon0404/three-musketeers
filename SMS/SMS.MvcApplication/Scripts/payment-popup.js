﻿function PaymentPopup(id, height, getDataUrl, orderId, templateId, templateVatId, getUrlForCallback, refreshCallback, useServiceFee, useTax) {
    var root = this;
    this.id = id;
    this.height = height;
    this.getDataUrl = getDataUrl;
    this.orderId = orderId;
    this.templateId = templateId;
    this.templateVatId = templateVatId;
    this.getUrlForCallback = getUrlForCallback;
    this.refreshCallback = refreshCallback;
    this.useServiceFee = useServiceFee;
    this.useTax = useTax;
    this.popupId = '#' + id;
    this.Data = null;

    $(root.popupId).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: "100%",
        height: root.height,
        modal: true,
        close: refreshCallback
    });

    $(root.popupId + ' #print').unbind('click');
    $(root.popupId + ' #print').button({
        icons: {
            primary: "ui-icon-print"
        }
    }).click(function() {
        if (MeadCo.ScriptX.Init()) {
            MeadCo.ScriptX.Printing.header = "";
            MeadCo.ScriptX.Printing.footer = "";
            MeadCo.ScriptX.PreviewPage();
        } else {
            window.print();
        }

        return false;
    });
    
    $(root.popupId + ' #payment').unbind('click');
    $(root.popupId + ' #payment').button({
        icons: {
            primary: "ui-icon-check"
        }
    }).click(function () {
        payment();
    });

    this.OpenPopup = function () {
        renderData();
        $(root.popupId).dialog("open");
        
        $(root.popupId + ' #popupchkUseServiceFee').show();
        $(root.popupId + ' input[id^="popupChkUseTax-"]').show();
        $(root.popupId + ' #payment').prop("disabled", false);
        $(root.popupId + ' #payment').removeClass('RmenuDisable');
        $(root.popupId + ' #btnTaxInvoice').hide();
        $(root.popupId + ' #taxInvoice').hide();

        var parentHeight = $(root.popupId).height();
        $(root.popupId + ' .payment-content').height(parentHeight);
    };
    
    function renderData() {
        var postData = { orderID: root.orderId };
        $.ajax({
            type: 'POST',
            url: root.getDataUrl,
            data: postData
        }).done(function (result) {
            if (!result.Success)
                return;

            root.Data = result.Data;
            
            $('#lblSubTotal').text(root.Data.SubTotal.formatAsMoney());
            $(root.popupId + ' #popupchkUseServiceFee').prop('checked', root.useServiceFee);
            $(root.popupId + ' input[id^="popupChkUseTax-"]').each(function (idx, e) {
                $(e).prop('checked', root.useTax[idx]);
            });

            processData();
        });
    }

    $(root.popupId + ' #btnTaxInvoice').unbind('click');
    $(root.popupId + ' #btnTaxInvoice').click(function () {
        if ($(this).is(':checked')) {
            $(root.popupId + ' #taxInvoice').show();
            $(root.popupId + ' .page').html($('#' + root.templateVatId).tmpl(root.Data).scanLabel());
        } else {
            $(root.popupId + ' #taxInvoice').hide();
            $(root.popupId + ' .page').html($('#' + root.templateId).tmpl(root.Data).scanLabel());
        }
    });
    
    $(root.popupId + ' #popupchkUseServiceFee').unbind('click');
    $(root.popupId + ' #popupchkUseServiceFee').click(function () {
        if ($(this).is(':checked')) {
            $(root.popupId + ' #ServiceFree').removeClass('RmenuDisable');
        } else {
            $(root.popupId + ' #ServiceFree').addClass('RmenuDisable');
        }
        processData();
    });
    
    $(root.popupId + ' input[id^="popupChkUseTax-"]').unbind('click');
    $(root.popupId + ' input[id^="popupChkUseTax-"]').click(function () {
        var type = $(this).attr('id').split('-')[1];
        if ($(this).is(':checked')) {
            $(root.popupId + ' #tax-' + type).removeClass('RmenuDisable');
        } else {
            $(root.popupId + ' #tax-' + type).addClass('RmenuDisable');
        }
        processData();
    });

    function processData() {
        var serviceFee = 0;
        if ($(root.popupId + ' #popupchkUseServiceFee').length > 0
                && $(root.popupId + ' #popupchkUseServiceFee').is(':checked')) {

            $(root.popupId + ' #ServiceFree').removeClass('RmenuDisable');
            serviceFee = $(root.popupId + ' .payment-config tr[id="ServiceFree"] .fee').text().readMoneyAsNumber();
            $(root.popupId + ' .payment-config tr[id="ServiceFree"] .fee').text(serviceFee.formatAsMoney());
        } else {
            $(root.popupId + ' #ServiceFree').addClass('RmenuDisable');
        }

        root.Data.ServiceFee = serviceFee;
        root.Data.SumAmount = root.Data.SubTotal + root.Data.OtherFee + serviceFee;

        var tax = 0;
        $(root.popupId + ' .payment-config table tr[id^="tax-"]').each(function (idx, element) {
            if ($(element).find('input[id^="popupChkUseTax-"]').is(':checked')) {
                $(element).removeClass('RmenuDisable');
                var value = $(element).find('span[id^="tax-value-"]').text();
                tax += root.Data.SumAmount > 0 ? root.Data.SumAmount * value / 100 : 0;
                $(element).find('span[id^="tax-amount-"]').text((root.Data.SumAmount * value / 100).formatAsMoney());
            } else {
                $(element).addClass('RmenuDisable');
                $(element).find('span[id^="tax-amount-"]').text('0');
            }
        });
        root.Data.Tax = tax;
        root.Data.TotalAmount = root.Data.SumAmount + tax;
        $(root.popupId + ' #lblTotalAmount').text(root.Data.TotalAmount.formatAsMoney());
        $(root.popupId + ' #txtcash').val(root.Data.TotalAmount.formatAsMoney());

        $(root.popupId + ' .page').html($('#' + root.templateId).tmpl(root.Data).scanLabel());
    }
    
    function payment() {
        var popup = new MessagePopup('Thông báo',
            'Bàn đã sẵn sàng để thanh toán.<br />Thanh toán ngay?',
            3,
            function() {
                $.ajax({
                    type: 'POST',
                    url: root.getUrlForCallback,
                    data: { orderID: root.orderId, tax: root.Data.Tax, serviceFee: root.Data.ServiceFee }
                }).done(function(result) {
                    if (!result.Success) {
                        popup = new MessagePopup('Thông báo',
                            'Có lỗi xảy ra trong quá trình thực thi.<br />Xin vui lòng thử lại sau.',
                            4,
                            function() {
                            });

                        popup.OpenPopup();
                    } else {
                        $(root.popupId + ' #popupchkUseServiceFee').hide();
                        $(root.popupId + ' input[id^="popupChkUseTax-"]').hide();
                        $(root.popupId + ' #payment').addClass('RmenuDisable');
                        $(root.popupId + ' #payment').prop("disabled", true);
                        $(root.popupId + ' #btnTaxInvoice').show();
                        if (MeadCo.ScriptX.Init()) {
                            MeadCo.ScriptX.Printing.header = "";
                            MeadCo.ScriptX.Printing.footer = "";
                            MeadCo.ScriptX.PrintPage();
                        } else {
                            window.print();
                        }
                    }
                });
            });

        popup.OpenPopup();
    }
}