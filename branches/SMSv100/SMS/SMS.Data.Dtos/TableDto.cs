using System;

namespace SMS.Data.Dtos
{
    public class TableDto : EnableSortableDto
    {
        public virtual long ID { get; set; }
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual AreaDto Area { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }

    public class LanguageTableDto
    {
        public virtual long ID { get; set; }
        public virtual string Name { get; set; }
        public virtual LanguageAreaDto Area { get; set; }
    }
}
