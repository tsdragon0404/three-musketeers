var globalTimer;
$(document).ready(function () {
    var leftmenu = $('#leftmenu');
    if (leftmenu.length != 0) {
        $('#leftmenuExpander').css("left", leftmenu.outerWidth() + "px");
        $('#expander').click(ExpandColapseMenu);
    }
    
    var body = $('#body');
    if (body.length != 0) {
        SetHeightBodySection();
        $(window).resize(SetHeightBodySection);

        globalTimer = setInterval(GlobalTimerExecute, 250);
    }
});

function ExpandColapseMenu() {
    var link = $('#expander');
    if (link.hasClass('expanded')) {
        $('#leftmenu').css("width", "0").toggle(500);
        $('#leftmenuExpander').css("left", "0");

        $('#body').css("width", "99%");
        
        link.removeClass('expanded');
        link.addClass('colapsed');
    }
    else {
        $('#leftmenu').css("width", "13%").toggle(500);
        $('#leftmenuExpander').css("left", "13%");

        $('#body').css("width", "86%");
        link.removeClass('colapsed');
        link.addClass('expanded');
    }
    return false;
}

function SetHeightBodySection() {
    var windowHeight = $(window).height();
    var headerHeight = $('#header').outerHeight(true);
    var footerHeight = $('#footer').outerHeight(true);
    var menuHeight = $('#tabs-menu').outerHeight(true);

    $('#body #content').height(windowHeight - headerHeight - footerHeight - menuHeight);
    $('#leftmenu').height(windowHeight - headerHeight - footerHeight);
    
    // set position for expander
    $('#leftmenuExpander').css("left", $('#leftmenu').outerWidth() + "px");
}

function GlobalTimerExecute() {
    if ($('#area-table').length != 0) {
        SetHeightCashierContent();
    }
}

function SetHeightCashierContent() {
    var outerDivHeight = $('#area-table').height();
    var siblingsHeight = $('#areas').outerHeight(true);
    $('#tables').height(outerDivHeight - siblingsHeight);
    
    outerDivHeight = $('#tableorder').height();
    siblingsHeight = $('#order-header').outerHeight(true);
    $('#order-detail').height(outerDivHeight - siblingsHeight);
}

function setHeightPopupContent(popupId) {
    var parentHeight = $(popupId).height();
    var siblings = $(popupId + ' > *:not(.popup-content)');
    var siblingsHeight = 0;
    siblings.each(function (idx, element) {
        siblingsHeight += $(element).outerHeight(true);
    });

    $(popupId + ' > .popup-content').height(parentHeight - siblingsHeight);
}

function setHeightTableContent(popupId, tableId) {
    var contentHeight = $(popupId + ' .popup-content').height();
    var height1 = 0;
    $(tableId + '_wrapper > .ui-widget-header').each(function (idx, element) {
        height1 += $(element).outerHeight();
    });

    var height2 = $(tableId + '_wrapper > .dataTables_scroll > .dataTables_scrollHead').outerHeight();

    var targetHeight = contentHeight - height1 - height2 - 7; // subtract 2 more px due to the border and padding bottom
    $(tableId + '_wrapper > .dataTables_scroll > .dataTables_scrollBody').css('height', targetHeight + 'px');
}

function fixTableHeader(popupId, tableId) {
    $(popupId + ' .dataTables_scrollHeadInner, ' + popupId + ' .dataTables_scrollHeadInner > table').css('width', '').css('padding-left', '');

    var headerColumns = $(popupId + ' .dataTables_scrollHead table > thead > tr:first-child th');
    var columns = $(popupId + ' ' + tableId + ' > tbody > tr:first-child td');

    for (var i = 0; i < columns.length; i++) {
        $(headerColumns[i]).css('width', $(columns[i]).width());
    }

    // calculate vertical scroll
    var widthHeader = $(popupId + ' .dataTables_scrollHead').outerWidth();
    var widthContent = $(popupId + ' ' + tableId).outerWidth();
    $(popupId + ' .dataTables_scrollHeadInner').css('padding-right', (widthHeader - widthContent) + 'px');
}

function applyColumnFilterForDataTable(popupId, table, columns) {
    $(popupId + ' .dataTables_scrollHead table thead').append('<tr role="row" class="datatable_filter"></tr>');

    $(popupId + ' .dataTables_scrollHead table thead th').each(function (idx) {
        if ($.inArray(idx, columns) >= 0) {
            $(popupId + ' .dataTables_scrollHead table thead .datatable_filter')
                .append('<th class="ui-state-default" style="padding: 1px; border-bottom: 0; border-top: 0"><input type="text" /></th>');
        } else {
            $(popupId + ' .dataTables_scrollHead table thead .datatable_filter')
                .append('<th class="ui-state-default" style="padding: 1px; border-bottom: 0; border-top: 0"></th>');
        }
    });

    // Apply the search
    $(popupId + " .datatable_filter input").keyup(function (e) {
        var code = e.keyCode || e.which;
        if (code != '9') {
            var that = this;
            setTimeout(function () {
                var idx = $(popupId + " .datatable_filter input").index(that);
                table
                    .column(idx)
                    .search(that.value)
                    .draw();
            }, 100);
        }
    });
}

function pad(s) { return (s < 10) ? '0' + s : s; }

String.prototype.formatAsDateTime = function () {
    if (this == '' || this == null)
        return '';
    var d = new Date(this);
    return [pad(d.getMonth() + 1), pad(d.getDate()), d.getFullYear()].join('/') + ' ' + [pad(d.getHours()), pad(d.getMinutes() + 1), pad(d.getSeconds() + 1)].join(':');
};

String.prototype.formatAsDate = function () {
    if (this == '' || this == null)
        return '';
    var d = new Date(this);
    return [pad(d.getMonth() + 1), pad(d.getDate()), d.getFullYear()].join('/');
};

Number.prototype.formatAsMoney = function () {
    if (!isNaN(parseFloat(this)))
        return parseFloat(this).toLocaleString('en');
    return 0;
};
String.prototype.formatAsMoney = function () {
    if (!isNaN(parseFloat(this)))
        return parseFloat(this).toLocaleString('en');
    return '';
};

String.prototype.readMoneyAsNumber = function() {
    var str = this;
    if (this.indexOf(',') >= 0) {
        str = str.replace(/,/g, '');
    }
    if (this.indexOf('-') >= 0) {
        str = str.replace(/-/g, '');
    }

    return parseFloat(str);
};

$.fn.table = function () {
    this.addClass('no-border');
    if (this.hasClass('popup-table-header')) {
        if (!this.parent().hasClass('ui-widget-header'))
            this.wrap('<div class="ui-widget-header"></div>');
    }
    else{    
        this.find('thead tr').addClass('ui-widget-header');
        this.find('tbody tr, tfoot tr').addClass('ui-helper-reset ui-state-default');
    }
};