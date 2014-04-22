using System.Collections.Generic;
using SMS.Business;

namespace SMS.Services.Impl
{
    public class ProductService : IProductService
    {
        #region Fields

        public virtual IProductManagement ProductManagement { get; set; }

        #endregion

        public IList<T> GetAllProducts<T>()
        {
            return ProductManagement.GetAllProducts<T>();
        }

        public T GetProductById<T>(long id)
        {
            return ProductManagement.GetProductById<T>(id);
        }
    }
}