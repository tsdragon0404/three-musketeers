using System.Web.Mvc;
using SMS.Data.Dtos;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Controllers
{
    public class AccountController : Controller
    {
        public IUserService UserService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var response = UserService.Get<UserDto>(model.Username, model.Password);
                if (!response.Success)
                {
                    // handle error
                    ModelState.AddModelError(response.Errors[0].Property, response.Errors[0].ErrorMessage);
                    return View(model);
                }

                var user = response.Data;

            }
            return View();
        }
    }
}
