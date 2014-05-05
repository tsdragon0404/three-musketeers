using System.Collections.Generic;

namespace SMS.Services
{
    public interface IBaseService<TDto, in TPrimaryKey>
    {
        IList<TDto> GetAll();
        TDto GetByID(TPrimaryKey ID);
        bool Save(TDto Dto);
        bool Delete(TPrimaryKey ID);
    }
}