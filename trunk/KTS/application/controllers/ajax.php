<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class Ajax extends CI_Controller {

	public function index()
	{
	}
	
	public function login()
	{
		$this->load->library('form_validation');
		
		$this->form_validation->set_rules('username', 'Username', 'required');
		$this->form_validation->set_rules('password', 'Password', 'required');
		
		$this->users->username = strtolower($this->input->post('username'));
		$this->users->password = md5($this->input->post('password'));
		//$this->users->remember = $this->input->post('remember');
		
		if ($this->users->username != FALSE && $this->users->password != FALSE )//&& $this->users->remember != FALSE)
		{
			if ($this->form_validation->run())
			{
				$data_login['loged'] = $this->users->login();
				$data_login['fullname'] = $this->session->userdata('fullname');
				
				echo $this->load->view('controls/login', $data_login, TRUE);
			}
			else
				echo "";
		}
		else
			echo "";
	}
	
	public function logout()
	{
		$this->users->logout();
		$data_login['loged'] = FALSE;
		echo $this->load->view('controls/login', $data_login, TRUE);
	}
	
	public function getSupporters()
	{
		echo $this->supporters->get_supporters_html();
	}
	
	public function user_check()
	{
		$this->users->username = strtolower($this->input->post('username'));
		$this->load->library('form_validation');
		$this->form_validation->set_rules('username', 'Username', 'min_length[6]|xss_clean');
		if ($this->form_validation->run() && strpos($this->input->post('username'), ' ') === FALSE)
		{
			$rs = $this->users->check_availability();
			if($rs == 0)
				echo "TRUE";//"<img src='" . base_url() . "images/tick.png'/>";
			else
				echo "FALSE";//"<img src='" . base_url() . "images/cross.png'/>";
		}
		else
			echo "FALSE";//"<img src='" . base_url() . "images/cross.png'/>";
	}
}
?>