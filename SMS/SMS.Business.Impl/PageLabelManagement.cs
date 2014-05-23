using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class PageLabelManagement : BaseManagement<PageLabelDto, PageLabel, long, IPageLabelRepository>, IPageLabelManagement
    {
        #region Fields

        #endregion

        public IList<TDto> GetByPageID<TDto>(int pageID)
        {
            var a = Repository.Find(x => x.Page.ID == pageID).ToList();
            return Mapper.Map<IList<PageLabel>, IList<TDto>>(a);
        }
    }
}