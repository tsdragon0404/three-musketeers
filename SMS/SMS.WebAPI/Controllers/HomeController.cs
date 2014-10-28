using System.Web.Http;

namespace SMS.WebAPI.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "webcome";
        }
    }
}
