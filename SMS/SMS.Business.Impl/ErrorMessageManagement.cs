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
    public class ErrorMessageManagement : BaseManagement<ErrorMessageDto, ErrorMessage, long, IErrorMessageRepository>, IErrorMessageManagement
    {
        #region Fields

        #endregion

        public override ServiceResult<IList<ErrorMessageDto>> GetAll()
        {
            return new ServiceResult<IList<ErrorMessageDto>>
                       {
                           Data = Mapper.Map<IList<ErrorMessageDto>>(Repository.Find(x => x.BranchID == UserContext.BranchID).ToList())
                       };
        }
        public override ServiceResult<IList<TModel>> GetAll<TModel>()
        {
            return new ServiceResult<IList<TModel>>
                       {
                           Data = Mapper.Map<IList<TModel>>(Repository.Find(x => x.BranchID == UserContext.BranchID).ToList())
                       };
        }
    }
}