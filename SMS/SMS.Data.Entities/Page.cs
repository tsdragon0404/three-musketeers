using System.Collections.Generic;
using Core.Data;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    public class Page : Entity, IEnableEntity
    {
        public virtual string VNTitle { get; set; }

        public virtual string ENTitle { get; set; }

        public virtual string VNDescription { get; set; }

        public virtual string ENDescription { get; set; }

        public virtual PageType Type { get; set; }

        public virtual string Area { get; set; }

        public virtual string Controller { get; set; }

        public virtual string Action { get; set; }

        public virtual bool Enable { get; set; }

        public virtual IList<PageLabel> PageLabels { get; set; }
    }
}