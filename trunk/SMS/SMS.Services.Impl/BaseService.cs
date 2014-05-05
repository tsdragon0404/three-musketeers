using System.Collections.Generic;
using SMS.Business;

namespace SMS.Services.Impl
{
    public class BaseService<TDto, TPrimaryKey, TIManagement> : IBaseService<TDto, TPrimaryKey> where TIManagement : IBaseManagement<TDto, TPrimaryKey>
    {
        public virtual TIManagement Management { get; set; }
        public IList<TDto> GetAll()
        {
            return Management.GetAll();
        }

        public TDto GetByID(TPrimaryKey ID)
        {
            return Management.GetByID(ID);
        }

        public bool Save(TDto Dto)
        {
            return Management.Save(Dto);
        }

        public bool Delete(TPrimaryKey ID)
        {
            return Management.Delete(ID);
        }
    }
}
