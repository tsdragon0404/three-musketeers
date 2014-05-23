using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IPageLabelManagement : IBaseManagement<PageLabelDto, long>
    {
        IList<TDto> GetByPageID<TDto>(int pageID);
    }
}