using SMS.Common.Enums;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class UploadedFileMap : BaseMap<UploadedFile>
    {
        public UploadedFileMap()
        {
            Table("UploadedFile");
            Map(x => x.Category).CustomType<UploadedFileCategory>();
            Map(x => x.PhysicalPath);
            Map(x => x.UploadedDateTime);
            Map(x => x.UploadedBy);
        }
    }
}