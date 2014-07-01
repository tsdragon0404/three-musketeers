﻿using SMS.Common.Paging;

namespace SMS.MvcApplication.Models
{
    public class AdminModel<TDto>
    {
        public IPagedList<TDto> ListRecord { get; set; }
        public SortingPagingInfo PagingInfo { get; set; }
    }
}