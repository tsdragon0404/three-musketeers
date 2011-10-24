<div id="left">
	<div id="banner"></div>
    <div class="bortop"></div>
    <div class="borleft">
        <div class="borright">
        <div class="title">Đăng ký thành viên</div>
            <div class="content">
            <?=form_open('user/register', array('id'=>'frm_reg', 'autocomplete'=>'off'));?>
                <table cellpadding="5" cellspacing="10">
                	<colgroup>
                    	<col class='col1' />
                        <col class='col2' />
                        <col class='col3' />
                    </colgroup>
                    <?php if( isset($error) ):?>
                        <tr>
                            <td colspan="3" style='text-align:center; color:#f00'><?=$error?></td>
                        </tr>
                    <?php endif;?>
                    <tr>
                        <th>Tên đăng nhập</th>
                        <td><?=form_input(array('name'=>'txtusername', 'id'=>'frmreg_username', 'value'=>set_value('txtusername')));?></td>
                        <td><div id='username_validator'><img src='<?=base_url()?>images/cross.png'/></div></td>
                    </tr>
                    <tr>
                        <th>Mật khẩu</th>
                        <td><?=form_password(array('name'=>'txtpassword', 'id'=>'frmreg_password'));?></td>
                        <td><div id='password_validator'><img src='<?=base_url()?>images/cross.png'/></div></td>
                    </tr>
                    <tr>
                        <th>Nhập lại mật khẩu</th>
                        <td><?=form_password(array('name'=>'txtpasswordconf', 'id'=>'frmreg_passwordconf'));?></td>
                        <td><div id='passwordconf_validator'><img src='<?=base_url()?>images/cross.png'/></div></td>
                    </tr>
                    <tr>
                        <th>Họ và tên</th>
                        <td><?=form_input(array('name'=>'txtname'));?></td>
                        <td></td>
                    </tr>
                    <!--<tr>
                        <th>Ngày sinh</th>
                        <td><input type="text" id="txtbirthday"/></td>
                    </tr>-->
                    <tr>
                        <th>Giới tính</th>
                        <td><?=form_dropdown('ddlsex', array('1' => 'Nam', '0' =>'Nữ'), 'Nam', 'value="' . set_value('ddlsex') . '"');?></td>
                        <td></td>
                    </tr>
                    <tr>
                        <th>Email</th>
                        <td><?=form_input(array('name'=>'txtemail', 'value'=>set_value('txtemail')));?></td>
                        <td></td>
                    </tr>
                    <tr>
                        <th>Địa chỉ</th>
                        <td><?=form_input(array('name'=>'txtaddress', 'value'=>set_value('txtaddress')));?></td>
                        <td></td>
                    </tr>
                    <tr>
                    	<td colspan="3"><?=$captcha?></td>
                    </tr>
                    <tr>
                    	<td colspan="3" style="text-align:center;"><?=form_submit(array('name'=>'btnreg', 'value'=>' ', 'id'=>'btnreg'))?></td>
                    </tr>
                </table>
                <?=form_close();?>
            </div>
        </div>
    </div>
    <div class="borbottom"></div>
</div>