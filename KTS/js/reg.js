// JavaScript Document
$(document).ready(function () {
    $('#frmreg_username').keyup(user_check);
	$('#frmreg_password').keyup(pass_check);
	$('#frmreg_passwordconf').keyup(passconf_check);
	$('#frm_reg').submit(submit_frmreg);
});

var delay = (function(){
  var timer = 0;
  return function(callback, ms){
    clearTimeout (timer);
    timer = setTimeout(callback, ms);
  };
})();

/* check username availability */
function user_check(){
	delay(function(){
		var user = $('#frmreg_username')[0].value;
		if(user == "")
		{
			$('#username_validator')[0].innerHTML = "<img src='" + base_folder + "images/cross.png'/>";
			return;
		}
		$('#username_validator')[0].innerHTML = loading_img2;
		$.post(base_url + "ajax/user_check", 
			  { username: user },
				function(data){
					if(data == "TRUE")
						$('#username_validator')[0].innerHTML = "<img src='" + base_folder + "images/tick.png'/>";
					else
						$('#username_validator')[0].innerHTML = "<img src='" + base_folder + "images/cross.png'/>";
					$($('#username_validator')[0]).css('display', 'none');
					$($('#username_validator')[0]).fadeToggle()
		});
	}, 500 );
}
function pass_check(){
		var pass = $('#frmreg_password')[0].value;
		if(pass == "" || pass.length < 6)
		{
			$('#password_validator')[0].innerHTML = "<img src='" + base_folder + "images/cross.png'/>";
			return;
		}
		$('#password_validator')[0].innerHTML = "<img src='" + base_folder + "images/tick.png'/>";		
	
}
function passconf_check(){
		var pass1 = $('#frmreg_password')[0].value;
		var pass2 = $('#frmreg_passwordconf')[0].value;
		if(pass2 == "" || pass1 != pass2 || pass1.length < 6)
		{
			$('#passwordconf_validator')[0].innerHTML = "<img src='" + base_folder + "images/cross.png'/>";
			return;
		}
		$('#passwordconf_validator')[0].innerHTML = "<img src='" + base_folder + "images/tick.png'/>";		
	
}
function submit_frmreg()
{
	var pass = $('#frmreg_password')[0].value;
	if(pass == "" || pass.length < 6)
	{
		$('#frmreg_password')[0].focus();
		return false;
	}
	var passconf = $('#frmreg_passwordconf')[0].value;
	if(pass != passconf)
	{
		$('#frmreg_passwordconf')[0].focus();
		return false;
	}
}