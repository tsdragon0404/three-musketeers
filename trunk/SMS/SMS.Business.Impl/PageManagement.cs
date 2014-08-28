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

        public ServiceResult<IList<PageDto>> GetProtectedPages()
        {
            return GetProtectedPages<PageDto>();
        }

        public ServiceResult<IList<TModel>> GetProtectedPages<TModel>()
        {
            var result = Repository.Find(x => !ConstPage.PublicPages.Contains(x.ID) && !ExcludedPages.Contains(x.ID)).ToList();
            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public ServiceResult<IList<PageDto>> GetAccessiblePagesForUser()
        {
            return GetAccessiblePagesForUser<PageDto>();
        }

        public ServiceResult<IList<TModel>> GetAccessiblePagesForUser<TModel>()
        {
            if (SmsSystem.UserContext.UserID == 0)
                return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(new List<Page>()));

            if (SmsSystem.UserContext.IsSystemAdmin)
                return GetProtectedPages<TModel>();

            var user = UserRepository.Get(SmsSystem.UserContext.UserID);
            var accessiblePageIds = new List<long>();

            foreach (var role in user.Roles)
                accessiblePageIds.AddRange(role.Pages.Where(x => !ConstPage.PublicPages.Contains(x.ID) && !ExcludedPages.Contains(x.ID)).Select(x => x.ID));
            accessiblePageIds = accessiblePageIds.Distinct().ToList();

            var result = Repository.Find(x => accessiblePageIds.Contains(x.ID)).ToList();
            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        private IEnumerable<long> ExcludedPages
        {
            get
            {
                var pages = new List<long>();
                if(SmsSystem.BranchConfig != null && !SmsSystem.BranchConfig.UseKitchenFunction)
                    pages.Add(ConstPage.Kitchen);

                return pages;
            }
        }
    }
}