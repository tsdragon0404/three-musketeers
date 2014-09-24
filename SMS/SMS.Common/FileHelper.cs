using System.IO;
using System.Web;
using SMS.Common.Enums;
using SMS.Common.Session;

namespace SMS.Common
{
    public class FileHelper
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
                    DeleteOldProfileImages();
                }

                var path = GetFilePath(category, fileName);
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

        public static byte[] GetProfileImageAsStream(long userID)
        {
            var folder = new DirectoryInfo(GetFolderPath(UploadedFileCategory.ProfileImage));
            var listfiles = folder.GetFiles(string.Format("{0}.*", SmsSystem.UserContext.UserID));
            if (listfiles.Length > 0)
            {
                var fileStream = new FileStream(listfiles[0].FullName, FileMode.Open, FileAccess.Read);
                var data = new byte[(int)fileStream.Length];
                fileStream.Read(data, 0, data.Length);
                return data;
            }

            return null;
        }

        private static string GetFilePath(UploadedFileCategory category, string filename)
        {
            return Path.Combine(GetFolderPath(category), filename);
        }

        private static string GetFolderPath(UploadedFileCategory category)
        {
            var dir = Path.Combine(
                Storage.SystemInformation.SystemInfos.Data[Constant.ConstKey.SystemInfo_FileUploadPath],
                category.ToString());

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }

        private static void DeleteOldProfileImages()
        {
            var folder = new DirectoryInfo(GetFolderPath(UploadedFileCategory.ProfileImage));
            var listfiles = folder.GetFiles(string.Format("{0}.*", SmsSystem.UserContext.UserID));
            foreach (var file in listfiles)
                File.Delete(file.FullName);
        }
    }

    public class FileUploadReturn
    {
        public bool Success { get; set; }
        public string ActualPath { get; set; }
    }
}