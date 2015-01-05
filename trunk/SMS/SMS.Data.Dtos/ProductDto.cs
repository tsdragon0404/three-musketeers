using System;

namespace SMS.Data.Dtos
{
    public class ProductDto : ProductBasicDto
    {
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual string VNDescription { get; set; }
        public virtual string ENDescription { get; set; }
        public virtual UnitDto Unit { get; set; }
        public virtual ProductCategoryDto ProductCategory { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }

    public class LanguageProductDto : ProductBasicDto
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual LanguageUnitDto Unit { get; set; }
        public virtual LanguageProductCategoryDto ProductCategory { get; set; }
    }

    public class ProductForKitchenDto
    {
        public virtual long ID { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string Name { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual string UnitName { get; set; }
    }

    public class ProductBasicDto : EnableSortableDto
    {
        public virtual long ID { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual decimal Price { get; set; }
    }

    public class SearchProductDto
    {
        public virtual long ID { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual decimal Price { get; set; }
    }
}
