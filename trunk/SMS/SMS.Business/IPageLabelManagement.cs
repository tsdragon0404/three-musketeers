using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IPageLabelManagement : IBaseManagement<PageLabelDto, long>
    {
        ServiceResult<IList<TDto>> GetByPageID<TDto>(int pageID, bool includeGlobalLabels = false);
        ServiceResult Save(int pageID, List<PageLabelDto> listLabels);
        ServiceResult Copy(long fromBranchID, long toBranchID);
    }
}