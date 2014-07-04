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

        public ServiceResult<IList<ErrorMessageDto>> GetMessagesForSelectedBranch()
        {
            return ServiceResult<IList<ErrorMessageDto>>.CreateSuccessResult(
                Mapper.Map<IList<ErrorMessageDto>>(Repository.Find(x => x.BranchID == SmsSystem.SelectedBranchID && x.ID > 0).ToList()));
       
        }
        public ServiceResult<IList<TModel>> GetMessagesForSelectedBranch<TModel>()
        {
            return ServiceResult<IList<TModel>>.CreateSuccessResult(
                Mapper.Map<IList<TModel>>(Repository.Find(x => x.BranchID == SmsSystem.SelectedBranchID && x.ID > 0).ToList()));
        }

        public ServiceResult<IList<ErrorMessageDto>> GetSystemMessages()
        {
            return ServiceResult<IList<ErrorMessageDto>>.CreateSuccessResult(
                Mapper.Map<IList<ErrorMessageDto>>(Repository.Find(x => x.ID < 0).ToList()));

        }
        public ServiceResult<IList<TModel>> GetSystemMessages<TModel>()
        {
            return ServiceResult<IList<TModel>>.CreateSuccessResult(
                Mapper.Map<IList<TModel>>(Repository.Find(x => x.ID < 0).ToList()));
        }
    }
}