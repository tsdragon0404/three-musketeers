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
    public class ErrorMessageManagement : BaseManagement<ErrorMessageDto, ErrorMessage, long, IErrorMessageRepository>, IErrorMessageManagement
    {
        #region Fields

        #endregion

        public override ServiceResult<IList<ErrorMessageDto>> GetAll()
        {
            return ServiceResult<IList<ErrorMessageDto>>.CreateSuccessResult(
                Mapper.Map<IList<ErrorMessageDto>>(Repository.Find(x => x.BranchID == SmsSystem.UserContext.BranchID).ToList()));
       
        }
        public override ServiceResult<IList<TModel>> GetAll<TModel>()
        {
            return ServiceResult<IList<TModel>>.CreateSuccessResult(
                Mapper.Map<IList<TModel>>(Repository.Find(x => x.BranchID == SmsSystem.UserContext.BranchID).ToList()));
        }
    }
}