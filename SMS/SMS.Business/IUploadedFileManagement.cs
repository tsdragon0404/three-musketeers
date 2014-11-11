using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IUploadedFileManagement : IBaseManagement<UploadedFileDto>
    {
        ServiceResult<UploadedFileDto> GetByPhysicalPath(string physicalPath);
    }
}