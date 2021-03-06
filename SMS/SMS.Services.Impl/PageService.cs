﻿using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class PageService : BaseService<PageDto, IPageManagement>, IPageService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<PageDto>> GetProtectedPages()
        {
            return Management.GetProtectedPages();
        }

        public ServiceResult<IList<TModel>> GetProtectedPages<TModel>()
        {
            return Management.GetProtectedPages<TModel>();
        }

        public ServiceResult<IList<PageDto>> GetPublicPages()
        {
            return Management.GetPublicPages();
        }

        public ServiceResult<IList<TModel>> GetPublicPages<TModel>()
        {
            return Management.GetPublicPages<TModel>();
        }
        public ServiceResult<IList<PageDto>> GetAccessiblePagesForUser(long userID)
        {
            return Management.GetAccessiblePagesForUser(userID);
        }

        public ServiceResult<IList<TModel>> GetAccessiblePagesForUser<TModel>(long userID)
        {
            return Management.GetAccessiblePagesForUser<TModel>(userID);
        }

        public ServiceResult<IList<PageDto>> GetPagesByIds(IList<long> ids)
        {
            return Management.GetPagesByIds(ids);
        }

        public ServiceResult<IList<TModel>> GetPagesByIds<TModel>(IList<long> ids)
        {
            return Management.GetPagesByIds<TModel>(ids);
        }
    }
}