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

    $('#popup').dialog({
        autoOpen: false,
        closeOnEscape: false,
        resizable: false,
        width: 500,
        modal: true
    });

    // cannot use this method because the title can be unicode string
    //$('#popup').dialog('option', 'title', unescape(root.title));
    $('#popup').siblings('.ui-dialog-titlebar').find('.ui-dialog-title').html(root.title);
    $('#popup-message').html(root.message);

    //unbind click event for buttons
    $('#popup-button input[type="button"]').unbind('click');

    $('#popup-icon').removeClass('info-icon');
    $('#popup-icon').removeClass('confirm-icon');
    $('#popup-icon').removeClass('warning-icon');
    $('#popup-icon').removeClass('error-icon');
    
    if (popupType == 1) {
        $('#popup-icon').addClass('info-icon');
        $('#popup-button').html(root.okButton);
        $('#popup-button .okButton').button({
            icons: {
                primary: "ui-icon-check"
            }
        }).click(function () {
            $('#popup').dialog('close');
            if (root.firstButtonCallback)
                firstButtonCallback();
            return false;
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
        $('#popup-button').html(root.okButton);
        $('#popup-button .okButton').button({
            icons: {
                primary: "ui-icon-check"
            }
        }).click(function () {
            $('#popup').dialog('close');
            if (root.firstButtonCallback)
                firstButtonCallback();
            return false;
        });
    }

    this.OpenPopup = function () {
        $('#popup').dialog("open");
    };
}