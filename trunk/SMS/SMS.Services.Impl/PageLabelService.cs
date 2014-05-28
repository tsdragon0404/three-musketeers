using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class PageLabelService : BaseService<PageLabelDto, long, IPageLabelManagement>, IPageLabelService
    {
        #region Fields

        #endregion

        public IList<TDto> GetByPageID<TDto>(int pageID)
        {
            return Management.GetByPageID<TDto>(pageID);
        }

        public bool Save(int pageID, string labelID, string text)
        {
            return Management.Save(pageID, labelID, text);
        }

        public bool Save(int pageID, List<PageLabelDto> listLabels)
        {
            return Management.Save(pageID, listLabels);
        }
    }
}