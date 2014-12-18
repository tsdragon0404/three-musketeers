using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class PageLabelService : BaseService<PageLabelDto, IPageLabelManagement>, IPageLabelService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<TDto>> GetByPageID<TDto>(long pageID, bool includeGlobalLabels = false)
        {
            return Management.GetByPageID<TDto>(pageID, includeGlobalLabels);
        }

        public ServiceResult Save(List<PageLabelDto> listLabels)
        {
            return Management.Save(listLabels);
        }
    }
}