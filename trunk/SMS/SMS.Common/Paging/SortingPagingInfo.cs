namespace SMS.Common.Paging
{
    public class SortingPagingInfo
    {
        private int _currentPage;
        public int CurrentPage 
        { 
            get { return _currentPage; }
            set { _currentPage = value <= 0 ? 1 : value; }
        }
        //public int OldPage { get; set; }
        //public string SortColumnName { get; set; }
        //public string OldSortColumnName { get; set; }
        //public bool SortType { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int TotalItemCount { get; set; }
    }
}
