using SMS.Common.Enums;

namespace SMS.Data.Dtos
{
    public class SystemInformationDto
    {
        public virtual long ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Value { get; set; }
        public virtual SystemInformationType Type { get; set; }
    }
}
