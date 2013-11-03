using TM.Data;

namespace RMS.Core.Entities
{
    public class ProductCategory : Entity<int>
    {
        [DataField("Name")]
        public virtual string Name { get; set; }

        [DataField("TestValue")]
        public virtual string Value { get; set; }

        public virtual string TestValue { get; set; }
    }
}
