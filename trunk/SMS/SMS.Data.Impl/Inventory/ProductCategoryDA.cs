using System.Collections.Generic;
using Core.Data.PetaPoco;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public class ProductCategoryDA : EntityDA, IProductCategoryDA
    {
        public ProductCategoryDA(IConfig config, ISqlStatementDA sqlStatementDA)
            : base(config, sqlStatementDA)
        {
        }

        public List<ProductCategory> GetList(bool isEnable = true)
        {
            return DAHelper.Select<ProductCategory>(config, "SELECT * FROM PRODUCTCATEGORY WHERE ENABLE=@0", isEnable.ToSqlValue());
        }

        public List<ProductCategory> GetListForInventory(bool isEnable = true)
        {
            return DAHelper.Select<ProductCategory>(config, "SELECT * FROM PRODUCTCATEGORY WHERE BRANCHID IS NULL AND ENABLE=@0", isEnable.ToSqlValue());
        }

        public ProductCategory GetByID(long categoryID)
        {
            return DAHelper.SelectOne<ProductCategory>(config, "SELECT * FROM PRODUCTCATEGORY WHERE PRODUCTCATEGORYID=@0", categoryID);
        }

        public ProductCategory Update(ProductCategory category, params string[] columns)
        {
            return DAHelper.Update(config, category, columns);
        }

        public ProductCategory Insert(ProductCategory category)
        {
            return DAHelper.Insert(config, category);
        }

        public bool Delete(long categoryID)
        {
            return DAHelper.Delete<ProductCategory>(config, categoryID);
        }
    }
}