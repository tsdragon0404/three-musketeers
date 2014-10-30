using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IPageLabelManagement : IBaseManagement<PageLabelDto, long>
    {
        ServiceResult<IList<TDto>> GetByPageID<TDto>(long pageID, bool includeGlobalLabels = false);
        ServiceResult Save(long pageID, List<PageLabelDto> listLabels);
        ServiceResult Copy(long fromBranchID, long toBranchID);
    }
}