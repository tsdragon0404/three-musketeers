using System.Web.Http;
using SMS.WebAPI.Base;

namespace SMS.WebAPI.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public string Index()
        {
            return "webcome";
        }
    }
}
