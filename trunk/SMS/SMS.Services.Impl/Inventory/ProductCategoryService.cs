using System.Collections.Generic;
using SMS.Business.Inventory;
using SMS.Data.Dtos;

namespace SMS.Services.Impl.Inventory
{
    public class ProductCategoryService : Services.Inventory.IProductCategoryService
    {
        public virtual IProductCategoryManagement Management { get; set; }

        public List<CategoryDto> GetList()
        {
            return Management.GetList();
        }

        public List<TModel> GetListForInventory<TModel>()
        {
            return Management.GetListForInventory<TModel>();
        }

        public CategoryDto GetByID(long itemID)
        {
            return Management.GetByID(itemID);
        }

        public CategoryDto GetByIDForInventory(long itemID)
        {
            return Management.GetByIDForInventory(itemID);
        }

        public CategoryDto Save(CategoryDto item)
        {
            return Management.Save(item);
        }

        public CategoryDto SaveForInventory(CategoryDto item)
        {
            return Management.SaveForInventory(item);
        }

        public bool Delete(long itemID)
        {
            return Management.Delete(itemID);
        }

        public bool DeleteForInventory(long itemID)
        {
            return Management.DeleteForInventory(itemID);
        }
    }
}