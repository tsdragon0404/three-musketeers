$(document).ready(function () {
    $('#navmenu ul li:not(.active)').hover(showtit, hidetit); // 1
	$('#box_login form').submit(ajax_login); // 2
	$('a#logout').click(ajax_logout); // 3
	$('#tab ul li').click(function(e){
		e.preventDefault();
		changeTab($('#tab ul li').index($(this)));
	}); // 4
	$('#tab ul li').hover(arrowmove, arrowback); // 5
	getSupporters(); // 6
});

/* 1 - Top navigation menu animation */
function showtit()
{
	$(this).find('p').animate({top:'5px'},{queue:false,duration:250});
}
function hidetit()
{
	$(this).find('p').animate({top:'-20px'},{queue:false,duration:250});
}

/* 2 - AJAX login */
function ajax_login()
{
	var par = $(this).serializeArray();
	var user = par[0].value;
	var pass = par[1].value;
	if(user.trim() == "" && pass.trim() == "")
		return false;
	var loading = "<center style='padding-top:20px;'>" + loading_img + "</center>";
	$('#box_login_content')[0].innerHTML = loading;
	$.post(base_url + "ajax/login",
		  { username: user,
			password: pass },
			function(data){
				if(data == "" || data.indexOf("<form") != -1)
				{
					alert("Đăng nhập thất bại.");
				}
				else
				{
					$('#box_login')[0].innerHTML = data;
					$($('#box_login_content')[0]).css('display', 'none');
					$($('#box_login_content')[0]).fadeToggle()
					$('a#logout').click(function(e){
						e.preventDefault();
						ajax_logout();
					}); // 3
				}
	});
	return false;
}
/* 3 - AJAX logout */
function ajax_logout()
{
	var loading = "<center style='padding-top:20px;'>" + loading_img + "</center>";
	$('#box_login_content')[0].innerHTML = loading;
	$.post(base_url + "ajax/logout", function(data){
				$('#box_login')[0].innerHTML = data;
				$($('#box_login_content')[0]).css('display', 'none');
				$($('#box_login_content')[0]).fadeToggle()
				$('#box_login form').submit(function(e){
				e.preventDefault();
				ajax_login();
			});
	});
	return false;
}

/* 4 - Change content tab */
function changeTab(index)
{
	if($($('#tab ul li')[index]).hasClass('current') && $($('#tab_content .section')[index]).hasClass('current'))
		return;
		
	$('#tab_content .section.current').fadeOut(0);
	$('#tab .current').toggleClass('current');
	$('#tab_content .current').toggleClass('current');
	
	$($('#tab_content .section')[index]).fadeIn(500);
	$($('#tab ul li')[index]).toggleClass('current');
	$($('#tab_content .section')[index]).toggleClass('current');
}

/* 5 - Tab arrow animation */
function arrowmove()
{
	if($(this).hasClass('current'))
		return;
	var target = $('#tab ul li').index($(this));
	$('#nav-arrow').animate({left: (58 + 103 * target) + 'px'}, {queue:false,duration:500});
}
function arrowback()
{
	if($(this).hasClass('current'))
		return;
	var target = $('#tab ul li').index($('#tab ul li.current'));
	$('#nav-arrow').animate({left: (58 + 103 * target) + 'px'}, {queue:false,duration:500});
}

/* 6 - AJAX Get supporters */
function getSupporters()
{
$.post(base_url + "ajax/getsupporters", function(data){
		if (data.indexOf('error')!= -1)
		{
			setTimeout(getSupporters, 10000);
		}
		else
		{
			$('#box_supporter .box_content')[0].innerHTML = data;
			$($('#box_supporter .box_content')[0]).css('display', 'none');
			$($('#box_supporter .box_content')[0]).slideToggle()
		}
	});
}