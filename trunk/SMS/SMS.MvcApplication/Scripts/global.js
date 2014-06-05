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
        $('#leftmenu').css("width", "0");
        $('#leftmenuExpander').css("left", "0%");

        $('#body').css("width", "99%");
        
        link.removeClass('expanded');
        link.addClass('colapsed');
    }
    else {
        $('#leftmenu').css("width", "13%");
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
    var menuHeight = $('#admin-menu').outerHeight(true);

    $('#body #admin-body, #body #cashier, #body #kitchen').height(windowHeight - headerHeight - footerHeight - menuHeight);
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
    if (this == '')
        return '--/--/-- --:--';
    var d = new Date(this);
    return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/') + ' ' + [pad(d.getHours()), pad(d.getMinutes() + 1)].join(':');
};

Number.prototype.formatAsMoney = function () {
    return this.toLocaleString('en');
};

String.prototype.readMoneyAsNumber = function() {
    var str = this;
    if (this.indexOf(',') >= 0) {
        str = str.replace(/,/g, '');
    }

    return parseInt(str);
};

$.fn.table = function () {
    this.addClass('no-border');
    this.find('thead tr').addClass('ui-widget-header');
    this.find('tbody tr, tfoot tr').addClass('ui-helper-reset ui-state-default');
};