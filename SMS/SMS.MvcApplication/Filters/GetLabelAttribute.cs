using System.Web.Mvc;

namespace SMS.MvcApplication.Filters
{
    public sealed class GetLabelAttribute : ActionFilterAttribute
    {
        public int PageID { get; private set; }

        public GetLabelAttribute(int pageID)
        {
            PageID = pageID;
        }
    }
}