<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class Home extends CI_Controller {
	
	public function index()
	{	
		$data['title'] = "KTS online - Homepage";
		$data['header'] = $this->controls->load_header();
		
		$data['control_login'] = $this->controls->load_login_box();
		
		$data['control_support'] = $this->controls->load_support_box();
		
		$data['content'] = $this->controls->load_main_content();
		
		$this->load->view('master', $data);
	}
}
?>