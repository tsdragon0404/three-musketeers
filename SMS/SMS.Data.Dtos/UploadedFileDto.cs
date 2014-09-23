using System;
using SMS.Common.Enums;

namespace SMS.Data.Dtos
{
    public class UploadedFileDto
    {
        public virtual long UploadedFileID { get; set; }

        public virtual UploadedFileType Type { get; set; }

        public virtual string Name { get; set; }

        public virtual string Extension { get; set; }

        public virtual DateTime UploadedDateTime { get; set; }

        public virtual string UploadedBy { get; set; }
    }
}