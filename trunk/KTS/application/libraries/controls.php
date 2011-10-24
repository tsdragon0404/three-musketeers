<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed'); 

class Controls {
	var $CI;
	
	public function __construct()
    {
        $this->CI =& get_instance();
    }
	
	private function get_view_html($viewname, $data = ''){
		return $this->CI->load->view($viewname, $data, true);
	}
	
	public function load_header()
	{
		return $this->get_view_html('client/header');
	}
	
    public function load_login_box()
    {
		$data_login['loged'] = $this->CI->session->userdata('loged_in');
		$data_login['fullname'] = $this->CI->session->userdata('fullname');
		return $this->get_view_html('controls/login', $data_login);
    }
	
	public function load_support_box()
	{
		$data_support['list'] = $this->CI->supporters->get_all_supporters();
		return $this->get_view_html('controls/support', $data_support);
	}
	
	public function load_main_content()
	{
		return $this->get_view_html('client/left');
	}
	
	public function load_register_content($error)
	{
		$data_register['captcha'] = $this->load_captcha();
		if($error != "")
			$data_register['error'] = $error;
		return $this->get_view_html('client/register', $data_register);
	}
	public function load_registersuccess_content()
	{
		return $this->get_view_html('client/register_success');
	}
	public function load_captcha()
	{
		$this->CI->load->library('recaptcha');
		return $this->CI->recaptcha->recaptcha_get_html('6Lf0A8kSAAAAAGZnlWqiof5c3T36AkGSsDpB2UUo');
	}
	public function load_forgetpassword_content()
	{
		$data_forget['captcha'] = $this->load_captcha();
		return $this->get_view_html('client/forgetpass', $data_forget);
	}
}