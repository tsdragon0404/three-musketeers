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

        public ProductCategory GetByID(long itemID)
        {
            return DAHelper.SelectOne<ProductCategory>(config, "SELECT * FROM PRODUCTCATEGORY WHERE PRODUCTCATEGORYID=@0", itemID);
        }

        public ProductCategory Save(ProductCategory item)
        {
            return DAHelper.Save(config, item);
        }

        public bool Delete(long itemID)
        {
            return DAHelper.Delete<ProductCategory>(config, itemID);
        }
    }
}