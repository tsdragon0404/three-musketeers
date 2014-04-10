$(document).ready(function(){
    BuildLeftMenuExpander();
    
    var cashier = $('#cashier');
    if (cashier.length != 0) {
        SetHeightCashierSection();
        $(window).resize(SetHeightCashierSection);
    }
});

function BuildLeftMenuExpander() {
    var leftmenu = $('#leftmenu');
    if (leftmenu.length == 0)
        return;

    var linkHtml = '<a href="#" id="expander" class="expanded">&lt;</a>';
    leftmenu.append(linkHtml);

    $('#expander').click(ExpandColapseMenu);
}

function ExpandColapseMenu() {
    var link = $('#expander');
    if(link.hasClass('expanded')) {
        $('#leftmenu').animate({
            width: "1%"
        }, 500);
        $('#body').animate({
            width: "98%"
        }, 500);
        link.removeClass('expanded');
        link.addClass('colapsed');
    }
    else {
        $('#leftmenu').animate({
            width: "14%"
        }, 500);
        $('#body').animate({
            width: "85%"
        }, 500);
        link.removeClass('colapsed');
        link.addClass('expanded');
    }
}

function SetHeightCashierSection() {
    var windowHeight = $(window).height();
    var headerHeight = $('header').outerHeight();
    var footerHeight = $('footer').outerHeight();

    $('#body #cashier').height(windowHeight - headerHeight - footerHeight);
}