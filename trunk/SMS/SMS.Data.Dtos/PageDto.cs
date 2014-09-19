using System.Collections.Generic;
using SMS.Common.Enums;

namespace SMS.Data.Dtos
{
    public class PageDto : PageBasicDto
    {
        public virtual string VNTitle { get; set; }
        public virtual string ENTitle { get; set; }
        public virtual string VNDescription { get; set; }
        public virtual string ENDescription { get; set; }
        public virtual IList<PageLabelDto> PageLabels { get; set; }
        public virtual IList<RoleDto> RolesHasPermission { get; set; }
    }

    public class LanguagePageDto : PageBasicDto
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
    }

    public class PageBasicDto
    {
        public virtual long ID { get; set; }
        public virtual PageType Type { get; set; }
        public virtual string Area { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Action { get; set; }
    }
}