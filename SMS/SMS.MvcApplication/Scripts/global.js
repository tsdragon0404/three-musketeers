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

        if ($('#area-table').length != 0) {
            
            globalTimer = setInterval(SetHeightCashierContent, 250);
        }
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
    var menuHeight = $('#branch-menu, #branchdata-menu').outerHeight(true);

    $('#body #content').height(windowHeight - headerHeight - footerHeight - menuHeight);
    $('#leftmenu').height(windowHeight - headerHeight - footerHeight);
    
    // set position for expander
    $('#leftmenuExpander').css("left", $('#leftmenu').outerWidth() + "px");
}

function SetHeightCashierContent() {
    var outerDivHeight = $('#area-table').height();
    var siblingsHeight = $('#areas').outerHeight(true);
    $('#tables').height(outerDivHeight - siblingsHeight);
    
    outerDivHeight = $('#tableorder').height();
    siblingsHeight = $('#order-header').outerHeight(true);
    $('#order-detail').height(outerDivHeight - siblingsHeight);
}

function SetHeightPopupContent(popupId) {
    var parentHeight = $(popupId).height();
    var siblings = $(popupId + ' > *:not(.popup-content)');
    var siblingsHeight = 0;
    siblings.each(function (idx, element) {
        siblingsHeight += $(element).outerHeight(true);
    });

    $(popupId + ' > .popup-content').height(parentHeight - siblingsHeight);
}

function pad(s) { return (s < 10) ? '0' + s : s; }

String.prototype.formatAsDateTime = function () {
    if (this == '' || this == null)
        return '';
    var d = new Date(this);
    return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('-') + ' ' + [pad(d.getHours()), pad(d.getMinutes() + 1), pad(d.getSeconds() + 1)].join(':');
};

String.prototype.formatAsDate = function () {
    if (this == '' || this == null)
        return '';
    var d = new Date(this);
    return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('-');
};

Number.prototype.formatAsMoney = function () {
    return this.toLocaleString('en');
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

$.fn.sortingTable = function (sortColumn) {
    var popupId = this.attr('id');
    this.find('.popup-table-header thead th').each(function (idx, element) {
        $(element).attr('sort-index', popupId + '-' + idx);
        if ($.inArray(idx, sortColumn) >= 0)
            $(element).addClass('sort_both');
    });
};

$(document).on("click", '.popup-table-header th.sort_both', (function () {
    var id = $(this).attr('sort-index').split('-')[0];
    var index = $(this).attr('sort-index').split('-')[1];
    removeSortIcon(id);
    $(this).removeClass('sort_both');
    $(this).addClass('sorting_asc');
    
    $('#' + id + ' .popup-content form tbody').append($('#' + id + ' .popup-content form tbody tr').Sorting(index, 'asc'));
    $('#' + id + ' .popup-content form tbody').rebuildSorting();
}));

$(document).on("click", '.popup-table-header th.sorting_asc', (function () {
    var id = $(this).attr('sort-index').split('-')[0];
    var index = $(this).attr('sort-index').split('-')[1];
    removeSortIcon(id);
    $(this).removeClass('sorting_asc');
    $(this).addClass('sorting_desc');
    $('#' + id + ' .popup-content form tbody').append($('#' + id + ' .popup-content form tbody tr').Sorting(index, 'desc'));
    $('#' + id + ' .popup-content form tbody').rebuildSorting();
}));

$(document).on("click", '.popup-table-header th.sorting_desc', (function () {
    var id = $(this).attr('sort-index').split('-')[0];
    var index = $(this).attr('sort-index').split('-')[1];
    removeSortIcon(id);
    $(this).removeClass('sorting_desc');
    $(this).addClass('sorting_asc');
    $('#' + id + ' .popup-content form tbody').append($('#' + id + ' .popup-content form tbody tr').Sorting(index, 'asc'));
    $('#' + id + ' .popup-content form tbody').rebuildSorting();
}));

function removeSortIcon(id) {
    $('#' + id).find('.popup-table-header thead th').each(function (idx, element) {
        if ($(element).hasClass('sorting_asc') || $(element).hasClass('sorting_desc')) {
            $(element).removeClass('sorting_desc');
            $(element).removeClass('sorting_asc');
            $(element).addClass('sort_both');
        }
    });
}

Array.prototype.sortByProp = function(value, type) {
    if (type == 'desc') {
        return this.sort(function (a, b) {
            if ($.isNumeric(a[value].formatAsMoney()) && $.isNumeric(b[value].formatAsMoney()))
                return (parseFloat(a[value].formatAsMoney()) < parseFloat(b[value].formatAsMoney())) ? 1 : (parseFloat(a[value].formatAsMoney()) > parseFloat(b[value].formatAsMoney())) ? -1 : 0;
            else
                return (a[value] < b[value]) ? 1 : (a[value] > b[value]) ? -1 : 0;
        });
    } else {
        return this.sort(function(a, b) {
            if ($.isNumeric(a[value].formatAsMoney()) && $.isNumeric(b[value].formatAsMoney()))
                return (parseFloat(a[value].formatAsMoney()) > parseFloat(b[value].formatAsMoney())) ? 1 : (parseFloat(a[value].formatAsMoney()) < parseFloat(b[value].formatAsMoney())) ? -1 : 0;
            else
                return (a[value] > b[value]) ? 1 : (a[value] < b[value]) ? -1 : 0;
        });
    }
};

$.fn.Sorting = function (index, sortType) {
    var data = new Array();
    var result = new Array();
    this.each(function (idx, element) {
        $(element).find('td').each(function (i, e) {
            if (i == index) {
                data[data.length] = { Index: idx, Value: $(e).text(), Data: element };
            }
        });
    });
    data.sortByProp('Value', sortType);
    for (var z = 0; z < data.length; z++) {
        result[z] = data[z].Data;
    }
    return $(result);
};

$.fn.rebuildSorting = function() {
    this.find('tr').each(function(idx, e) {
        if(idx%2) {
            $(e).addClass('alt');
        } else {
            $(e).removeClass('alt');
        }
    });
    return this;
};