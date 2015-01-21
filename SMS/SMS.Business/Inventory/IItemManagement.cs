using System.Collections.Generic;
using SMS.Data.Dtos.Inventory;

namespace SMS.Business.Inventory
{
    public interface IItemManagement
    {
        List<ItemDto> GetList();
        ItemDto GetByID(long itemID);
        ItemDto Save(ItemDto item);
        bool Delete(long itemID);
    }
}