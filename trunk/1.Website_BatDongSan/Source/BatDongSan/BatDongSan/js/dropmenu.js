$(document).ready(function () {
    setHeight();
    $('ul.sf-menu').superfish();
});

function setHeight()
{
    var h = 0;
    var li = $('ul.sf-menu ul.sub').children();
    for(i = 0; i < li.length; i++)
        h += li[0].clientHeight;
        
    $('ul.sf-menu ul.sub').css("height", h + "px");
}