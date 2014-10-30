namespace SMS.Common.Paging
{
    public class Page
    {
        /// <summary>
        /// CurrentPage
        /// </summary>
        public int Cp { get; set; }
        /// <summary>
        /// Old Page
        /// </summary>
        public int Op { get; set; }
        /// <summary>
        /// SortColumnName
        /// </summary>
        public string Sc { get; set; }
        /// <summary>
        /// OldSortColumnName
        /// </summary>
        public string Osc { get; set; }
        /// <summary>
        /// SortType
        /// </summary>
        public bool St { get; set; }
        /// <summary>
        /// PageSize
        /// </summary>
        public int Ps { get; set; }
        /// <summary>
        /// PageCount
        /// </summary>
        public int Pc { get; set; }
        /// <summary>
        /// TotalItemCount
        /// </summary>
        public int Tic{ get; set; }
        /// <summary>
        /// FormNameSubmitted
        /// </summary>
        public string Fns { get; set; }
    }
}
