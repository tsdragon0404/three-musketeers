<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class Admins extends CI_Model {
	var $id;
	var $user;
	var $password;
	var $remember;
	
	function __construct()
    {
		$id = 0;
		$user = '';
		$password = '';
		$remember = FALSE;
        // Call the Model constructor
		$this->load->helper('cookie');
        parent::__construct();
    }
	
	function check_login()
	{
		$this->user = get_cookie('user');
		$this->password = get_cookie('password');
		if($this->user != FALSE && $this->password != FALSE)
		{
			$this->login();
		}
	}
	function login()
	{
		$this->db->where('username', $this->user);
		$this->db->where('password', $this->password);
		$query = $this->db->get('admin');
		if($query->num_rows() == 1)
		{
			$this->session->set_userdata('user', $this->user);
			$this->session->set_userdata('loged_in', TRUE);
			$this->session->set_userdata('is_admin', TRUE);
			if($this->remember)
			{
				$cookie = array(
					'name'   => 'user',
					'value'  => $this->user,
					'expire' => '604800'
				);
				set_cookie($cookie);
				$cookie = array(
					'name'   => 'password',
					'value'  => md5($this->password),
					'expire' => '604800'
				);
				set_cookie($cookie);
			}
			return TRUE;
		}
		$this->session->unset_userdata('user');
		$this->session->unset_userdata('loged_in');
		$this->session->unset_userdata('is_admin');
		return FALSE;
	}
	function logout()
	{
		$this->session->unset_userdata('user');
		$this->session->unset_userdata('loged_in');
		$this->session->unset_userdata('is_admin');
	}
}
?>