﻿namespace SMS.MvcApplication.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool ShowError { get; set; }
        public string ErrorMessage { get; set; }
    }
}