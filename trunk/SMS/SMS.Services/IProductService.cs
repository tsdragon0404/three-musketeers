using System.Collections.Generic;

namespace SMS.Services
{
    public interface IProductService
    {
        IList<T> GetAllProducts<T>();
        T GetProductById<T>(long id);
    }
}