$(document).ready(function () {
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