using System.Collections.Generic;

namespace SMS.MvcApplication.Areas.Administrator.Models
{
    public class AdminModel<TDto>
    {
        public IList<TDto> ListRecord { get; set; }
    }
}