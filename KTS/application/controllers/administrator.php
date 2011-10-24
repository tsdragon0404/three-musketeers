<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class Administrator extends CI_Controller {

	public function index()
	{
		
		$loged = $this->session->userdata('loged_in');
		$admin = $this->session->userdata('is_admin');
		
		if($loged && $admin)
			$this->load->view('administrator');
		else
			redirect('/administrator/login', 'refresh');
	}

	public function supporters()
	{
		$this->load->model('supporters');
		$data['title'] = "Manage Supporters";
		$data['list'] = $this->supporters->get_all_supporters();
		
		$this->load->view('admin/supporters', $data);
	}
	
	public function login()
	{
		$this->load->view('admin/login');
	}
	public function login_validate()
	{
		$user = $this->input->post('username');
		$pass = $this->input->post('password');
		
		$this->load->model('admins');
		$flag = $this->admins->login($user, $pass);
		if($flag == TRUE)
		{
			$this->session->set_userdata('user', $user);
			$this->session->set_userdata('loged_in', TRUE);
			$this->session->set_userdata('is_admin', TRUE);
			redirect('administrator/');
		}
		else
			redirect('administrator/login');
	}
	public function logout()
	{
		$this->session->set_userdata('loged_in', FALSE);
		$this->session->set_userdata('is_admin', FALSE);
		redirect('administrator/');
	}
	
}
?>