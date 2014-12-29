using SMS.Common.Paging;

namespace SMS.MvcApplication.Models
{
    public class AdminModel<TDto>
    {
        public IPagedList<TDto> ListRecord { get; set; }
        public bool CanEdit { get; set; }
        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
    }
}