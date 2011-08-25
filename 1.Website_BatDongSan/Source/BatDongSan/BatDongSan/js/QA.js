$(document).ready(function () {
    setHeight();
    $('a.showhide').click(showhideAnswer);
});

function showhideAnswer()
{
    if(!$(this).hasClass("show"))
	{
		$('a.show').parent('.func').prev('div.A:first').slideToggle('medium');
		$('a.show').text("Xem trả lời");
		$('a.show').removeClass("show");
		$(this).text("Ẩn trả lời");
		$(this).addClass("show");
	}
	else
	{
		$(this).removeClass("show");
		$(this).text("Xem trả lời");
	}
	$(this).parent('.func').prev('div.A:first').slideToggle('medium');
}

function setHeight()
{
    for(i = 0; i < $('div.A').length; i++)
    {
        $($('div.A')[i]).css("height", $($('div.A')[i]).height() + "px");
        $($('div.A')[i]).hide();
    }
}