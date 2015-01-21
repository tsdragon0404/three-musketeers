using System.Collections.Generic;
using SMS.Data.Entities.Inventory;

namespace SMS.Data.Inventory
{
    public interface IProductCategoryDA
    {
        List<ProductCategory> GetList(bool isEnable = true);
        List<ProductCategory> GetListForInventory(bool isEnable = true);
        ProductCategory GetByID(long itemID);
        ProductCategory Save(ProductCategory item);
        bool Delete(long itemID);
    }
}