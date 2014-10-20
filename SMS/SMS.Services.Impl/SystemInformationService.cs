using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Common.Enums;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class SystemInformationService : BaseService<SystemInformationDto, long, ISystemInformationManagement>, ISystemInformationService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<SystemInformationDto>> GetByType(SystemInformationType type)
        {
            return Management.GetByType(type);
        }

        public ServiceResult UpdateSystemConfig(SystemInformationDto[] systemInformations)
        {
            return Management.UpdateSystemConfig(systemInformations);
        }
    }
}