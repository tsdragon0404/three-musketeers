<div id="left">
	<div id="banner"></div>
    <div class="bortop"></div>
    <div class="borleft">
        <div class="borright">
        <div class="title">Quên mật khẩu</div>
            <div class="content">
            <?=form_open('user/forgetpassword', array('id'=>'frm_forget', 'autocomplete'=>'off'));?>
                <table cellpadding="5" cellspacing="10">
                	<colgroup>
                    	<col class='col1' />
                        <col class='col2' />
                    </colgroup>
                    <?php if( isset($error) ):?>
                        <tr>
                            <td colspan="3" style='text-align:center; color:#f00'><?=$error?></td>
                        </tr>
                    <?php endif;?>
                    <tr>
                        <th>Tên đăng nhập</th>
                        <td><?=form_input(array('name'=>'txtusername'));?></td>
                    </tr>
                    <tr>
                        <th>Email</th>
                        <td><?=form_input(array('name'=>'txtemail'));?></td>
                    </tr>
                    <tr>
                    	<td colspan="2"><?=$captcha?></td>
                    </tr>
                    <tr>
                    	<td colspan="2" style="text-align:center;"><?=form_submit(array('name'=>'btnforget', 'value'=>' ', 'id'=>'btnforget'))?></td>
                    </tr>
                </table>
                <?=form_close();?>
            </div>
        </div>
    </div>
    <div class="borbottom"></div>
</div>