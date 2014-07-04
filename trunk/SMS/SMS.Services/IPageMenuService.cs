using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IPageMenuService : IBaseService<PageMenuDto, long>
    {
        ServiceResult<IList<PageMenuDto>>  GetMenuByPageIds(IList<long> pageList);
    }
}