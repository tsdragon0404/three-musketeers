using System.Collections.Generic;
using SMS.Data.Dtos.Inventory;

namespace SMS.Business.Inventory
{
    public interface IProductCategoryManagement
    {
        List<ProductCategoryDto> GetList();
        List<TModel> GetListForInventory<TModel>();
        ProductCategoryDto GetByID(long itemID);
        ProductCategoryDto GetByIDForInventory(long itemID);
        ProductCategoryDto Save(ProductCategoryDto item);
        ProductCategoryDto SaveForInventory(ProductCategoryDto item);
        bool Delete(long itemID);
        bool DeleteForInventory(long itemID);
    }
}