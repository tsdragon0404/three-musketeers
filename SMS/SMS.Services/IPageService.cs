using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IPageService : IBaseService<PageDto, long>
    {
        ServiceResult<IList<PageDto>> GetProtectedPages();
        ServiceResult<IList<TModel>> GetProtectedPages<TModel>();
        ServiceResult<IList<PageDto>> GetAccessiblePagesForUser();
        ServiceResult<IList<TModel>> GetAccessiblePagesForUser<TModel>();
    }
}