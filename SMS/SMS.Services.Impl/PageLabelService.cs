using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class PageLabelService : BaseService<PageLabelDto, long, IPageLabelManagement>, IPageLabelService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<TDto>> GetByPageID<TDto>(int pageID)
        {
            return Management.GetByPageID<TDto>(pageID);
        }

        public ServiceResult Save(int pageID, List<PageLabelDto> listLabels)
        {
            return Management.Save(pageID, listLabels);
        }
    }
}