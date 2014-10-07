using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Common.Enums;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class SystemInformationManagement : BaseManagement<SystemInformationDto, SystemInformation, long, ISystemInformationRepository>, ISystemInformationManagement
    {
        #region Fields

        #endregion

        public ServiceResult<IList<SystemInformationDto>> GetByType(SystemInformationType type)
        {
            var result = Repository.Find(x => x.Type == type);
            return ServiceResult<IList<SystemInformationDto>>.CreateSuccessResult(Mapper.Map<IList<SystemInformationDto>>(result));
        }
    }
}