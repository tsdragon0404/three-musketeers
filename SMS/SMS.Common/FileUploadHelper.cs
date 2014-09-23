using System.IO;
using System.Web;
using SMS.Common.Enums;
using SMS.Common.Session;

namespace SMS.Common
{
    public class FileUploadHelper
    {
        public static FileUploadReturn Upload(HttpPostedFileBase uploadedFile, UploadedFileCategory category, bool overwrite = true)
        {
            if (uploadedFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(uploadedFile.FileName);
                if (fileName == null)
                    return new FileUploadReturn { Success = false };

                if(category == UploadedFileCategory.ProfileImage)
                {
                    var extension = fileName.Remove(0, fileName.LastIndexOf('.'));
                    fileName = SmsSystem.UserContext.UserID + extension;
                }

                var path = BuildFilePath(category, fileName);
                if (File.Exists(path))
                {
                    if (overwrite)
                        File.Delete(path);
                    else
                        return new FileUploadReturn { Success = false };
                }

                uploadedFile.SaveAs(path);

                return new FileUploadReturn { Success = true, ActualPath = path };
            }
            return new FileUploadReturn { Success = false };
        } 

        private static string BuildFilePath(UploadedFileCategory category, string filename)
        {
            var dir = Path.Combine(
                Storage.SystemInformation.SystemInfos.Data[Constant.ConstKey.SystemInfo_FileUploadPath],
                category.ToString());

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            return Path.Combine(dir, filename);
        }
    }

    public class FileUploadReturn
    {
        public bool Success { get; set; }
        public string ActualPath { get; set; }
    }
}