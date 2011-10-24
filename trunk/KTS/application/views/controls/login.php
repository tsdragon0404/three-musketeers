<div class="bortop"></div>
<div class="borleft">
    <div class="borright">
        <div class="content">
            <div class="box_content">
            	<div id="box_login_content">
				<?php if ($loged): ?>
                    <div class="welcome">Xin chào, <span class="bold"><?= $fullname;?></span></div>
                    <ul class="userfunc">
                        <li><?=anchor('#', 'Thông tin cá nhân')?></li>
                        <li><?=anchor('#', 'Đơn hàng của bạn')?></li>
                    </ul>
                    <div class="logout"><?=anchor('#', '<img src="' . base_url() . 'images/templates/default/btnlogout.png"/>', array('id'=>'logout'))?></div>
                <?php else: 
					echo form_open('', array('id'=>'frm_login'));
				?>
                    <table cellspacing="0" id="login">
                        <colgroup>
                            <col class="col1" />
                            <col class="col2" />
                        </colgroup>
                        <tbody>
                            <tr>
                                <td>Tên đăng nhập</td>
                                <td><?=form_input(array('name'=>'username', 'id'=>'login_username'));?></td>
                            </tr>
                            <tr>
                                <td>Mật khẩu</td>
                                <td><?=form_password(array('name'=>'password', 'id'=>'login_password'));?></td>
                            </tr>
                            <tr>
                                <td><?=anchor('user/forgetpassword', 'Quên mật khẩu ?', array('style'=>'font-size:90%;'))?></td>
                                <td align="right"><?=form_submit(array('name'=>'login', 'id'=>'btnlogin', 'value'=>' '));?></td>
                            </tr>
                        </tbody>
                    </table>
                    <p class="link"><?=anchor('user/register', 'Đăng ký thành viên')?></p>
                <?php echo form_close();
				 	endif;?>
            	</div>
            </div>
        </div>
    </div>
</div>
<div class="borbottom"></div>