using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IPageLabelService : IBaseService<PageLabelDto, long>
    {
        ServiceResult<IList<TDto>> GetByPageID<TDto>(int pageID);
        ServiceResult Save(int pageID, List<PageLabelDto> listLabels);
        ServiceResult Copy(long fromBranchID, long toBranchID);
    }
}