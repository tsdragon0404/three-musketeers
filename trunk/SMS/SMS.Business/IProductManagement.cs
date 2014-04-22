using System.Collections.Generic;

namespace SMS.Business
{
    public interface IProductManagement
    {
        IList<T> GetAllProducts<T>();
        T GetProductById<T>(long id);
    }
}