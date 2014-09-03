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
    var menuHeight = $('#tabs-menu').outerHeight(true);

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

$.fn.sortingTable = function (sortColumn) {
    var popupId = this.attr('id');
    this.find(' .popup-table-header thead th').each(function (idx, element) {
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
    $('#' + id + ' .popup-content form tbody').rebuildTable();
}));

$(document).on("click", '.popup-table-header th.sorting_asc', (function () {
    var id = $(this).attr('sort-index').split('-')[0];
    var index = $(this).attr('sort-index').split('-')[1];
    removeSortIcon(id);
    $(this).removeClass('sorting_asc');
    $(this).addClass('sorting_desc');
    $('#' + id + ' .popup-content form tbody').append($('#' + id + ' .popup-content form tbody tr').Sorting(index, 'desc'));
    $('#' + id + ' .popup-content form tbody').rebuildTable();
}));

$(document).on("click", '.popup-table-header th.sorting_desc', (function () {
    var id = $(this).attr('sort-index').split('-')[0];
    var index = $(this).attr('sort-index').split('-')[1];
    removeSortIcon(id);
    $(this).removeClass('sorting_desc');
    $(this).addClass('sorting_asc');
    $('#' + id + ' .popup-content form tbody').append($('#' + id + ' .popup-content form tbody tr').Sorting(index, 'asc'));
    $('#' + id + ' .popup-content form tbody').rebuildTable();
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
            return (a[value] < b[value]) ? 1 : (a[value] > b[value]) ? -1 : 0;
        });
    } else {
        return this.sort(function(a, b) {
            return (a[value] > b[value]) ? 1 : (a[value] < b[value]) ? -1 : 0;
        });
    }
};

$.fn.Sorting = function (index, sortType) {
    var data = new Array();
    var result = new Array();
    var flag = true;
    this.each(function (idx, element) {
        $(element).find('td').each(function (i, e) {
            if (i == index) {
                if (!$.isNumeric($(e).text().formatAsMoney())) {
                    flag = false;
                }
                data[data.length] = { Index: idx, Value: $(e).text(), Data: element };
            }
        });
    });
    
    if (flag) {
        for (var j = 0; j < data.length; j++) {
            data[j].Value = parseFloat(data[j].Value.formatAsMoney());
        }
    }

    data.sortByProp('Value', sortType);
    for (var z = 0; z < data.length; z++) {
        result[z] = data[z].Data;
    }
    return $(result);
};

$.fn.rebuildTable = function () {
    var index = 0;
    this.find('tr').each(function (idx, e) {
        if (!$(e).hasClass('hide')) {
            $(e).find('td:first-child').text(index + 1);
            if (index % 2) {
                $(e).addClass('alt');
            } else {
                $(e).removeClass('alt');
            }
            index++;
        }
    });
    return this;
};

$.fn.searchTable = function (searchColumn) {
    var popupId = this.attr('id');
    this.find(' .popup-table-header thead .search-popup').remove();

    var HTMLElement = '<tr class="search-popup">';
    this.find(' .popup-table-header thead th').each(function (idx) {
        HTMLElement = HTMLElement + '<th>';
        if ($.inArray(idx, searchColumn) >= 0)
            HTMLElement = HTMLElement + '<input type="text" search-index="' + popupId + '-' + idx +'" class="text-search" />';
        
        HTMLElement = HTMLElement + '</th>';
    });
    HTMLElement = HTMLElement + '</tr>';

    this.find(' .popup-table-header thead').append(HTMLElement);
};

$(document).on("keypress", '.popup-table-header th input.text-search', (function (e) {
    if (e.which == 13) {
        var id = $(this).attr('search-index').split('-')[0];
        var index = [];
        var keyword = [];

        $('.popup-table-header th input').each(function(idx, elem) {
            if (id == $(elem).attr('search-index').split('-')[0]) {
                index[index.length] = parseInt($(this).attr('search-index').split('-')[1]);
                keyword[keyword.length] = $(this).val().trim();
            }
        });

        $('#' + id + ' .popup-content form tbody').append($('#' + id + ' .popup-content form tbody tr').Searching(index, keyword));
        $('#' + id + ' .popup-content form tbody').rebuildTable();
    }
}));

$.fn.Searching = function (index, keyword) {
    this.each(function (idx, element) {
        $(element).removeClass('hide');
        $(element).find('td').each(function (i, e) {
            if ($.inArray(i, index) >= 0) {
                var str = $(e).text().toUpperCase();

                if (str.search(keyword[$.inArray(i, index)].toUpperCase()) < 0) {
                    $(element).addClass('hide');
                }
            }
        });
    });
    return this;
};