﻿using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using SMS.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class BranchManagement : BaseManagement<BranchDto, Data.Entities.Branch, long, IBranchRepository>, IBranchManagement
    {
        #region Fields

        #endregion

        public ServiceResult<IList<TModel>> GetAssignedBranchesForUser<TModel>()
        {
            var result = Repository.Find(x => 
                (x.Users.Select(y => y.ID).Contains(SmsSystem.UserContext.UserID) && x.Enable) 
                || SmsSystem.UserContext.IsSystemAdmin).ToList();

            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }
    }
}