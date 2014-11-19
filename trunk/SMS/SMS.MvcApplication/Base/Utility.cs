using System;
using System.Web;
using SMS.Common;
using SMS.Common.Enums;
using SMS.Common.Storage;
using SMS.Data.Dtos;
using SMS.Services;

namespace SMS.MvcApplication.Base
{
    public class Utility
    {
        public static long UploadFile(HttpPostedFileBase uploadedFile, UploadedFileCategory category)
        {
            var result = FileHelper.Upload(uploadedFile, category);
            if (!result.Success)
                return 0;

            var uploadedFileService = ServiceLocator.Resolve<IUploadedFileService>();
            var existingFile = uploadedFileService.GetByPhysicalPath(result.ActualPath);

            var dtoToSave = new UploadedFileDto
                                {
                                    PhysicalPath = result.ActualPath,
                                    Category = category,
                                    UploadedBy = SmsCache.UserContext.UserName,
                                    UploadedDateTime = DateTime.Now
                                };

            if(existingFile.Success && existingFile.Data != null)
                dtoToSave.UploadedFileID = existingFile.Data.UploadedFileID;

            var saveResult = uploadedFileService.Save(dtoToSave);

            if (!saveResult.Success || saveResult.Data == null)
                return 0;

            return saveResult.Data.UploadedFileID;
        }

        public static string GetCurrentUserProfileImage()
        {
            var imageData = FileHelper.GetProfileImageAsStream(SmsCache.UserContext.UserID);
            if (imageData == null) return string.Empty;
            return Convert.ToBase64String(imageData);
        }
    }
}