<html>
<head>
<title>Login to website</title>
</head>
<body>
	<?php
    	echo form_open('administrator/login_validate');
		echo form_input('username', 'Username');
		echo form_password('password', 'Password');
		echo form_submit('submit', 'Login');
	?>
</body>
</html>