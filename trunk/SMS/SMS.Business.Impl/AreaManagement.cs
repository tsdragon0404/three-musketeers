using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Common.Session;
using Core.Common.Validation;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class AreaManagement : BaseManagement<AreaDto, Area, long, IAreaRepository>, IAreaManagement
    {
        #region Fields

        #endregion

        public ServiceResult<IList<TDto>> GetAllByBranch<TDto>()
        {
            var result =
                Repository.Find(x => x.BranchID == UserContext.BranchID && x.Enable).OrderBy(x => x.SEQ).ToList();
            return new ServiceResult<IList<TDto>> { Data = !result.Any() ? null : Mapper.Map<IList<TDto>>(result) };
        }
    }
}