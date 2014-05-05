using System.Collections.Generic;

namespace SMS.Business
{
    public interface IBaseManagement<TDto, in TPrimaryKey>
    {
        IList<TDto> GetAll();
        TDto GetByID(TPrimaryKey ID);
        bool Save(TDto Dto);
        bool Delete(TPrimaryKey ID); 
    }
}