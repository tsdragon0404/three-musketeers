$(document).ready(function() {
    // Slide home
    if($('#home_pic a img').length > 1)
    {
        $('#home_pic a img:gt(0)').hide();
        $('#home_pic a img:eq(0)').addClass('current');
        setInterval(slide_next, 5000);
    }
    // zoom picture
    $('#pictures .pic .zoomArea:gt(0)').hide();
    $('#pictures .pic .zoomArea:eq(0)').addClass('current');
    $('#pictures .pic .zoomArea').zoom();

    $('#pictures .next a').click(nextPicture);
    $('#pictures .prev a').click(prevPicture);
    
});

// slide home
function slide_next()
{
    var cur = $('#home_pic a img.current');
    var next;
    if($('#home_pic a img').index(cur) < $('#home_pic a img').length - 1)
	    next = cur.next();
    else
	    next = $('#home_pic a img:eq(0)');
	
	cur.fadeOut(1000);
	next.fadeIn(1000);
	
	cur.removeClass('current');
    next.addClass('current');
}
// end slide home

// zoom picture functions
function nextPicture()
{
    var cur = $('#pictures .pic .zoomArea.current');
    var next;
    if($('#pictures .pic .zoomArea').index(cur) < $('#pictures .pic .zoomArea').length - 1)
	    next = cur.next();
    else
	    next = $('#pictures .pic .zoomArea:first');
    next.show();
    cur.hide();
	
    cur.removeClass('current');
    next.addClass('current');
}
function prevPicture()
{
    var cur = $('#pictures .pic .zoomArea.current');
    var prev;
    if($('#pictures .pic .zoomArea').index(cur) > 0)
	    prev= cur.prev();
    else
	    prev = $('#pictures .pic .zoomArea:last');
    prev.show();
    cur.hide();
	
    cur.removeClass('current');
    prev.addClass('current');
}
// end zoom picture functions