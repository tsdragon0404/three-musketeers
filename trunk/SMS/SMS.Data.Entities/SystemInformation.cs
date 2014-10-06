using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    public class SystemInformation : Entity
    {
        public virtual string Name { get; set; }

        public virtual string Value { get; set; }

        public virtual SystemInformationType Type { get; set; }
    }
}
