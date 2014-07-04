using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class PageMenuManagement : BaseManagement<PageMenuDto, PageMenu, long, IPageMenuRepository>, IPageMenuManagement
    {
        #region Fields

        public IUserRepository UserRepository { get; set; }

        #endregion

        public ServiceResult<IList<PageMenuDto>> GetMenuByPageIds(IList<long> pageList)
        {
            var result = Repository.Find(x => pageList.Contains(x.PageID)).ToList();
            return ServiceResult<IList<PageMenuDto>>.CreateSuccessResult(Mapper.Map<IList<PageMenuDto>>(result));
        }
    }
}