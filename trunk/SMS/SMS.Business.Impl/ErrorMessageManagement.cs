using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public ServiceResult<IList<ErrorMessageDto>> GetSystemMessages()
        {
            return GetSystemMessages<ErrorMessageDto>();

        }
        public ServiceResult<IList<TModel>> GetSystemMessages<TModel>()
        {
            return ServiceResult<IList<TModel>>.CreateSuccessResult(
                Mapper.Map<IList<TModel>>(Repository.Find(x => x.ID < 0).ToList()));
        }
    }
}