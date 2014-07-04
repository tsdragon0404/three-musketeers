using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class ErrorMessageService : BaseService<ErrorMessageDto, long, IErrorMessageManagement>, IErrorMessageService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<ErrorMessageDto>> GetMessagesForSelectedBranch()
        {
            return Management.GetMessagesForSelectedBranch();
        }

        public ServiceResult<IList<TModel>> GetMessagesForSelectedBranch<TModel>()
        {
            return Management.GetMessagesForSelectedBranch<TModel>();
        }

        public ServiceResult<IList<ErrorMessageDto>> GetSystemMessages()
        {
            return Management.GetSystemMessages();
        }

        public ServiceResult<IList<TModel>> GetSystemMessages<TModel>()
        {
            return Management.GetSystemMessages<TModel>();
        }
    }
}