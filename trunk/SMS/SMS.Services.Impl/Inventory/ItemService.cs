using System.Collections.Generic;
using SMS.Business.Inventory;
using SMS.Data.Dtos.Inventory;
using SMS.Services.Inventory;

namespace SMS.Services.Impl.Inventory
{
    public class ItemService : IItemService
    {
        public virtual IItemManagement Management { get; set; }

        public List<ItemDto> GetList()
        {
            return Management.GetList();
        }

        public ItemDto GetByID(long itemID)
        {
            return Management.GetByID(itemID);
        }

        public ItemDto Save(ItemDto item)
        {
            return Management.Save(item);
        }

        public bool Delete(long itemID)
        {
            return Management.Delete(itemID);
        }
    }
}