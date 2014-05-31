﻿$(document).ready(function(){
    var leftmenu = $('#leftmenu');
    if (leftmenu.length != 0) {
        $('#leftmenuExpander').css("left", leftmenu.outerWidth() + "px");
        $('#expander').click(ExpandColapseMenu);
    }
    
    var body = $('#body');
    if (body.length != 0) {
        SetHeightBodySection();
        $(window).resize(SetHeightBodySection);
    }
});

function ExpandColapseMenu() {
    var link = $('#expander');
    if (link.hasClass('expanded')) {
        $('#leftmenu').css("width", "0");
        $('#leftmenuExpander').css("left", "0");

        $('#body').css("width", "99%");
        
        link.removeClass('expanded');
        link.addClass('colapsed');
    }
    else {
        $('#leftmenu').css("width", "13%");
        $('#leftmenuExpander').css("left", $('#leftmenu').outerWidth() + "px");

        $('#body').css("width", "86%");
        link.removeClass('colapsed');
        link.addClass('expanded');
    }
    return false;
}

function SetHeightBodySection() {
    var windowHeight = $(window).height();
    var headerHeight = $('#header').outerHeight();
    var footerHeight = $('#footer').outerHeight();
    var menuHeight = $('#admin-menu').outerHeight();

    $('#body #admin-body, #body #cashier, #leftmenu').height(windowHeight - headerHeight - footerHeight - menuHeight);
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