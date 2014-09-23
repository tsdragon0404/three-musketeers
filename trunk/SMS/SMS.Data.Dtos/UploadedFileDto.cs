using System;
using SMS.Common.Enums;

namespace SMS.Data.Dtos
{
    public class UploadedFileDto
    {
        public virtual long UploadedFileID { get; set; }

        public virtual UploadedFileCategory Category { get; set; }

        public virtual string PhysicalPath { get; set; }

        public virtual DateTime UploadedDateTime { get; set; }

        public virtual string UploadedBy { get; set; }
    }
}