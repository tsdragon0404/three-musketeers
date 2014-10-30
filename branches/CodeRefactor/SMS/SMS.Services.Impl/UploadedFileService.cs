using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class UploadedFileService : BaseService<UploadedFileDto, long, IUploadedFileManagement>, IUploadedFileService
    {
        #region Fields

        #endregion

        public ServiceResult<UploadedFileDto> GetByPhysicalPath(string physicalPath)
        {
            return Management.GetByPhysicalPath(physicalPath);
        }
    }
}