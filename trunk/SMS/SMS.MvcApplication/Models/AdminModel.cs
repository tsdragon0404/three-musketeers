using System.Collections.Generic;

namespace SMS.MvcApplication.Models
{
    public class AdminModel<TDto>
    {
        public IList<TDto> ListRecord { get; set; }
        public bool CanEdit { get; set; }
        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
}