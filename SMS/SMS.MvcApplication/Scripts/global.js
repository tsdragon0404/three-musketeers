$(document).ready(function(){
    var leftmenu = $('#leftmenu');
    if (leftmenu.length != 0) {
        $('#expander').click(ExpandColapseMenu);
    }
    
    var cashier = $('#cashier');
    if (cashier.length != 0) {
        SetHeightCashierSection();
        $(window).resize(SetHeightCashierSection);
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

function SetHeightCashierSection() {
    var windowHeight = $(window).height();
    var headerHeight = $('#header').outerHeight();
    var footerHeight = $('#footer').outerHeight();

    $('#body #cashier').height(windowHeight - headerHeight - footerHeight);
}