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

        public ProductCategory GetByID(long ID)
        {
            return DAHelper.SelectOne<ProductCategory>(config, "SELECT * FROM PRODUCTCATEGORY WHERE PRODUCTCATEGORYID=@0", ID);
        }

        public ProductCategory Save(ProductCategory item)
        {
            if (item.ProductCategoryID > 0)
                return DAHelper.Update(config, item, new[] { "VNNAME", "ENNAME", "VNDESCRIPTION", "ENDESCRIPTION", "SEQ", "MODIFIEDDATE", "MODIFIEDUSER" });
            return DAHelper.Save(config, item);
        }

        public bool Delete(long ID)
        {
            return DAHelper.Delete<ProductCategory>(config, ID);
        }
    }
}