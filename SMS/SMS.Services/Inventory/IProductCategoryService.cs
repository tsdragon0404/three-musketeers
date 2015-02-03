using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services.Inventory
{
    public interface IProductCategoryService
    {
        List<CategoryDto> GetList();
        List<TModel> GetListForInventory<TModel>();
        CategoryDto GetByID(long itemID);
        CategoryDto GetByIDForInventory(long itemID);
        CategoryDto Save(CategoryDto item);
        CategoryDto SaveForInventory(CategoryDto item);
        bool Delete(long itemID);
        bool DeleteForInventory(long itemID);
    }
}