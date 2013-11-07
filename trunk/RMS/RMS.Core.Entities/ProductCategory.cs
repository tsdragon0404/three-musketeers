using TM.Data;
using TM.Data.BaseClasses;
using TM.Data.Mapping;

namespace RMS.Core.Entities
{
    public class ProductCategory : Entity
    {
        [DataField("Name")]
        public virtual string Name { get; set; }
    }
}
