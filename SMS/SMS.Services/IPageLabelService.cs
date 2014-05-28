using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IPageLabelService : IBaseService<PageLabelDto, long>
    {
        IList<TDto> GetByPageID<TDto>(int pageID);
        bool Save(int pageID, string labelID, string text);
        bool Save(int pageID, List<PageLabelDto> listLabels);
    }
}