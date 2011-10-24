<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class Users extends CI_Model {
	var $id;
	var $fullname;
	var $birthday;
	var $sex;
	var $email;
	var $address;
	var $username;
	var $password;
	
	// Remember me function
	var $remember;
	
	function __construct()
    {
		$this->id = 0;
		$this->fullname = '';
		$this->birthday = '1900-01-01';
		$this->sex = 1;
		$this->email = '';
		$this->username = '';
		$this->password = '';
		$this->remember = FALSE;
		
        // Call the Model constructor
        parent::__construct();
    }
	
	/*function check_login()
	{
		if($this->session->userdata('loged_in') != TRUE)
		{
			$this->username = get_cookie('username');
			$this->password = get_cookie('password');
			if($this->username != FALSE && $this->password != FALSE)
			{
				return $this->login();
			}
			return FALSE;
		}
		return TRUE;
	}*/
	function login()
	{
		$this->db->where('username', $this->username);
		$this->db->where('password', $this->password);
		$query = $this->db->get('user');
		if($query->num_rows() == 1)
		{
			$row = $query->row();
			$this->session->set_userdata('uid', $row->id);
			$this->session->set_userdata('username', $row->username);
			$this->session->set_userdata('fullname', $row->fullname);
			$this->session->set_userdata('loged_in', TRUE);
/*
			if($this->remember == "true")
			{
				set_cookie('username', $row->username, 604800, '', '');
				set_cookie('password', $row->password, 604800, '', '');
			}*/
			return TRUE;
		}
		$this->session->unset_userdata('username');
		$this->session->unset_userdata('uid');
		$this->session->unset_userdata('fullname');
		$this->session->unset_userdata('loged_in');
		return FALSE;
	}
	function logout()
	{
		$this->session->unset_userdata('user');
		$this->session->unset_userdata('loged_in');
		/*
		delete_cookie('username', '', 0, '', '');
		delete_cookie('password', '', 0, '', '');
		*/
	}
	function check_availability()
	{
		$this->db->where('username', $this->username);
		$query = $this->db->get('user');
		if($query->num_rows() > 0)
			return 1;
		else
			return 0;
	}
	function insert()
	{
		$data = array('id'=>'', 'fullname'=>$this->users->fullname, 'birthday'=>$this->users->birthday, 'sex'=>$this->users->sex, 'email'=>$this->users->email, 
						'address'=>$this->users->address, 'username'=>$this->users->username, 'password'=>$this->users->password);
		$this->db->insert('user', $data);
	}
}
?>