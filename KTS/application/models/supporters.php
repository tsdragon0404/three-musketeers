<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class Supporters extends CI_Model {
	
	var $id;
	var $yahoo;
	var $phone;
	
	function __construct()
    {
		$id = 0;
		$yahoo = "";
		$phone = "";
        // Call the Model constructor
        parent::__construct();
    }
	
	function get_all_supporters()
	{
		return $this->db->get('supporter')->result_array();
	}
	
	function get_supporters_html()
	{
		$list = $this->get_all_supporters();
		$rs = "";
		foreach($list as $row)
		{
			$im = imagecreatefromgif("http://opi.yahoo.com/online?u=" . $row['yahoo'] . "&t=5");
			if ($im == FALSE)
				return "error";
			$rgb = imagecolorat($im, 7, 7);
			$r = ($rgb >> 16) & 0xFF;
			$g = ($rgb >> 8) & 0xFF;
			$b = $rgb & 0xFF;
			$img = "offline.png";
			if($r == 0 && $g == 0 && $b == 20)
				$img = "online.png";
			$rs .= "<p class='supporter'><a href='ymsgr:sendIM?" . $row['yahoo'] . "'><img src='" . 
			base_url() . "images/templates/default/" . $img . "'/>". $row['name'] . " - " . $row['phone'] . "</a></p>";
		}
		return $rs;
	}
}
?>