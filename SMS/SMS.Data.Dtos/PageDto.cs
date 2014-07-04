using System.Collections.Generic;

namespace SMS.Data.Dtos
{
    public class PageDto
    {
        public virtual long ID { get; set; }
        public virtual string VNTitle { get; set; }
        public virtual string ENTitle { get; set; }
        public virtual string VNDescription { get; set; }
        public virtual string ENDescription { get; set; }
        public virtual string Area { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Action { get; set; }
        public virtual IList<PageLabelDto> PageLabels { get; set; }
        public virtual IList<RoleDto> RolesHasPermission { get; set; }
    }
}