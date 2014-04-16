using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface ISearchPopupService
    {
        IList<SearchProductPopupDto> ProductsForCashier(string textSearch = "");
    }
}