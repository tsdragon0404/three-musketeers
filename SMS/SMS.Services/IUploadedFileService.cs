using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IUploadedFileService : IBaseService<UploadedFileDto>
    {
        ServiceResult<UploadedFileDto> GetByPhysicalPath(string physicalPath);
    }
}