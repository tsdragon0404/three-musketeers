﻿using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class PageService : BaseService<PageDto, long, IPageManagement>, IPageService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<PageDto>> GetAllWithoutGlobal()
        {
            return Management.GetAllWithoutGlobal();
        }
    }
}