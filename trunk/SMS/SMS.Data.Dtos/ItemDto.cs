using System;

namespace SMS.Data.Dtos
{
    public class ItemDto : ItemBasicDto
    {
        public virtual UnitDto Unit { get; set; }
        public virtual ProductCategoryDto ProductCategory { get; set; }
    }

    public class LanguageItemDto : ItemBasicDto
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual LanguageUnitDto Unit { get; set; }
        public virtual LanguageProductCategoryDto ProductCategory { get; set; }
    }

    public class ItemBasicDto : EnableSortableDto
    {
        public virtual long ID { get; set; }
        public virtual string ItemCode { get; set; }
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual string VNDescription { get; set; }
        public virtual string ENDescription { get; set; }
        public virtual bool IsInventory { get; set; }
        public virtual decimal MinQuantity { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
