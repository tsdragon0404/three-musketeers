using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Common.Validation;
using SMS.Common.Constant;
using SMS.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class PageManagement : BaseManagement<PageDto, Page, long, IPageRepository>, IPageManagement
    {
        #region Fields

        public IUserRepository UserRepository { get; set; }

        #endregion

        public ServiceResult<IList<PageDto>> GetAllWithoutGlobal()
        {
            var result = Repository.Find(x => x.ID != ConstPage.Global).ToList();
            return ServiceResult<IList<PageDto>>.CreateSuccessResult(Mapper.Map<IList<PageDto>>(result));
        }

        public ServiceResult<IList<PageDto>> GetAccessiblePagesForUser()
        {
            return GetAccessiblePagesForUser<PageDto>();
        }

        public ServiceResult<IList<TModel>> GetAccessiblePagesForUser<TModel>()
        {
            if (SmsSystem.UserContext.UserID == 0)
            {
                var resultNotLogin = Repository.Find(x => x.ID == ConstPage.HomePage).ToList();
                return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(resultNotLogin));
            }

            if (SmsSystem.UserContext.IsSystemAdmin)
            {
                var resultSystemAdmin = Repository.Find(x => x.ID != ConstPage.Global).ToList();
                return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(resultSystemAdmin));
            }

            var user = UserRepository.Get(SmsSystem.UserContext.UserID);
            var accessiblePageIds = new List<long>();

            foreach (var role in user.Roles)
                accessiblePageIds.AddRange(role.Pages.Select(x => x.ID));
            accessiblePageIds = accessiblePageIds.Distinct().ToList();

            var result = Repository.Find(x => accessiblePageIds.Contains(x.ID)).ToList();
            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }
    }
}