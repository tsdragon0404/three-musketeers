function MessagePopup(title, message, popupType, firstButtonCallback, secondButtonCallback) {
    var root = this;
    this.title = title;
    this.message = message;
    this.popupType = popupType;
    this.firstButtonCallback = firstButtonCallback;
    this.secondButtonCallback = secondButtonCallback;

    this.okButton = '<button class="okButton">Ok</button>';
    this.cancelButton = '<button class="cancelButton">Cancel</button>';//'<input type="button" class="cancelButton" value="Cancel" />';
    this.yesButton = '<button class="yesButton">Yes</button>';//'<input type="button" class="yesButton" value="Yes" />';
    this.noButton = '<button class="noButton">No</button>';//'<input type="button" class="noButton" value="No" />';

    var imgTmpl = '<img src="' + location.pathname + '/../Images/IconControls/{0}" alt="icon"/>';
    this.infoIcon = imgTmpl.replace('{0}', 'info-icon.png');
    this.questionIcon = imgTmpl.replace('{0}', 'confirm-icon.png');
    this.warningIcon = imgTmpl.replace('{0}', 'warning-icon.png'); 
    this.errorIcon = imgTmpl.replace('{0}', 'error-icon.png');

    $('#popup').dialog({
        autoOpen: false,
        closeOnEscape: false,
        resizable: false,
        width: 500,
        modal: true
    });

    $('#popup').dialog('option', 'title', root.title);
    $('#popup-message').html(root.message);

    //unbind click event for buttons
    $('#popup-button input[type="button"]').unbind('click');
    
    if (popupType == 1) {
        $('#popup-icon').html(root.infoIcon);
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
        $('#popup-icon').html(root.questionIcon);
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
        $('#popup-icon').html(root.questionIcon);
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
        $('#popup-icon').html(root.errorIcon);
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