using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Common.Enums;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface ISystemInformationService : IBaseService<SystemInformationDto>
    {
        ServiceResult<IList<SystemInformationDto>> GetByType(SystemInformationType type);
        ServiceResult UpdateSystemConfig(SystemInformationDto[] systemInformations);
    }
}