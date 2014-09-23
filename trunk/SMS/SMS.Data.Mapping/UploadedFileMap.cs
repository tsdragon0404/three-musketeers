using SMS.Common.Enums;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class UploadedFileMap : BaseMap<UploadedFile>
    {
        public UploadedFileMap()
        {
            Table("UploadedFile");
            Map(x => x.Type).CustomType<UploadedFileType>();
            Map(x => x.Name);
            Map(x => x.Extension);
            Map(x => x.UploadedDateTime);
            Map(x => x.UploadedBy);
        }
    }
}