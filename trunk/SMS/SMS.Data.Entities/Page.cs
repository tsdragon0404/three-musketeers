using System.Collections.Generic;

namespace SMS.Data.Entities
{
    public class Page : Entity
    {
        public virtual string VNTitle { get; set; }

        public virtual string ENTitle { get; set; }

        public virtual string VNDescription { get; set; }

        public virtual string ENDescription { get; set; }

        public virtual string Path { get; set; }

        public virtual IList<PageLabel> PageLabels { get; set; }
    }
}