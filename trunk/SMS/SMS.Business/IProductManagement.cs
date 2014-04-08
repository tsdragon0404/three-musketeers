using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IProductManagement
    {
        IList<ProductDto> GetAllProducts();
    }
}