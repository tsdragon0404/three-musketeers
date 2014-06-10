namespace SMS.Data.Dtos
{
    public class LanguageProductDto
    {
        public virtual long ID { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual LanguageUnitDto Unit { get; set; }
        public virtual LanguageProductCategoryDto ProductCategory { get; set; }
    }
}
