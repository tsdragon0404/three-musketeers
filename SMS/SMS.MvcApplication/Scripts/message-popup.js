function MessagePopup(title, message, popupType, firstButtonCallback, secondButtonCallback) {
    var root = this;
    this.title = title;
    this.message = message;
    this.popupType = popupType;
    this.firstButtonCallback = firstButtonCallback;
    this.secondButtonCallback = secondButtonCallback;

    this.okButton = '<input type="button" class="button myButton okButton" value="Ok" />';
    this.cancelButton = '<input type="button" class="button myButton cancelButton" value="Cancel" />';
    this.yesButton = '<input type="button" class="button myButton yesButton" value="Yes" />';
    this.noButton = '<input type="button" class="button myButton noButton" value="No" />';
    this.infoIcon = '<img src="../Images/IconControls/info-icon.png" alt="icon"/>';
    this.questionIcon = '<img src="../Images/IconControls/confirm-icon.png" alt="icon"/>';
    this.warningIcon = '<img src="../Images/IconControls/warning-icon.png" alt="icon"/>';
    this.errorIcon = '<img src="../Images/IconControls/error-icon.png" alt="icon"/>';

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
    $('#popup .button').unbind('click');
    
    if (popupType == 1) {
        $('#popup-icon').html(root.infoIcon);
        $('#popup-button').html(root.okButton);
        $('#popup-button .okButton').click(function() {
            $('#popup').dialog('close');
            if (root.firstButtonCallback)
                firstButtonCallback();
        });
    }
    else if (popupType == 2) {
        $('#popup-icon').html(root.questionIcon);
        $('#popup-button').html(root.okButton + root.cancelButton);
        $('#popup-button .okButton').click(function () {
            $('#popup').dialog('close');
            if (root.firstButtonCallback)
                root.firstButtonCallback();
        });
        $('#popup-button .cancelButton').click(function () {
            $('#popup').dialog('close');
            if (root.secondButtonCallback)
                root.secondButtonCallback();
        });
    }
    else if (popupType == 3) {
        $('#popup-icon').html(root.questionIcon);
        $('#popup-button').html(root.yesButton + root.noButton);
        $('#popup-button .yesButton').click(function () {
            $('#popup').dialog('close');
            if (root.firstButtonCallback)
                root.firstButtonCallback();
        });
        $('#popup-button .noButton').click(function () {
            $('#popup').dialog('close');
            if (root.secondButtonCallback)
                root.secondButtonCallback();
        });
    }

    this.OpenPopup = function () {
        $('#popup').dialog("open");
    };
}