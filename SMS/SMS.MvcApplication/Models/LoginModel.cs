using System.Collections.Generic;
using System.Web.Mvc;

namespace SMS.MvcApplication.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public long SelectedBranch { get; set; }
        public IList<SelectListItem> ListBranch { get; set; }

        public bool ShowError { get; set; }
        public string ErrorMessage { get; set; }
    }
}