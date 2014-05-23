using System.Collections.Generic;
using Core.Data;

namespace SMS.Data.Entities
{
    public class Page : Entity
    {
        public virtual string VNTitle { get; set; }

        public virtual string ENTitle { get; set; }

        public virtual string VNDescription { get; set; }

        public virtual string ENDescription { get; set; }

        public virtual string Path { get; set; }

        public IList<PageLabel> PageLabels { get; set; }
    }
}