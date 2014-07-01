using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Common.Validation;
using SMS.Common.Constant;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class PageManagement : BaseManagement<PageDto, Page, long, IPageRepository>, IPageManagement
    {
        #region Fields

        #endregion

        public ServiceResult<IList<PageDto>> GetAllWithoutGlobal()
        {
            var result = Repository.Find(x => x.ID != ConstPage.Global).ToList();
            return ServiceResult<IList<PageDto>>.CreateSuccessResult(Mapper.Map<IList<PageDto>>(result));
        }
    }
}