function PaymentPopup(id, height, getDataUrl, getDataForPostCallback, templateId, getUrlForCallback, useServiceFee, useTax) {
    var root = this;
    this.id = id;
    this.height = height;
    this.getDataUrl = getDataUrl;
    this.getDataForPostCallback = getDataForPostCallback;
    this.templateId = templateId;
    this.getUrlForCallback = getUrlForCallback;
    this.useServiceFee = useServiceFee;
    this.useTax = useTax;
    this.Data = null;

    $('#' + root.id).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: "100%",
        height: root.height,
        modal: true
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

    this.OpenPopup = function () {
        renderData();
        var popupId = '#' + root.id;
        $(popupId).dialog("open");
        
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

            $('#lblSumlAmount').text(root.Data.SumAmount.formatAsMoney());
            $('#' + root.id + ' #popupchkUseServiceFee').prop('checked', root.useServiceFee);
            $('#' + root.id + ' input[id^="popupChkUseTax-"]').each(function (idx, e) {
                $(e).prop('checked', root.useTax[idx]);
            });

            var serviceFee = 0;
            if ($('#' + root.id + ' #popupchkUseServiceFee').length > 0
                    && $('#' + root.id + ' #popupchkUseServiceFee').is(':checked')) {
                serviceFee = $('#' + root.id + ' .payment-config tr[id="ServiceFree"] .fee').text().readMoneyAsNumber();
            }
            root.Data.ServiceFee = serviceFee;
            root.Data.SumAmount += serviceFee;

            var tax = 0;
            $('#' + root.id + ' .payment-config table tr[id^="tax-"]').each(function (idx, element) {
                if ($(element).find('input[id^="popupChkUseTax-"]').is(':checked')) {
                    var value = $(element).find('span[id^="tax-value-"]').text();
                    tax += root.Data.SumAmount > 0 ? root.Data.SumAmount * value / 100 : 0;
                    $(element).find('span[id^="tax-amount-"]').text((root.Data.SumAmount * value / 100).formatAsMoney());
                } else {
                    $(element).find('span[id^="tax-amount-"]').text('0');
                }
            });

            $('#' + root.id + ' .page').html($('#' + root.templateId).tmpl(root.Data).scanLabel());
        });
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
    
    //$.fn.Calculation = function () {
    //    var serviceFee = 0;
    //    if ($('#' + root.id + ' #popupchkUseServiceFee').length > 0
    //            && $('#' + root.id + ' #popupchkUseServiceFee').is(':checked')) {
    //        serviceFee = $('#' + root.id + ' .payment-config tr[id="ServiceFree"] .fee').text().readMoneyAsNumber();
    //    }
    //    this.ServiceFee = serviceFee;
    //    return this;
    //};
}