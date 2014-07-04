using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IErrorMessageManagement : IBaseManagement<ErrorMessageDto, long>
    {
        ServiceResult<IList<ErrorMessageDto>> GetMessagesForSelectedBranch();
        ServiceResult<IList<TModel>> GetMessagesForSelectedBranch<TModel>();
        ServiceResult<IList<ErrorMessageDto>> GetSystemMessages();
        ServiceResult<IList<TModel>> GetSystemMessages<TModel>();
    }
}