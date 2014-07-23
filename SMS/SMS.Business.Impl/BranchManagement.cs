using System.Collections.Generic;
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

        public ServiceResult<IList<TModel>> GetUserAssignedBranches<TModel>(long id)
        {
            if(id == 0)
                return ServiceResult<IList<TModel>>.CreateSuccessResult(new List<TModel>());

            var result = Repository.Find(x => (x.Users.Select(y => y.ID).Contains(id) && x.Enable)).ToList();
            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }
    }
}