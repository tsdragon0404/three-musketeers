<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><?=$title?></title>
<link type="text/css" rel="stylesheet" href="<?=base_url()?>css/default.css" />
<script type="text/javascript" src="<?=base_url()?>js/jquery-1.6.2.min.js"></script>
<script type="text/javascript" src="<?=base_url()?>js/script.js"></script>
<?php if(isset($script))
	echo $script;
?>
<script type="text/javascript" >
	var base_folder = "<?= base_url();?>";
	var loading_img = "<img src='<?= base_url();?>images/templates/default/loading.gif' />";
	var loading_img2 = "<img src='<?= base_url();?>images/templates/default/loading.gif' width='22px' height='22px'/>";	
	var base_url = base_folder + "index.php/";
</script>
</head>

<body>
	<div id="wrapper">
        <?=$header?>
        <div id="container">
        	<?=$content?>
            <div id="right">
            	<div class="box" id="box_login">
            		<?=$control_login?>
                </div>
            	<?php $this->load->view('client/right');?>
                <div class="box" id="box_supporter">
            		<?=$control_support?>
                </div>
            </div>
            <div class="clear"></div>
        </div>
        <div id="footer"></div>
    </div>
</body>
</html>
