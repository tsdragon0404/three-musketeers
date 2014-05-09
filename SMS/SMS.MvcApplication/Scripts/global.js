$(document).ready(function(){
    var leftmenu = $('#leftmenu');
    if (leftmenu.length != 0) {
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
        $('#leftmenu').animate({
            width: "1%"
        }, 500);
        
        $('#body').animate({
            width: "97%"
        }, 500);
        
        link.removeClass('expanded');
        link.addClass('colapsed');
    }
    else {
        $('#body').animate({
            width: "85%"
        }, 500);
        
        $('#leftmenu').animate({
            width: "13%"
        }, 500);
        
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

    $('#body #admin-body, #body #cashier').height(windowHeight - headerHeight - footerHeight - menuHeight);
}

function pad(s) { return (s < 10) ? '0' + s : s; }

Date.prototype.transform = function (inputDate) {
    var d = new Date(inputDate);
    return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/');
}