using Core.Data.PetaPoco;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    [TableName("SYSTEMINFORMATION")]
    [PrimaryKey("ID")]
    public class SystemInformation
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public SystemInformationType Type { get; set; }
    }
}
