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

        $('#' + root.addButtonId).button().click(function() {
            $('#' + root.originalListBoxId + ' > option:selected').each(function() {
                $(this).remove().appendTo('#' + root.assignedListBoxId);
            });
        });

        $('#' + root.removeButtonId).button().click(function () {
            $('#' + root.assignedListBoxId + ' > option:selected').each(function() {
                $(this).remove().appendTo('#' + root.originalListBoxId);
            });
        });

        $('#' + root.addAllButtonId).button().click(function () {
            $('#' + root.originalListBoxId + ' > option').each(function() {
                $(this).remove().appendTo('#' + root.assignedListBoxId);
            });
        });

        $('#' + root.removeAllButtonId).button().click(function () {
            $('#' + root.assignedListBoxId + ' > option').each(function() {
                $(this).remove().appendTo('#' + root.originalListBoxId);
            });
        });
    };
}
