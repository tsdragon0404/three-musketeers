using TM.Data;

namespace RMS.Core.Entities
{
    public class ProductCategory : Entity<int>
    {
        [DataField("Name")]
        public virtual string Name { get; set; }
    }
}
