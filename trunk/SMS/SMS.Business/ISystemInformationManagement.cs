using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Common.Enums;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface ISystemInformationManagement : IBaseManagement<SystemInformationDto, long>
    {
        ServiceResult<IList<SystemInformationDto>> GetByType(SystemInformationType type);
    }
}