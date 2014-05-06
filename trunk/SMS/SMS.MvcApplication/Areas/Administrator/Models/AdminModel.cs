using SMS.Common.Paging;

namespace SMS.MvcApplication.Areas.Administrator.Models
{
    public class AdminModel<TDto>
    {
        public IPagedList<TDto> ListRecord { get; set; }
        public SortingPagingInfo PagingInfo { get; set; }
    }
}