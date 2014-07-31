using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class BranchManagement : BaseManagement<BranchDto, Data.Entities.Branch, long, IBranchRepository>, IBranchManagement
    {
        #region Fields

        #endregion

        #region Func

        public override Func<Data.Entities.Branch, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.ID == y;
            }
        }

        #endregion

        public ServiceResult<IList<TModel>> GetUserAssignedBranches<TModel>(long userID)
        {
            if(userID == 0)
                return ServiceResult<IList<TModel>>.CreateSuccessResult(new List<TModel>());

            var result = Repository.Find(x => (x.Users.Select(y => y.ID).Contains(userID) && x.Enable)).ToList();
            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }
    }
}