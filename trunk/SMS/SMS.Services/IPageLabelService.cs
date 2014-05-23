using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IPageLabelService : IBaseService<PageLabelDto, long>
    {
        IList<TDto> GetByPageID<TDto>(int pageID);
    }
}