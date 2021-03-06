﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Common.Validation;
using SMS.Common.Constant;
using SMS.Common.Enums;
using SMS.Common.Storage;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class PageManagement : BaseManagement<PageDto, Page, IPageRepository>, IPageManagement
    {
        #region Fields

        public IUserRepository UserRepository { get; set; }

        #endregion

        private ServiceResult<IList<TModel>> GetPagesByTypes<TModel>(params PageType[] types)
        {
            if(types == null || !types.Any())
                return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(new List<Page>()));

            var result = Repository.List(x => types.Contains(x.Type) && x.Enable).ToList();
            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public ServiceResult<IList<PageDto>> GetProtectedPages()
        {
            return GetProtectedPages<PageDto>();
        }

        public ServiceResult<IList<TModel>> GetProtectedPages<TModel>()
        {
            var result = Repository.List(x => x.Type == PageType.Protected && x.Controller != null && x.Controller.Trim() != string.Empty && x.Enable).ToList();
            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public ServiceResult<IList<PageDto>> GetPublicPages()
        {
            return GetPublicPages<PageDto>();
        }

        public ServiceResult<IList<TModel>> GetPublicPages<TModel>()
        {
            var result = Repository.List(x => x.Type == PageType.Public && x.Controller != null && x.Controller.Trim() != string.Empty && x.Enable).ToList();
            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public ServiceResult<IList<PageDto>> GetAccessiblePagesForUser(long userID)
        {
            return GetAccessiblePagesForUser<PageDto>(userID);
        }

        public ServiceResult<IList<TModel>> GetAccessiblePagesForUser<TModel>(long userID)
        {
            if (userID == 0)
                return GetPagesByTypes<TModel>(PageType.Public);

            var user = UserRepository.GetByID(userID);

            if (user.IsSystemAdmin)
                return GetPagesByTypes<TModel>(PageType.Public, PageType.Protected, PageType.System);

            var accessiblePageIds = new List<long>();
            foreach (var role in user.Roles.Where(x => x.Enable))
                accessiblePageIds.AddRange(role.Pages.Where(x => !ExcludedPages.Contains(x.ID)).Select(x => x.ID));

            accessiblePageIds = accessiblePageIds.Distinct().ToList();

            var result = Repository.List(x => x.Enable && (accessiblePageIds.Contains(x.ID) 
                                           || x.Type == PageType.Public
                                           || (user.UseSystemConfig && x.Type == PageType.System))).ToList();

            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public ServiceResult<IList<PageDto>> GetPagesByIds(IList<long> ids)
        {
            return GetPagesByIds<PageDto>(ids);
        }

        public ServiceResult<IList<TModel>> GetPagesByIds<TModel>(IList<long> ids)
        {
            var result = Repository.List(x => ids.Contains(x.ID) && x.Enable).ToList();
            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        private IEnumerable<long> ExcludedPages
        {
            get
            {
                var pages = new List<long>();
                if (SmsCache.BranchConfigs.Current != null && !SmsCache.BranchConfigs.Current.UseKitchenFunction)
                    pages.Add(ConstPage.Kitchen);

                return pages;
            }
        }
    }
}