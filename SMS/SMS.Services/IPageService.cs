using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IPageService : IBaseService<PageDto>
    {
        ServiceResult<IList<PageDto>> GetProtectedPages();
        ServiceResult<IList<TModel>> GetProtectedPages<TModel>();
        ServiceResult<IList<PageDto>> GetPublicPages();
        ServiceResult<IList<TModel>> GetPublicPages<TModel>();
        ServiceResult<IList<PageDto>> GetAccessiblePagesForUser(long userID);
        ServiceResult<IList<TModel>> GetAccessiblePagesForUser<TModel>(long userID);
        ServiceResult<IList<PageDto>> GetPagesByIds(IList<long> ids);
        ServiceResult<IList<TModel>> GetPagesByIds<TModel>(IList<long> ids);
    }
}