using System;
using Core.Data.PetaPoco;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    [TableName("UPLOADEDFILE")]
    [PrimaryKey("ID")]
    public class UploadedFile
    {
        public long ID { get; set; }
        public UploadedFileCategory Category { get; set; }
        public string PhysicalPath { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
    }
}