using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class PageMenuManagement : BaseManagement<PageMenuDto, PageMenu, IPageMenuRepository>, IPageMenuManagement
    {
        #region Fields

        public IUserRepository UserRepository { get; set; }

        #endregion

        public ServiceResult<IList<PageMenuDto>> GetMenuByPageIds(IList<long> pageList)
        {
            var menus = Mapper.Map<IList<PageMenuDto>>(Repository.ListAll());
            var result = menus.Where(x => pageList.Contains(x.PageID)).ToList();

            for (var i = 0; i < result.Count; i++)
            {
                if (result[i].ParentID == 0) continue;
                if (result.Any(x => x.ID == result[i].ParentID)) continue;

                var menu = menus.FirstOrDefault(x => x.ID == result[i].ParentID);
                if(menu != null)
                    result.Add(menu);
            }

            return ServiceResult<IList<PageMenuDto>>.CreateSuccessResult(result);
        }
    }
}