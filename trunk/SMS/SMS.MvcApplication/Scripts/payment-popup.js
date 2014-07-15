function PaymentPopup(id, height, getDataUrl, getDataForPostCallback, templateId, getUrlForCallback, refreshCallback, useServiceFee, useTax) {
    var root = this;
    this.id = id;
    this.height = height;
    this.getDataUrl = getDataUrl;
    this.getDataForPostCallback = getDataForPostCallback;
    this.templateId = templateId;
    this.getUrlForCallback = getUrlForCallback;
    this.refreshCallback = refreshCallback;
    this.useServiceFee = useServiceFee;
    this.useTax = useTax;
    this.Data = null;

    $('#' + root.id).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: "100%",
        height: root.height,
        modal: true,
        close: refreshCallback
    });

    $('#' + root.id + ' #print').button({
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
    
    $('#' + root.id + ' #payment').button({
        icons: {
            primary: "ui-icon-check"
        }
    }).click(function () {
        payment();
    });
    
    $('#' + root.id + ' #print-VAT').button({
        icons: {
            primary: "ui-icon-print"
        }
    }).click(function () {
        
    });

    this.OpenPopup = function () {
        renderData();
        var popupId = '#' + root.id;
        $(popupId).dialog("open");
        
        $('#' + root.id + ' #popupchkUseServiceFee').show();
        $('#' + root.id + ' input[id^="popupChkUseTax-"]').show();
        $('#' + root.id + ' #payment').removeClass('RmenuDisable');
        $('#' + root.id + ' #payment').prop("disabled", false);
        $('#' + root.id + ' #btnTaxInvoice').hide();
        $('#' + root.id + ' #taxInvoice').hide();

        var parentHeight = $(popupId).height();
        $(popupId + ' .payment-content').height(parentHeight);
    };
    
    function renderData() {
        var postData = getDataForPostCallback();
        $.ajax({
            type: 'POST',
            url: root.getDataUrl,
            data: postData
        }).done(function (result) {
            if (!result.Success)
                return;

            root.Data = result.Data;
            
            $('#lblSubTotal').text(root.Data.SubTotal.formatAsMoney());
            $('#' + root.id + ' #popupchkUseServiceFee').prop('checked', root.useServiceFee);
            $('#' + root.id + ' input[id^="popupChkUseTax-"]').each(function (idx, e) {
                $(e).prop('checked', root.useTax[idx]);
            });

            processData();
        });
    }

    $('#' + root.id + ' #btnTaxInvoice').click(function () {
        $('#' + root.id + ' #taxInvoice').toggle(300);
    });
    
    $('#' + root.id + ' #popupchkUseServiceFee').click(function () {
        if ($(this).is(':checked')) {
            $('#' + root.id + ' #ServiceFree').removeClass('RmenuDisable');
        } else {
            $('#' + root.id + ' #ServiceFree').addClass('RmenuDisable');
        }
        processData();
    });
    
    $('#' + root.id + ' input[id^="popupChkUseTax-"]').click(function () {
        var type = $(this).attr('id').split('-')[1];
        if ($(this).is(':checked')) {
            $('#' + root.id + ' #tax-' + type).removeClass('RmenuDisable');
        } else {
            $('#' + root.id + ' #tax-' + type).addClass('RmenuDisable');
        }
        processData();
    });

    function processData() {
        var serviceFee = 0;
        if ($('#' + root.id + ' #popupchkUseServiceFee').length > 0
                && $('#' + root.id + ' #popupchkUseServiceFee').is(':checked')) {

            $('#' + root.id + ' #ServiceFree').removeClass('RmenuDisable');
            serviceFee = $('#' + root.id + ' .payment-config tr[id="ServiceFree"] .fee').text().readMoneyAsNumber();
            $('#' + root.id + ' .payment-config tr[id="ServiceFree"] .fee').text(serviceFee.formatAsMoney());
        } else {
            $('#' + root.id + ' #ServiceFree').addClass('RmenuDisable');
        }

        root.Data.ServiceFee = serviceFee;
        root.Data.SumAmount = root.Data.SubTotal + root.Data.OtherFee + serviceFee;

        var tax = 0;
        $('#' + root.id + ' .payment-config table tr[id^="tax-"]').each(function (idx, element) {
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
        $('#' + root.id + ' #lblTotalAmount').text(root.Data.TotalAmount.formatAsMoney());
        $('#' + root.id + ' #txtcash').val(root.Data.TotalAmount.formatAsMoney());

        $('#' + root.id + ' .page').html($('#' + root.templateId).tmpl(root.Data).scanLabel());
    }
    
    function payment() {
        var popup = new MessagePopup('Thông báo',
            'Bàn đã sẵn sàng để thanh toán.<br />Thanh toán ngay?',
            3,
            function() {
                var postData = getDataForPostCallback();
                $.ajax({
                    type: 'POST',
                    url: root.getUrlForCallback,
                    data: postData
                }).done(function(result) {
                    if (!result.Success) {
                        popup = new MessagePopup('Thông báo',
                            'Có lỗi xảy ra trong quá trình thực thi.<br />Xin vui lòng thử lại sau.',
                            4,
                            function() {
                            });

                        popup.OpenPopup();
                    } else {
                        $('#' + root.id + ' #popupchkUseServiceFee').hide();
                        $('#' + root.id + ' input[id^="popupChkUseTax-"]').hide();
                        $('#' + root.id + ' #payment').addClass('RmenuDisable');
                        $('#' + root.id + ' #payment').prop("disabled", true);
                        $('#' + root.id + ' #btnTaxInvoice').show();
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