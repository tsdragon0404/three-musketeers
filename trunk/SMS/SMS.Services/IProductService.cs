using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IProductService
    {
        IList<T> GetAllProducts<T>();
        ProductForCashierDto GetProductById(long id);
    }
}