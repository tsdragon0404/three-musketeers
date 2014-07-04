using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IPageMenuManagement : IBaseManagement<PageMenuDto, long>
    {
        ServiceResult<IList<PageMenuDto>> GetMenuByPageIds(IList<long> pageList);
    }
}