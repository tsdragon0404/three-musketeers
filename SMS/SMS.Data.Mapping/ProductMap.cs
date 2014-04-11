﻿using FluentNHibernate.Mapping;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class ProductMap : BaseMap<Product>
    {
        public ProductMap()
        {
            Table("Product");
            Map(x => x.ProductCode);
            Map(x => x.VNName);
            Map(x => x.ENName);
            Map(x => x.VNDescription);
            Map(x => x.ENDescription);
            Map(x => x.UnitID);
            Map(x => x.ProductCategoryID);
            Map(x => x.Price);
            Map(x => x.Enable);
            Map(x => x.SEQ);
            Map(x => x.CreatedDate);
            Map(x => x.CreatedUser);
            Map(x => x.ModifiedDate);
            Map(x => x.ModifiedUser);
        }
    }
}