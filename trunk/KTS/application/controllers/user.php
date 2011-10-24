<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class User extends CI_Controller {

	public function index()
	{
	}
	
	public function register($verify = "")
	{	
		$error = "";	
		if($this->input->post('btnreg'))
		{
			$this->load->library('recaptcha');
			$privatekey = "6Lf0A8kSAAAAAGguEFRNSwrDNobswZKtxCephsd0";
			$this->recaptcha->recaptcha_check_answer ($privatekey,
										$this->input->ip_address(),
										$this->input->post("recaptcha_challenge_field", FALSE),
										$this->input->post("recaptcha_response_field", FALSE));
			if (!$this->recaptcha->is_valid)
				$error = "Mã bảo vệ không chính xác";
			else
			{
				$this->users->username = $this->input->post('txtusername');
				$avai = $this->users->check_availability();
				if($avai == 1)
					$error = "Tên đăng nhập này đã tồn tại. Bạn <a href='user/forgetpassword'>quên mật khẩu</a> ?";
				else
				{
					$passconf = $this->input->post('txtpasswordconf');
					if(strlen($this->input->post('txtpassword')) < 6 || $this->input->post('txtpassword') == "" 
						|| $this->input->post('txtpassword') != $passconf)
						$error = "Mật khẩu không hợp lệ";
					else
					{
						$this->users->password = md5($this->input->post('txtpassword'));
						$this->users->fullname = $this->input->post('txtname');
						$this->users->sex = $this->input->post('ddlsex');
						$this->users->email = $this->input->post('txtemail');
						$this->users->address = $this->input->post('txtaddress');
						
						$this->users->insert();
						$this->users->login();
						redirect('user/regsuccess');
					}
				}
			}
		}
		$data['title'] = "KTS online - Register";
		$data['header'] = $this->controls->load_header();
		$data['script'] = "<script type='text/javascript' src='" . base_url() . "js/reg.js'></script>";
		
		$data['control_login'] = $this->controls->load_login_box();
		$data['control_support'] = $this->controls->load_support_box();

		$data['content'] = $this->controls->load_register_content($error);
		
		$this->load->view('master', $data);
	}
	public function regsuccess()
	{
		$data['title'] = "KTS online - Register Successful";
		$data['header'] = $this->controls->load_header();
		
		$data['control_login'] = $this->controls->load_login_box();
		$data['control_support'] = $this->controls->load_support_box();

		$data['content'] = $this->controls->load_registersuccess_content();
		
		$this->load->view('master', $data);
	}
	public function forgetpassword()
	{
		$data['title'] = "KTS online - Forget password";
		$data['header'] = $this->controls->load_header();
		
		$data['control_login'] = $this->controls->load_login_box();
		$data['control_support'] = $this->controls->load_support_box();

		$data['content'] = $this->controls->load_forgetpassword_content();
		
		$this->load->view('master', $data);
	}
}
?>