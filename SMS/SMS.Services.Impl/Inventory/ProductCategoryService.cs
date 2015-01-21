using System.Collections.Generic;
using SMS.Business.Inventory;
using SMS.Data.Dtos.Inventory;

namespace SMS.Services.Impl.Inventory
{
    public class ProductCategoryService : Services.Inventory.IProductCategoryService
    {
        public virtual IProductCategoryManagement Management { get; set; }

        public List<ProductCategoryDto> GetList()
        {
            return Management.GetList();
        }

        public List<TModel> GetListForInventory<TModel>()
        {
            return Management.GetListForInventory<TModel>();
        }

        public ProductCategoryDto GetByID(long itemID)
        {
            return Management.GetByID(itemID);
        }

        public ProductCategoryDto GetByIDForInventory(long itemID)
        {
            return Management.GetByIDForInventory(itemID);
        }

        public ProductCategoryDto Save(ProductCategoryDto item)
        {
            return Management.Save(item);
        }

        public ProductCategoryDto SaveForInventory(ProductCategoryDto item)
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