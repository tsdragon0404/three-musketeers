using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class ProductManagement : IProductManagement
    {
        #region Fields

        public virtual IProductRepository ProductRepository { get; set; }

        #endregion

        public IList<T> GetAllProducts<T>()
        {
            return Mapper.Map<IList<T>>(ProductRepository.GetAll().ToList());
        }

        public T GetProductById<T>(long id)
        {
            return Mapper.Map<T>(ProductRepository.Get(id));
        }
    }
}