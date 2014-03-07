using Core.Data;

namespace FMS.Entities
{
    public class Section : Entity<long>
    {
        public virtual string Name { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
