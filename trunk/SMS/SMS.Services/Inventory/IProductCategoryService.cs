using System.Collections.Generic;
using SMS.Data.Dtos.Inventory;

namespace SMS.Services.Inventory
{
    public interface IProductCategoryService
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