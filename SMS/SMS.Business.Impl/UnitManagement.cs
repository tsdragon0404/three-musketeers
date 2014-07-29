﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Common.Validation;
using SMS.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class UnitManagement : BaseManagement<UnitDto, Unit, long, IUnitRepository>, IUnitManagement
    {
        #region Fields

        #endregion

        public ServiceResult<IList<TDto>> GetAllByBranch<TDto>()
        {
            var result =
                Repository.Find(x => x.BranchID == SmsSystem.SelectedBranchID && x.Enable).ToList();
            return ServiceResult<IList<TDto>>.CreateSuccessResult(Mapper.Map<IList<TDto>>(result));
        }
    }
}