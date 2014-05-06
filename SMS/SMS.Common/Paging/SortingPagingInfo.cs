namespace SMS.Common.Paging
{
    public class SortingPagingInfo
    {
        public int CurrentPage { get; set; }
        //public int OldPage { get; set; }
        //public string SortColumnName { get; set; }
        //public string OldSortColumnName { get; set; }
        //public bool SortType { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int TotalItemCount { get; set; }

        public SortingPagingInfo()
        {
            CurrentPage = 1;
        }
    }
}
