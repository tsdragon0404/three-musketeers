using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IPageLabelService : IBaseService<PageLabelDto>
    {
        ServiceResult<IList<TDto>> GetByPageID<TDto>(long pageID, bool includeGlobalLabels = false);
        ServiceResult Save(List<PageLabelDto> listLabels);
    }
}