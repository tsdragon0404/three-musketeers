using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class PageMenuService : BaseService<PageMenuDto, long, IPageMenuManagement>, IPageMenuService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<PageMenuDto>> GetMenuByPageIds(IList<long> pageList)
        {
            return Management.GetMenuByPageIds(pageList);
        }
    }
}