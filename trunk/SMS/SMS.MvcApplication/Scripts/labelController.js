function LabelController(labelDictionary) {
    var root = this;
    this.labelDictionary = labelDictionary;

    this.Run = function() {
        if (labelDictionary == null)
            return;
        scanElements();
    };
    
    function scanElements() {
        var elements = $('span.label label.label');
        elements.each(function(idx, element) {
            var id = element.id;
            if (root.labelDictionary[id] != undefined) {
                $(element).text(root.labelDictionary[id]);
            }
        });
    }
}