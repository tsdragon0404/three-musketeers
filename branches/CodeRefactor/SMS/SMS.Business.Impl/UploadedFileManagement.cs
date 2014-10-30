using Core.Common.Validation;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class UploadedFileManagement : BaseManagement<UploadedFileDto, UploadedFile, IUploadedFileRepository>, IUploadedFileManagement
    {
        #region Fields

        #endregion

        public ServiceResult<UploadedFileDto> GetByPhysicalPath(string physicalPath)
        {
            var result = Repository.Get(x => x.PhysicalPath.ToLower() == physicalPath.ToLower());
            return result == null 
                ? ServiceResult<UploadedFileDto>.CreateFailResult() 
                : ServiceResult<UploadedFileDto>.CreateSuccessResult(Mapper.Map<UploadedFileDto>(result));
        }
    }
}