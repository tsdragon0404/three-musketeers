using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IPageLabelService : IBaseService<PageLabelDto, long>
    {
        ServiceResult<IList<TDto>> GetByPageID<TDto>(long pageID, bool includeGlobalLabels = false);
        ServiceResult Save(long pageID, List<PageLabelDto> listLabels);
        ServiceResult Copy(long fromBranchID, long toBranchID);
    }
}