using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IErrorMessageService : IBaseService<ErrorMessageDto, long>
    {
        ServiceResult<IList<ErrorMessageDto>> GetMessagesForSelectedBranch();
        ServiceResult<IList<TModel>> GetMessagesForSelectedBranch<TModel>();
    }
}