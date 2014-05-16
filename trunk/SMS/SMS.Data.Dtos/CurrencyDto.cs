using System;

namespace SMS.Data.Dtos
{
    public class CurrencyDto : EnableSortableDto
    {
        public virtual long ID { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Exchange { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
