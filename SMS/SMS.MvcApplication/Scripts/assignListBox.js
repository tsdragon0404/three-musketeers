function AssignListBox(originalListBoxId, assignedListBoxId, addButtonId, removeButtonId, addAllButtonId, removeAllButtonId) {
    var root = this;

    this.originalListBoxId = originalListBoxId;
    this.assignedListBoxId = assignedListBoxId;
    this.addButtonId = addButtonId;
    this.addAllButtonId = addAllButtonId;
    this.removeButtonId = removeButtonId;
    this.removeAllButtonId = removeAllButtonId;

    this.bindEvents = function () {
        $('#' + root.assignedListBoxId + ' > option').each(function () {
            var id = $(this).val();
            $('#' + root.originalListBoxId + ' > option[value="' + id + '"]').remove();
        });

        $('#' + root.originalListBoxId).dblclick(function () {
            $('#' + root.originalListBoxId + ' > option:selected').each(function () {
                $(this).remove().appendTo('#' + root.assignedListBoxId);
            });
        });
        
        $('#' + root.assignedListBoxId).dblclick(function () {
            $('#' + root.assignedListBoxId + ' > option:selected').each(function () {
                $(this).remove().appendTo('#' + root.originalListBoxId);
            });
        });

        $('#' + root.addButtonId).button({
            icons: {
                primary: "ui-icon-carat-1-e"
            },
            text: false
        }).click(function () {
            $('#' + root.originalListBoxId + ' > option:selected').each(function() {
                $(this).remove().appendTo('#' + root.assignedListBoxId);
            });
        });

        $('#' + root.removeButtonId).button({
            icons: {
                primary: "ui-icon-carat-1-w"
            },
            text: false
        }).click(function () {
            $('#' + root.assignedListBoxId + ' > option:selected').each(function() {
                $(this).remove().appendTo('#' + root.originalListBoxId);
            });
        });

        $('#' + root.addAllButtonId).button({
            icons: {
                primary: "ui-icon-seek-next"
            },
            text: false
        }).click(function () {
            $('#' + root.originalListBoxId + ' > option').each(function() {
                $(this).remove().appendTo('#' + root.assignedListBoxId);
            });
        });

        $('#' + root.removeAllButtonId).button({
            icons: {
                primary: "ui-icon-seek-prev"
            },
            text: false
        }).click(function () {
            $('#' + root.assignedListBoxId + ' > option').each(function() {
                $(this).remove().appendTo('#' + root.originalListBoxId);
            });
        });
    };
}
