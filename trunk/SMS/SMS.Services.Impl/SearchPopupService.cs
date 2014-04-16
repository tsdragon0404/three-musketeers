using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class SearchPopupService : ISearchPopupService
    {
        #region Fields

        public virtual IProductManagement ProductManagement { get; set; }

        #endregion

        public IList<SearchProductPopupDto> ProductsForCashier(string textSearch = "")
        {
            return ProductManagement.SearchProducts(textSearch);
        }
    }
}