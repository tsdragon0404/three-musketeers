function MessagePopup(title, message, popupType, firstButtonCallback, secondButtonCallback) {
    var root = this;
    this.title = title;
    this.message = message;
    this.popupType = popupType;
    this.firstButtonCallback = firstButtonCallback;
    this.secondButtonCallback = secondButtonCallback;

    this.okButton = '<input type="button" class="button okButton" value="Ok" />';
    this.cancelButton = '<input type="button" class="button cancelButton" value="Cancel" />';
    this.yesButton = '<input type="button" class="button yesButton" value="Yes" />';
    this.noButton = '<input type="button" class="button noButton" value="No" />';

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
        $('#popup-button .okButton').button().click(function () {
            $('#popup').dialog('close');
            if (root.firstButtonCallback)
                firstButtonCallback();
        });
    }
    else if (popupType == 2) {
        $('#popup-icon').html(root.questionIcon);
        $('#popup-button').html(root.okButton + root.cancelButton);
        $('#popup-button .okButton').button().click(function () {
            $('#popup').dialog('close');
            if (root.firstButtonCallback)
                root.firstButtonCallback();
        });
        $('#popup-button .cancelButton').button().click(function () {
            $('#popup').dialog('close');
            if (root.secondButtonCallback)
                root.secondButtonCallback();
        });
    }
    else if (popupType == 3) {
        $('#popup-icon').html(root.questionIcon);
        $('#popup-button').html(root.yesButton + root.noButton);
        $('#popup-button .yesButton').button().click(function () {
            $('#popup').dialog('close');
            if (root.firstButtonCallback)
                root.firstButtonCallback();
        });
        $('#popup-button .noButton').button().click(function () {
            $('#popup').dialog('close');
            if (root.secondButtonCallback)
                root.secondButtonCallback();
        });
    }
    else if (popupType == 4) {
        $('#popup-icon').html(root.errorIcon);
        $('#popup-button').html(root.okButton);
        $('#popup-button .okButton').button().click(function () {
            $('#popup').dialog('close');
            if (root.firstButtonCallback)
                firstButtonCallback();
        });
    }

    this.OpenPopup = function () {
        $('#popup').dialog("open");
    };
}