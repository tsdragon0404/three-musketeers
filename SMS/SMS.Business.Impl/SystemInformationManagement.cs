using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Common.Enums;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class SystemInformationManagement : BaseManagement<SystemInformationDto, SystemInformation, ISystemInformationRepository>, ISystemInformationManagement
    {
        #region Fields

        #endregion

        public ServiceResult<IList<SystemInformationDto>> GetByType(SystemInformationType type)
        {
            var result = Repository.List(x => x.Type == type);
            return ServiceResult<IList<SystemInformationDto>>.CreateSuccessResult(Mapper.Map<IList<SystemInformationDto>>(result));
        }

        public ServiceResult UpdateSystemConfig(SystemInformationDto[] systemInformations)
        {
            var entities = Mapper.Map<SystemInformation[]>(systemInformations);
            Repository.UpdateSystemConfig(entities);
            return ServiceResult.CreateSuccessResult();
        }
    }
}