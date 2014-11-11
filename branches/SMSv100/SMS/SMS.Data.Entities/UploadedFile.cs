using System;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    public class UploadedFile : Entity
    {
        public virtual UploadedFileCategory Category { get; set; }

        public virtual string PhysicalPath { get; set; }

        public virtual DateTime UploadedDateTime { get; set; }

        public virtual string UploadedBy { get; set; }
    }
}