﻿using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IPageManagement : IBaseManagement<PageDto, long>
    {
        ServiceResult<IList<PageDto>> GetAllWithoutGlobal();
        ServiceResult<IList<PageDto>> GetAccessiblePagesForUser();
        ServiceResult<IList<TModel>> GetAccessiblePagesForUser<TModel>();
    }
}