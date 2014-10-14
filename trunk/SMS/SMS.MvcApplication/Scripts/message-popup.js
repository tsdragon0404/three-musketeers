function MessagePopup(title, message, popupType, firstButtonCallback, secondButtonCallback) {
    var root = this;
    this.title = title;
    this.message = message;
    this.popupType = popupType;
    this.firstButtonCallback = firstButtonCallback;
    this.secondButtonCallback = secondButtonCallback;

    this.okButton = '<button class="okButton">Ok</button>';
    this.cancelButton = '<button class="cancelButton">Cancel</button>';
    this.yesButton = '<button class="yesButton">Yes</button>';
    this.noButton = '<button class="noButton">No</button>';

    var timer;

    $('#popup').dialog({
        autoOpen: false,
        closeOnEscape: false,
        resizable: false,
        width: 500,
        modal: true,
        position: { my: "center", at: "center", of: window },
        show: null,
        hide: null
    });

    // cannot use this method because the title can be unicode string
    //$('#popup').dialog('option', 'title', unescape(root.title));
    $('#popup').siblings('.ui-dialog-titlebar').find('.ui-dialog-title').html(root.title);
    if (root.message.length <= 1000)
        $('#popup-message').html(root.message);
    else {
        $('#popup-message').html('Somethings wrong.</br><a class="showMessageDetail">Click here</a> read more detail.');

        $('.showMessageDetail').click(function(event) {
            var strWindowFeatures = ["width=800, height=800, scrollbars=yes, resizable=yes"];
            var windowCustom = window.open("", root.title, strWindowFeatures);
            $(windowCustom.document.body).html(root.message);

            event.preventDefault();
        });
    }

    //unbind click event for buttons
    $('#popup-button input[type="button"]').unbind('click');

    $('#popup-icon').removeClass('info-icon');
    $('#popup-icon').removeClass('confirm-icon');
    $('#popup-icon').removeClass('warning-icon');
    $('#popup-icon').removeClass('error-icon');
    $('#popup-message').removeClass('red');
    
    if (popupType == 1) {
        $('#popup-icon').addClass('info-icon');
        $('#popup-button').html('');
        $('#popup').dialog({
            width: 300,
            show: {
                effect: "clip",
                duration: 2000
            },
            hide: {
                effect: "clip",
                duration: 2000
            },
            position: {
                my: "right bottom",
                at: "right bottom",
                of: window
            }
        });
        
        timer = setTimeout(
            function () {
                $('#popup').dialog('close');
                if (root.firstButtonCallback)
                    root.firstButtonCallback();
            }, 2000);

        $('#popup').mouseover(function () {
            clearTimeout(timer);
        }).mouseout(function () {
            timer = setTimeout(
                function () {
                    $('#popup').dialog('close');
                    if (root.firstButtonCallback)
                        root.firstButtonCallback();
                }, 1000);
        });
    }
    else if (popupType == 2) {
        $('#popup-icon').addClass('confirm-icon');
        $('#popup-button').html(root.okButton + root.cancelButton);
        $('#popup-button .okButton').button({
            icons: {
                primary: "ui-icon-check"
            }
        }).click(function () {
            $('#popup').dialog('close');
            if (root.firstButtonCallback)
                root.firstButtonCallback();
            return false;
        });
        $('#popup-button .cancelButton').button({
            icons: {
                primary: "ui-icon-close"
            }
        }).click(function () {
            $('#popup').dialog('close');
            if (root.secondButtonCallback)
                root.secondButtonCallback();
            return false;
        });
    }
    else if (popupType == 3) {
        $('#popup-icon').addClass('confirm-icon');
        $('#popup-button').html(root.yesButton + root.noButton);
        $('#popup-button .yesButton').button({
            icons: {
                primary: "ui-icon-check"
            }
        }).click(function () {
            $('#popup').dialog('close');
            if (root.firstButtonCallback)
                root.firstButtonCallback();
            return false;
        });
        $('#popup-button .noButton').button({
            icons: {
                primary: "ui-icon-close"
            }
        }).click(function () {
            $('#popup').dialog('close');
            if (root.secondButtonCallback)
                root.secondButtonCallback();
            return false;
        });
    }
    else if (popupType == 4) {
        $('#popup-icon').addClass('error-icon');
        $('#popup-button').html('');
        $('#popup-message').addClass('red');
        
        $('#popup').dialog({
            width: 300,
            show: {
                effect: "clip",
                duration: 1000
            },
            hide: {
                effect: "clip",
                duration: 1000
            },
            position: {
                my: "right bottom",
                at: "right bottom",
                of: window
            }
        });

        timer = setTimeout(
            function() {
                $('#popup').dialog('close');
                if (root.firstButtonCallback)
                    root.firstButtonCallback();
            }, 2000);

        $('#popup').mouseover(function() {
            clearTimeout(timer);
        }).mouseout(function () {
            timer = setTimeout(
                function () {
                    $('#popup').dialog('close');
                    if (root.firstButtonCallback)
                        root.firstButtonCallback();
                }, 1000);
        });
    }

    this.OpenPopup = function () {
        $('#popup').dialog("open");
    };
}