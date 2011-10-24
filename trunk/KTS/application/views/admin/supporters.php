<html>
<head>
<title><?=$title?></title>
</head>
<body>
	<ul><?php foreach( $list as $row ): ?>
    	<li><?=$row['yahoo']?></li>
        <?php endforeach;?>
    </ul>
</body>
</html>