using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Common.Validation;
using SMS.Common.Session;
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
                Repository.Find(x => x.BranchID == SmsSystem.SelectedBranchID && x.Enable).OrderBy(x => x.SEQ).ToList();
            return ServiceResult<IList<TDto>>.CreateSuccessResult(!result.Any() ? null : Mapper.Map<IList<TDto>>(result));
        }
    }
}