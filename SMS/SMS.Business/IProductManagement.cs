using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IProductManagement
    {
        IList<T> GetAllProducts<T>();
        IList<SearchProductPopupDto> SearchProducts(string textSearch);
        ProductForCashierDto GetProductById(long id);
    }
}