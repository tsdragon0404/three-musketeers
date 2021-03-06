﻿using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class ProductCategoryMap : BaseMap<ProductCategory>
    {
        public ProductCategoryMap()
        {
            Table("ProductCategory");
            Map(x => x.ProductCategoryCode);
            Map(x => x.VNName);
            Map(x => x.ENName);
            Map(x => x.VNDescription);
            Map(x => x.ENDescription);
            References(x => x.Branch).Column("BranchID");
            HasMany(x => x.Products)
                .KeyColumn("ProductID")
                .Inverse();
        }
    }
}